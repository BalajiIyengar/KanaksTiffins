using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace KanakTiffins
{
    class CommonUtilities
    {
        public static KanakTiffinsEntities db = new KanakTiffinsEntities();

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
        /// Creates an Excel file from the data in the DataGridView
        /// </summary>
        /// <param name="dataGridView">The DataGridView from which the data has to be read.</param>
        /// <param name="excelFilePath">Tha physical location of the file into which the Excel file will be written.</param>
        public static void exportDataGridViewToExcel(DataGridView dataGridView, string excelFilePath)
        {
            int numberOfColumns;
            
            //Open File
            StreamWriter wr = new StreamWriter(excelFilePath);

            //Determine the number of columns and write columns to file
            numberOfColumns = dataGridView.Columns.Count;
            for (int i = 0; i < numberOfColumns; i++)
            {
                wr.Write(dataGridView.Columns[i].Name.ToString().ToUpper() + "\t");
            }
            wr.WriteLine();

            //Write rows to excel file
            for (int i = 0; i < (dataGridView.Rows.Count - 1); i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    if (dataGridView.Rows[i].Cells[j].Value != null)
                        wr.Write(dataGridView.Rows[i].Cells[j].Value + "\t");
                    else
                    {
                        wr.Write("\t");
                    }
                }
                wr.WriteLine();
            }

            //Close file
            wr.Close();

            MessageBox.Show("Exported successfully", "Success");
        }

        /// <summary>
        /// Creates an Excel file from the data in the DataGridView
        /// </summary>
        /// <param name="dataGridView">The DataGridView from which the data has to be read.</param>
        /// <param name="excelFilePath">The physical location of the file into which the Excel file will be written.</param>
        /// <param name="customerId">The customerId of the Customer whose bill is being generated.</param>
        /// <param name="month">The month for which the bill is being generated.</param>
        /// <param name="year">The year for which the bill is being generated.</param>
        public static void exportDataGridViewToExcelUsingMicrosoft(DataGridView dataGridView, string excelFilePath, int customerId, int month, int year)
        {
            Microsoft.Office.Interop.Excel.Application excelSheet = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Range columnRangeInExcel;
            excelSheet.Application.Workbooks.Add(Type.Missing);

            CustomerDetail selectedCustomer = db.CustomerDetails.Where(x => x.CustomerId == customerId).First();

            //Customer Details at the beginning.
            excelSheet.Cells[1, 1] = selectedCustomer.FirstName.ToUpper() + " " + selectedCustomer.LastName.ToUpper() + ", " + selectedCustomer.Address + ", " + selectedCustomer.Area.AreaName;
            
            //Merge 5 columns in the 1st row.
            columnRangeInExcel = excelSheet.get_Range((Microsoft.Office.Interop.Excel.Range)excelSheet.Cells[1, 1], (Microsoft.Office.Interop.Excel.Range)excelSheet.Cells[1, 5]);
            columnRangeInExcel.MergeCells = true;
            columnRangeInExcel.Font.Bold = true;
            columnRangeInExcel.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; //Align Center
            columnRangeInExcel.BorderAround2(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick);

            //Green background for 1st row
            columnRangeInExcel.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.GreenYellow);                        
            
            //Header for the bill
            int columnNumberInExcel = 1;
            for (int columnNumber = 0; columnNumber < dataGridView.Columns.Count; columnNumber++)
            {
                //CustomerId and CustomerDetails - these columns should not be added to the Excel sheet.
                if (dataGridView.Columns[columnNumber].Name.Equals("CustomerId") || dataGridView.Columns[columnNumber].Name.Equals("CustomerDetail"))
                    continue;

                excelSheet.Cells[2, columnNumberInExcel] = dataGridView.Columns[columnNumber].HeaderText;

                //Alignment and border
                columnRangeInExcel = (Microsoft.Office.Interop.Excel.Range)excelSheet.Cells[2, columnNumberInExcel];
                columnRangeInExcel.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; //Align center
                columnRangeInExcel.Font.Bold = true;
                columnRangeInExcel.BorderAround2(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium);

                columnNumberInExcel++;
            }

            //Entire bill for the month            
            int rowNumberInExcel = 3;
            for (int rowNumber = 0; rowNumber < dataGridView.Rows.Count; rowNumber++) //iterate over the rows in the data grid view
            {
                columnNumberInExcel = 1;

                for (int columnNumber = 0; columnNumber < dataGridView.Columns.Count; columnNumber++) //iterate over the columns in the data grid view
                {
                    //CustomerId and CustomerDetails - these columns should not be added to the Excel sheet.
                    if (dataGridView.Columns[columnNumber].Name.Equals("CustomerId") || dataGridView.Columns[columnNumber].Name.Equals("CustomerDetail"))
                        continue;
                    
                    excelSheet.Cells[rowNumberInExcel, columnNumberInExcel] = dataGridView.Rows[rowNumber].Cells[columnNumber].Value;                   

                    //Alignment and border
                    columnRangeInExcel = (Microsoft.Office.Interop.Excel.Range)excelSheet.Cells[rowNumberInExcel, columnNumberInExcel];
                    columnRangeInExcel.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; //Align center                    
                    columnRangeInExcel.BorderAround2(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin);
                    //For DateTaken, define separate format "dd-MMM-yy"
                    if (dataGridView.Columns[columnNumber].Name.Equals("DateTaken"))
                    {
                        columnRangeInExcel.NumberFormat = "dd-MMM-yy";
                    }

                    columnNumberInExcel++;
                }

                rowNumberInExcel++;
            }
            
            //Below all bills, we display TOTAL(Lunch/Dinner).
            excelSheet.Cells[34, 1] = "Lunch/Dinner total: ";
            excelSheet.Cells[34, 2] = db.MonthlyBills.Where(x => x.CustomerId == customerId && x.DateTaken.Month == month && x.DateTaken.Year == year).Sum(x => x.LunchAmount).ToString(); //Lunch total
            excelSheet.Cells[34, 3] = db.MonthlyBills.Where(x => x.CustomerId == customerId && x.DateTaken.Month == month && x.DateTaken.Year == year).Sum(x => x.DinnerAmount).ToString(); //Dinner total
            excelSheet.Cells[34, 5] = db.MonthlyBills.Where(x => x.CustomerId == customerId && x.DateTaken.Month == month && x.DateTaken.Year == year).Sum(x => x.DailyPayment).ToString(); //Daily payments total
            columnRangeInExcel = excelSheet.get_Range((Microsoft.Office.Interop.Excel.Range)excelSheet.Cells[34, 1], (Microsoft.Office.Interop.Excel.Range)excelSheet.Cells[34, 5]);
            columnRangeInExcel.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; //Align Center
            columnRangeInExcel.Font.Bold = true;
            columnRangeInExcel.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            columnRangeInExcel.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
            columnRangeInExcel.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);

            //Dabbawala charges and extra delivery charges.
            excelSheet.Cells[35, 1] = "Dabbawala charges: ";
            excelSheet.Cells[35, 2] = db.ExtraCharges.Where(x => x.CustomerId == customerId && x.MonthId == month && x.Year == year).First().DabbawalaCharges.ToString();
            excelSheet.Cells[35, 4] = "Delivery charges: ";
            excelSheet.Cells[35, 5] = db.ExtraCharges.Where(x => x.CustomerId == customerId && x.MonthId == month && x.Year == year).First().DeliveryCharges.ToString();
            columnRangeInExcel = excelSheet.get_Range((Microsoft.Office.Interop.Excel.Range)excelSheet.Cells[35, 1], (Microsoft.Office.Interop.Excel.Range)excelSheet.Cells[35, 5]);
            columnRangeInExcel.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; //Align Center            
            columnRangeInExcel.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            columnRangeInExcel.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

            //total monthly bill / overall bill
            int monthlyBill =    db.MonthlyBills.Where(x => x.CustomerId == customerId && x.DateTaken.Month == month && x.DateTaken.Year == year).Sum(x => x.LunchAmount)
                               + db.MonthlyBills.Where(x => x.CustomerId == customerId && x.DateTaken.Month == month && x.DateTaken.Year == year).Sum(x => x.DinnerAmount)
                               - db.MonthlyBills.Where(x => x.CustomerId == customerId && x.DateTaken.Month == month && x.DateTaken.Year == year).Sum(x => x.DailyPayment);
            int overallDues = db.CustomerDues.Where(x => x.CustomerId == customerId).First().DueAmount;
            excelSheet.Cells[36, 1] = "MONTHLY BILL: "+monthlyBill+"   OVERALL DUES PENDING: "+overallDues;
            columnRangeInExcel = excelSheet.get_Range((Microsoft.Office.Interop.Excel.Range)excelSheet.Cells[36, 1], (Microsoft.Office.Interop.Excel.Range)excelSheet.Cells[36, 5]);
            columnRangeInExcel.MergeCells = true;
            columnRangeInExcel.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; //Align Center  
            columnRangeInExcel.Font.Bold = true;
            columnRangeInExcel.BorderAround2(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick);
            columnRangeInExcel.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);

            //Formatting
            columnRangeInExcel = excelSheet.get_Range((Microsoft.Office.Interop.Excel.Range)excelSheet.Cells[1, 1], (Microsoft.Office.Interop.Excel.Range)excelSheet.Cells[36, 5]);
            columnRangeInExcel.EntireColumn.AutoFit();            
            //columnRangeInExcel.BorderAround2(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin);

            //Save Excel file.
            excelSheet.ActiveWorkbook.SaveCopyAs(excelFilePath);
            excelSheet.ActiveWorkbook.Saved = true;
            excelSheet.Quit();

            MessageBox.Show("Exported successfully", "Success");
        }
    }
}
