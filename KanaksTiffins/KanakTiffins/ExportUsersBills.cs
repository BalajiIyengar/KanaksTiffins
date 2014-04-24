using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace KanakTiffins
{
    public partial class ExportUsersBills : Form
    {
        public Int32 selectedCustomerId;

        KanakTiffinsEntities db = CommonUtilities.db;

        public ExportUsersBills(Int32 selectedCustomerId)
        {
            this.selectedCustomerId = selectedCustomerId;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int32 fromMonth = comboBox_fromMonth.SelectedIndex + 1;
            Int32 fromYear = Int32.Parse(comboBox_fromYear.Text);
            Int32 toMonth = comboBox_toMonth.SelectedIndex + 1;
            Int32 toYear = Int32.Parse(comboBox_toYear.Text);

            //Validation
            if (fromYear > toYear)
            {
                MessageBox.Show("'From' date should be before/same as 'To' date", "Error");
                return;
            }
            if (fromYear == toYear && fromMonth > toMonth)
            {
                MessageBox.Show("'From' date should be before/same as 'To' date", "Error");
                return;
            }
            List<MonthlyBill> monthlyBills = db.MonthlyBills.Where(x => x.CustomerId == selectedCustomerId && x.DateTaken >= new DateTime(fromYear, fromMonth, 1) && x.DateTaken <= new DateTime(toYear, toMonth, 1)).ToList();
            if (monthlyBills.Count == 0)
            {
                MessageBox.Show("No bills found.");
                return;
            }

            //Validation succeeded.            
            this.Hide();

            String path = CommonUtilities.getFileSaveLocation();

            //if user quits the dialog box
            if (path.Trim().Length == 0)
                return;
            
            CommonUtilities.displayProgressBar();

            //start preparing the excel containing the bills.
            if (fromMonth == toMonth && fromYear == toYear)
            {
                Console.WriteLine(fromMonth + " " + fromYear);

                if (db.MonthlyBills.Where(x => x.CustomerId == selectedCustomerId && x.DateTaken.Month == fromMonth && x.DateTaken.Year == fromYear).Count() == 0) //Make sure that a bill exists for this month
                {
                    MessageBox.Show("No Bill found", "Error");
                }
                else
                {
                    CommonUtilities.exportDataGridViewToExcel(path, selectedCustomerId, fromMonth, fromYear);
                }                
            }
            else
            {
                int[] nextMonthAndYear = { fromMonth, fromYear };

                //Error handling
                bool errorOccurred = false;
                string errorMessage = "No Bills found for the following months: \n";

                //Bill for 'From' date
                if (db.MonthlyBills.Where(x => x.CustomerId == selectedCustomerId && x.DateTaken.Month == fromMonth && x.DateTaken.Year == fromYear).Count() == 0) //Make sure that a bill exists for this month
                {
                    errorOccurred = true;
                    errorMessage += ("- " + db.Months.Where(x => x.MonthId == fromMonth).Single().MonthName + ", " + fromYear + "\n");
                }
                else
                {
                    CommonUtilities.exportDataGridViewToExcel(path, selectedCustomerId, fromMonth, fromYear);
                }                    

                //Loop till 'To' date is reached.                
                while (true)
                {
                    nextMonthAndYear = getNextMonthAndYear(nextMonthAndYear[0], nextMonthAndYear[1]);

                    Console.WriteLine(nextMonthAndYear[0] + " " + nextMonthAndYear[1]);

                    int currentMonth = nextMonthAndYear[0];
                    int currentYear = nextMonthAndYear[1];

                    if (db.MonthlyBills.Where(x => x.CustomerId == selectedCustomerId && x.DateTaken.Month == currentMonth && x.DateTaken.Year == currentYear).Count() == 0) //Make sure that a bill exists for this month
                    {
                        errorOccurred = true;
                        errorMessage += ("- " + db.Months.Where(x => x.MonthId == currentMonth).Single().MonthName + ", " + currentYear + "\n");
                    }
                    else
                    {
                        CommonUtilities.exportDataGridViewToExcel(path, selectedCustomerId, currentMonth, currentYear);
                    }

                    if (currentMonth == toMonth && currentYear == toYear)
                        break;
                }

                if (errorOccurred)
                {
                    MessageBox.Show(errorMessage, "Warning");
                }
            }
            
            CommonUtilities.hideProgressBar();
            MessageBox.Show("Exported successfully", "Success");            
        }

        /// <summary>
        /// For deciding which month/year's bill is to be generated next.
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns>int[0] = monthId, int[1] = year</returns>
        private int[] getNextMonthAndYear(int month, int year)
        {
            int[] monthAndYear = new int[2];

            //Next month.
            int nextMonth = (month+1) == 13 ? 1 : month+1;
            monthAndYear[0] = nextMonth;

            //Next year.
            int nextYear = nextMonth == 1 ? year+1 : year;           
            monthAndYear[1] = nextYear;

            return monthAndYear;
        }

        private void ExportUsersBills_Load(object sender, EventArgs e)
        {
            MonthCalendar currentMonth = new MonthCalendar();

            //Populate the from and to month combo boxes.
            CommonUtilities.populateMonths(comboBox_fromMonth);
            CommonUtilities.populateMonths(comboBox_toMonth);

            comboBox_fromMonth.SelectedIndex = currentMonth.TodayDate.Month - 1;
            comboBox_toMonth.SelectedIndex = currentMonth.TodayDate.Month - 1;

            //Populate the from and to year combo boxes.
            List<int> fromyears = new List<int>();
            List<int> toyears = new List<int>();     
            for (int year = 2012; year <= currentMonth.TodayDate.Year; year++)
            {
                fromyears.Add(year);
                toyears.Add(year);
            }
            comboBox_fromYear.DataSource = fromyears;
            comboBox_fromYear.SelectedItem = currentMonth.TodayDate.Year;
            comboBox_toYear.DataSource = toyears;
            comboBox_toYear.SelectedItem = currentMonth.TodayDate.Year;
        }
    }
}
