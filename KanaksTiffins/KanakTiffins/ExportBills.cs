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
    public partial class ExportBills : Form
    {
        private int month;
        private int year;

        KanakTiffinsEntities db = CommonUtilities.db;

        public ExportBills()
        {
            InitializeComponent();
        }

        public ExportBills(int month, int year)
        {
            this.month = month;
            this.year = year;

            InitializeComponent();
        }

        private void PrintBills_Load(object sender, EventArgs e)
        {
            CommonUtilities.populateAreas(comboBox_specificArea);
        }

        private void button_export_Click(object sender, EventArgs e)
        { 
            //GENERATE A DOCUMENT TO PRINT.              
            List<Int32> customerIds;
            if (radioButton_specificArea.Checked)
            {
                Area selectedArea = comboBox_specificArea.SelectedItem as Area;
                customerIds = db.CustomerDetails.Where(x => x.AreaId == selectedArea.AreaId).Select(x => x.CustomerId).ToList();

                //validation
                if (selectedArea.AreaName == null)
                {
                    MessageBox.Show("Please select an area.", "Error");
                    return;
                }
                if (customerIds.Count == 0)
                {
                    MessageBox.Show("No users found in this area.", "Error");
                    return;
                }
            }
            else
            {
                customerIds = db.CustomerDetails.Select(x => x.CustomerId).ToList();
            }           

            String path = CommonUtilities.getFileSaveLocation();

            //if user quits the dialog box
            if (path.Trim().Length == 0)
                return;

            CommonUtilities.displayProgressBar();

            this.Hide();

            String errorMessage = "The following users do not have any saved bills for " + db.Months.Where(x=>x.MonthId == month).Single().MonthName + " " + year + ": \n";
            bool errorOccurred = false;
            foreach (Int32 customerId in customerIds)
            {
                if (db.MonthlyBills.Where(x => x.CustomerId == customerId && x.DateTaken.Month == month && x.DateTaken.Year == year).Count() == 0) //No bill for this user for this month/year
                {
                    errorOccurred = true;
                    CustomerDetail customer = db.CustomerDetails.Where(x => x.CustomerId == customerId).Single();
                    errorMessage += ("- " + customer.FirstName + " " + customer.LastName + "\n");
                    continue;
                }                
                CommonUtilities.exportDataGridViewToExcel(path, customerId, month, year);
            }
            MessageBox.Show("Exported successfully", "Success");
            if (errorOccurred)
                MessageBox.Show(errorMessage, "Warning");

            CommonUtilities.hideProgressBar();

            this.Close();
        }

        private void radioButton_specificArea_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_specificArea.Visible = true;
        }

        private void radioButton_All_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_specificArea.Visible = false;
        }
    }
}
