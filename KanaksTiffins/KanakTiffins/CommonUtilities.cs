using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace KanakTiffins
{
    class CommonUtilities
    {
        public static KanakTiffinsEntities db = new KanakTiffinsEntities();
        private static ProgressBar progressBar;

        /// <summary>
        /// Based on the changes made/not made to the current bill being displayed, updates the Customer's dues.
        /// </summary>
        /// <param name="customerId">The customerId of the Customer whose dues have to be recalculated.</param>
        public static void updateCustomerDues(int customerId)
        {
            Int32 totalPayableAmount;
            try
            {
                totalPayableAmount = db.MonthlyBills.Where(x => x.CustomerId == customerId).Sum(x => x.LunchAmount + x.DinnerAmount - x.DailyPayment);
            }
            catch (Exception ex)
            {
                totalPayableAmount = 0;
            }

            Int32 totalPaidAmount;
            try
            {
                totalPaidAmount = db.CustomerPaymentHistories.Where(x => x.CustomerId == customerId).Sum(x => x.PaidAmount);
            }
            catch (Exception ex)
            {
                totalPaidAmount = 0;
            }

            Int32 dabbawalaCharges;
            try
            {
                dabbawalaCharges = db.ExtraCharges.Where(x => x.CustomerId == customerId).Sum(x => x.DabbawalaCharges);
            }
            catch (Exception ex)
            {
                dabbawalaCharges = 0;
            }

            Int32 deliveryCharges;
            try
            {
                deliveryCharges = db.ExtraCharges.Where(x => x.CustomerId == customerId).Sum(x => x.DeliveryCharges);
            }
            catch (Exception ex)
            {
                deliveryCharges = 0;
            }

            Int32 initialBalance = db.CustomerDetails.Where(x => x.CustomerId == customerId && x.isDeleted.Equals("N")).First().InitialBalance;

            Int32 totalDueAmount = totalPayableAmount + dabbawalaCharges + deliveryCharges + initialBalance - totalPaidAmount;

            //Put values in CustomerDues tables
            CustomerDue updatedDues = db.CustomerDues.Where(x => x.CustomerId == customerId).FirstOrDefault();

            if (updatedDues == null)
                updatedDues = new CustomerDue();

            updatedDues.CustomerId = customerId;
            if (totalDueAmount < 0)
            {
                updatedDues.CarryforwardAmount = -1 * totalDueAmount;
                updatedDues.DueAmount = 0;
            }
            else
            {
                updatedDues.DueAmount = totalDueAmount;
                updatedDues.CarryforwardAmount = 0;
            }

            if (db.CustomerDues.Where(x => x.CustomerId == customerId).Count() == 0)
            {
                db.CustomerDues.AddObject(updatedDues);
            }

            db.SaveChanges();
        }

        /// <summary>
        /// Populates the Area combo box.
        /// </summary>
        public static void populateAreas(ComboBox comboBoxObj)
        {
            List<Area> areas = new List<Area>();
            areas.Add(new Area());
            areas.AddRange(db.Areas.OrderBy(x => x.AreaName).ToList());
            comboBoxObj.DataSource = areas;
            comboBoxObj.DisplayMember = "AreaName";
            comboBoxObj.ValueMember = "AreaName";
        }

        /// <summary>
        /// Populates the Month combo box.
        /// </summary>
        public static void populateMonths(ComboBox comboBoxObj)
        {
            comboBoxObj.DataSource = db.Months.ToList();
            comboBoxObj.DisplayMember = "MonthName";
            comboBoxObj.ValueMember = "MonthId";           
        }

        /// <summary>
        /// Used to populate the MealPlans combo-box.
        /// </summary>
        public static void populateMealPlans(ComboBox comboBoxObj)
        {
            comboBoxObj.DataSource = db.MealPlans.OrderBy(x => x.MealAmount).ToList();
            comboBoxObj.DisplayMember = "MealAmount";
            comboBoxObj.ValueMember = "MealPlanId";
        }

        /// <summary>
        /// Used to populate the Lunch/Dinner combo-box.
        /// </summary>
        public static void populateLunchOrDinner(ComboBox comboBoxObj)
        {
            comboBoxObj.DataSource = db.LunchOrDinners.ToList();
            comboBoxObj.DisplayMember = "Name";
            comboBoxObj.ValueMember = "Id";
        }

        /// <summary>
        /// Open up a dialog box to specify the location where to save the generated bill.
        /// </summary>
        /// <returns></returns>
        public static String getFileSaveLocation()
        {
            string path = "";
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = " Excel Sheet (.xlsx) | *.xlsx";
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
            }
            return path;
        }

        /// <summary>
        /// Common Search Functionality based on various parameters
        /// </summary>
        /// <returns></returns>
        public static List<CustomerDetail> getSearchResults(String firstName,String lastName,String areaName,int enteredBalance)
        {
            List<CustomerDetail> searchResults = new List<CustomerDetail>();

            //Search Result (List of usernames)
            searchResults = db.CustomerDetails.Where(x => x.FirstName.Contains(firstName) &&
                                                                           x.LastName.Contains(lastName) && x.isDeleted.Equals("N") &&
                                                                           x.Area.AreaName.Contains(areaName) && (x.CustomerDue.DueAmount>=enteredBalance)
                                                                     ).OrderBy(x=>x.FirstName).ToList();
            return searchResults;

        }

        /// <summary>
        /// Display a progress bar for heavy tasks.
        /// </summary>
        public static void displayProgressBar()
        {
            progressBar = new ProgressBar();
            progressBar.Show();
        }

        /// <summary>
        /// Hide the progress bar.
        /// </summary>
        public static void hideProgressBar()
        {
            progressBar.Close();
        }

        /// <summary>
        /// Creates an Excel file from the data in the DataGridView
        /// </summary>
        /// <param name="dataGridView">The DataGridView from which the data has to be read.</param>
        /// <param name="excelFilePath">The physical location of the file into which the Excel file will be written.</param>
        /// <param name="customerId">The customerId of the Customer whose bill is being generated.</param>
        /// <param name="month">The month for which the bill is being generated.</param>
        /// <param name="year">The year for which the bill is being generated.</param>
        public static void exportDataGridViewToExcel(string excelFilePath, int customerId, int month, int year)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.DisplayAlerts = false;
            Workbooks excelWorkbooks = excelApp.Workbooks;
            Workbook excelWorkbook = null;
            Sheets excelWorksheets = null;
            Worksheet excelWorksheet = null;            
            Range columnRangeInExcel;
            Range usedRange;
            Range usedRangeColumns;
            PageSetup pageSetup;

            bool exists = true;
            try
            {
                excelWorkbook = excelWorkbooks.Open(excelFilePath, null, false);                
            }
            catch (Exception ex)
            {
                excelWorkbook = excelWorkbooks.Add();                               
                exists = false;
            }

            excelWorksheets = excelWorkbook.Sheets;

            excelWorksheet = excelWorksheets.get_Item("Sheet1");
            
            CustomerDetail selectedCustomer = db.CustomerDetails.Where(x => x.CustomerId == customerId).First();

            //Retrieve the bill for the selected customer, for the specified month and year.
            List<MonthlyBill> thisMonthsBill = selectedCustomer.MonthlyBills.Where(x => x.DateTaken.Month == month && x.DateTaken.Year == year).ToList();            
            
            //Starting column index
            usedRange = excelWorksheet.UsedRange;
            usedRangeColumns = usedRange.Columns;
            int startColumnIndex = usedRangeColumns.Count == 1 ? 1 : usedRangeColumns.Count + 2;
            int endColumnIndex = startColumnIndex + 4;

            //Customer Details at the beginning.
            excelWorksheet.Cells[1, startColumnIndex] = selectedCustomer.FirstName.ToUpper() + " " + selectedCustomer.LastName.ToUpper() + ", " + (selectedCustomer.Address.Trim().Length==0?" ":( selectedCustomer.Address + ", ")) + selectedCustomer.Area.AreaName;
            
            //Merge 5 columns in the 1st row.
            columnRangeInExcel = excelWorksheet.get_Range((Range)excelWorksheet.Cells[1, startColumnIndex], (Range)excelWorksheet.Cells[1, endColumnIndex]);
            columnRangeInExcel.MergeCells = true;
            columnRangeInExcel.Font.Bold = true;
            columnRangeInExcel.HorizontalAlignment = XlHAlign.xlHAlignCenter; //Align Center
            columnRangeInExcel.BorderAround2(XlLineStyle.xlContinuous, XlBorderWeight.xlThick);

            //Green background for 1st row
            columnRangeInExcel.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.GreenYellow);                        
            
            //Header for the bill
            int columnNumberInExcel = startColumnIndex;
            excelWorksheet.Cells[2, columnNumberInExcel++] = new DateTime(year, month, 1).ToString("MMM-yyyy");
            excelWorksheet.Cells[2, columnNumberInExcel++] = "Lunch";
            excelWorksheet.Cells[2, columnNumberInExcel++] = "Dinner";
            excelWorksheet.Cells[2, columnNumberInExcel++] = "Comments";
            excelWorksheet.Cells[2, columnNumberInExcel++] = "Paid";

            //Alignment and border
            columnRangeInExcel = excelWorksheet.get_Range((Range)excelWorksheet.Cells[2, startColumnIndex], (Range)excelWorksheet.Cells[2, endColumnIndex]);
            columnRangeInExcel.HorizontalAlignment = XlHAlign.xlHAlignCenter; //Align center
            columnRangeInExcel.Font.Bold = true;
            columnRangeInExcel.Borders.LineStyle = XlLineStyle.xlContinuous;
            columnRangeInExcel.Borders.Weight = XlBorderWeight.xlMedium;
                        
            //Entire bill for the month            
            int rowNumberInExcel = 3;
            for (int dayNumber = 0; dayNumber < thisMonthsBill.Count; dayNumber++) //iterate over the rows in the List.
            {
                columnNumberInExcel = startColumnIndex;

                MonthlyBill dailyBill = thisMonthsBill.ElementAt(dayNumber);

                excelWorksheet.Cells[rowNumberInExcel, columnNumberInExcel++] = dailyBill.DateTaken.Day; //Date Taken
                
                //For DateTaken, define separate format "dd"
                columnRangeInExcel = (Range)excelWorksheet.Cells[rowNumberInExcel, columnNumberInExcel-1];
                columnRangeInExcel.NumberFormat = "dd";  

                excelWorksheet.Cells[rowNumberInExcel, columnNumberInExcel++] = dailyBill.LunchAmount; //Lunch
                excelWorksheet.Cells[rowNumberInExcel, columnNumberInExcel++] = dailyBill.DinnerAmount; //Dinner
                excelWorksheet.Cells[rowNumberInExcel, columnNumberInExcel++] = dailyBill.Comments; //Comments
                excelWorksheet.Cells[rowNumberInExcel, columnNumberInExcel++] = dailyBill.DailyPayment; //DailyPayments

                //Alignment and border
                columnRangeInExcel = excelWorksheet.get_Range((Range)excelWorksheet.Cells[rowNumberInExcel, startColumnIndex], (Range)excelWorksheet.Cells[rowNumberInExcel, endColumnIndex]);
                columnRangeInExcel.HorizontalAlignment = XlHAlign.xlHAlignCenter; //Align center  
                columnRangeInExcel.Borders.LineStyle = XlLineStyle.xlContinuous;
                columnRangeInExcel.Borders.Weight = XlBorderWeight.xlThin;
                rowNumberInExcel++;
            }
            
            //Below all bills, we display TOTAL(Lunch/Dinner).
            excelWorksheet.Cells[rowNumberInExcel, startColumnIndex] = "Total: ";
            excelWorksheet.Cells[rowNumberInExcel, startColumnIndex + 1] = db.MonthlyBills.Where(x => x.CustomerId == customerId && x.DateTaken.Month == month && x.DateTaken.Year == year).Sum(x => x.LunchAmount).ToString(); //Lunch total
            excelWorksheet.Cells[rowNumberInExcel, startColumnIndex + 2] = db.MonthlyBills.Where(x => x.CustomerId == customerId && x.DateTaken.Month == month && x.DateTaken.Year == year).Sum(x => x.DinnerAmount).ToString(); //Dinner total
            excelWorksheet.Cells[rowNumberInExcel, endColumnIndex] = db.MonthlyBills.Where(x => x.CustomerId == customerId && x.DateTaken.Month == month && x.DateTaken.Year == year).Sum(x => x.DailyPayment).ToString(); //Daily payments total
            columnRangeInExcel = excelWorksheet.get_Range((Range)excelWorksheet.Cells[rowNumberInExcel, startColumnIndex], (Range)excelWorksheet.Cells[rowNumberInExcel, endColumnIndex]);
            columnRangeInExcel.HorizontalAlignment = XlHAlign.xlHAlignCenter; //Align Center
            columnRangeInExcel.Font.Bold = true;
            columnRangeInExcel.Borders.LineStyle = XlLineStyle.xlContinuous;
            columnRangeInExcel.Borders.Weight = XlBorderWeight.xlMedium;
            columnRangeInExcel.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);

            rowNumberInExcel++;

            //Dabbawala charges and extra delivery charges.
            excelWorksheet.Cells[rowNumberInExcel, startColumnIndex] = "Dabbawala";
            excelWorksheet.Cells[rowNumberInExcel, startColumnIndex + 1] = db.ExtraCharges.Where(x => x.CustomerId == customerId && x.MonthId == month && x.Year == year).First().DabbawalaCharges.ToString();
            excelWorksheet.Cells[rowNumberInExcel, startColumnIndex + 3] = "Delivery";
            excelWorksheet.Cells[rowNumberInExcel, endColumnIndex] = db.ExtraCharges.Where(x => x.CustomerId == customerId && x.MonthId == month && x.Year == year).First().DeliveryCharges.ToString();
            columnRangeInExcel = excelWorksheet.get_Range((Range)excelWorksheet.Cells[rowNumberInExcel, startColumnIndex], (Range)excelWorksheet.Cells[rowNumberInExcel, endColumnIndex]);
            columnRangeInExcel.HorizontalAlignment = XlHAlign.xlHAlignCenter; //Align Center            
            columnRangeInExcel.Borders.LineStyle = XlLineStyle.xlContinuous;
            columnRangeInExcel.Borders.Weight = XlBorderWeight.xlThin;

            rowNumberInExcel++;

            //total monthly bill / overall bill
            int monthlyBill =    db.MonthlyBills.Where(x => x.CustomerId == customerId && x.DateTaken.Month == month && x.DateTaken.Year == year).Sum(x => x.LunchAmount)
                               + db.MonthlyBills.Where(x => x.CustomerId == customerId && x.DateTaken.Month == month && x.DateTaken.Year == year).Sum(x => x.DinnerAmount)
                               - db.MonthlyBills.Where(x => x.CustomerId == customerId && x.DateTaken.Month == month && x.DateTaken.Year == year).Sum(x => x.DailyPayment);
            int overallDues = db.CustomerDues.Where(x => x.CustomerId == customerId).First().DueAmount;
            excelWorksheet.Cells[rowNumberInExcel, startColumnIndex] = "BILL: "+monthlyBill+"   OVERALL: "+overallDues;
            columnRangeInExcel = excelWorksheet.get_Range((Range)excelWorksheet.Cells[rowNumberInExcel, startColumnIndex], (Range)excelWorksheet.Cells[rowNumberInExcel, endColumnIndex]);
            columnRangeInExcel.MergeCells = true;
            columnRangeInExcel.HorizontalAlignment = XlHAlign.xlHAlignCenter; //Align Center  
            columnRangeInExcel.Font.Bold = true;
            columnRangeInExcel.BorderAround2(XlLineStyle.xlContinuous, XlBorderWeight.xlThick);
            columnRangeInExcel.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);

            rowNumberInExcel++;

            //Please pay by 10th
            excelWorksheet.Cells[rowNumberInExcel, startColumnIndex] = "Please pay by 10th of every month";
            columnRangeInExcel = excelWorksheet.get_Range((Range)excelWorksheet.Cells[rowNumberInExcel, startColumnIndex], (Range)excelWorksheet.Cells[rowNumberInExcel, endColumnIndex]);
            columnRangeInExcel.MergeCells = true;
            columnRangeInExcel.Font.Bold = true;
            columnRangeInExcel.HorizontalAlignment = XlHAlign.xlHAlignCenter; //Align Center

            rowNumberInExcel++;

            //Facebook
            excelWorksheet.Cells[rowNumberInExcel, startColumnIndex] = "www.facebook.com/kanak.tiffins";
            columnRangeInExcel = excelWorksheet.get_Range((Range)excelWorksheet.Cells[rowNumberInExcel, startColumnIndex], (Range)excelWorksheet.Cells[rowNumberInExcel, endColumnIndex]);
            columnRangeInExcel.MergeCells = true;
            columnRangeInExcel.Font.Bold = true;
            columnRangeInExcel.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            columnRangeInExcel.HorizontalAlignment = XlHAlign.xlHAlignCenter; //Align Center

            //Formatting
            columnRangeInExcel = excelWorksheet.get_Range((Range)excelWorksheet.Cells[1, startColumnIndex], (Range)excelWorksheet.Cells[rowNumberInExcel, endColumnIndex]);
            columnRangeInExcel.EntireColumn.AutoFit();
            columnRangeInExcel.EntireColumn.Font.Name = "Arial";
            columnRangeInExcel.EntireColumn.Font.Size = 9;
                        
            //Set margin = 0 and landscape mode.
            pageSetup = excelWorksheet.PageSetup;
            pageSetup.LeftMargin = 0;
            pageSetup.RightMargin = 0;
            pageSetup.TopMargin = 0;
            pageSetup.BottomMargin = 0;
            pageSetup.HeaderMargin = 0;
            pageSetup.FooterMargin = 0;
            pageSetup.Orientation = XlPageOrientation.xlLandscape;
            
            //Save Excel file.
            if(exists)
                excelWorkbook.Save();
            else
                excelWorkbook.SaveAs(excelFilePath);           
                        
            excelWorkbook.Close();            
            excelApp.Quit();
            
            //Clean-up tasks.
            Marshal.ReleaseComObject(pageSetup);
            Marshal.ReleaseComObject(usedRangeColumns);
            Marshal.ReleaseComObject(usedRange);
            Marshal.ReleaseComObject(columnRangeInExcel);
            Marshal.ReleaseComObject(excelWorksheet);
            Marshal.ReleaseComObject(excelWorksheets);
            Marshal.ReleaseComObject(excelWorkbook);
            Marshal.ReleaseComObject(excelWorkbooks);            
            Marshal.ReleaseComObject(excelApp);
            pageSetup = null;
            usedRangeColumns = null;
            usedRange = null;
            columnRangeInExcel = null;
            excelWorksheet = null;
            excelWorksheets = null;
            excelWorkbook = null;
            excelWorkbooks = null;
            excelApp = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }



        internal static void populateYears(ComboBox comboBox)
        {
            comboBox.DataSource = Enumerable.Range(DateTime.Today.Year - 10, 20).ToList();

        }
    }
}
