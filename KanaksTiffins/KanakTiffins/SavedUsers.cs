using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KanakTiffins
{
    public partial class SavedUsers : Form
    {
        KanakTiffinsEntities db = CommonUtilities.db;

        public SavedUsers()
        {
            InitializeComponent();
        }

        private void SavedUsers_Load(object sender, EventArgs e)
        {
            CommonUtilities.populateMonths(comboBox_month);
            CommonUtilities.populateYears(comboBox_year);

        }

        private void button_getSavedUsers_Click(object sender, EventArgs e)
        {
            int year = Int32.Parse(comboBox_year.Text);
            Month selectedMonth = comboBox_month.SelectedItem as Month;
            int monthId = selectedMonth.MonthId;
            int numberOfDays = DateTime.DaysInMonth(year, monthId);

            DateTime startDate = new DateTime(year, monthId, 1);
            DateTime endDate = new DateTime(year, monthId, numberOfDays);

            List<int> customerIds = db.MonthlyBills.Where(x => x.DateTaken >= startDate && x.DateTaken <= endDate).Select(x => x.CustomerId).ToList();

            List<int> noDupes = customerIds.Distinct().ToList();

            List<int> allCustomers = db.CustomerDetails.Select(x=>x.CustomerId).ToList();

            List<int> unsavedUsers = allCustomers.Except(noDupes).ToList();
          

            List<CustomerDetail> unsavedUsersList = new List<CustomerDetail>();
            foreach (int customerId in unsavedUsers)
            {
                unsavedUsersList.Add(db.CustomerDetails.Where(x => x.CustomerId == customerId).Single());
            }
            
            dataGridView_unsavedUsers.DataSource = unsavedUsersList;

            List<CustomerDetail> savedUsers = new List<CustomerDetail>();
            foreach (int customerId in noDupes)
            {
                savedUsers.Add(db.CustomerDetails.Where(x=>x.CustomerId == customerId).Single());
            }

            dataGridView_savedUsers.DataSource = savedUsers;

            hideExcessiveColumns(dataGridView_unsavedUsers);
            hideExcessiveColumns(dataGridView_savedUsers);
           
           
        }

        void hideExcessiveColumns(DataGridView dataGridView_savedUsers)
        {
        
            dataGridView_savedUsers.Columns["CustomerId"].Visible = false;
            dataGridView_savedUsers.Columns["Address"].Visible = false;
            dataGridView_savedUsers.Columns["PhoneNumber"].Visible = false;
            dataGridView_savedUsers.Columns["EmailAddress"].Visible = false;
            dataGridView_savedUsers.Columns["DepositAmount"].Visible = false;
            dataGridView_savedUsers.Columns["AreaId"].Visible = false;
            dataGridView_savedUsers.Columns["MealPlanId"].Visible = false;
            dataGridView_savedUsers.Columns["LunchOrDinnerId"].Visible = false;
            dataGridView_savedUsers.Columns["DefaultDabbawalaCharges"].Visible = false;
            dataGridView_savedUsers.Columns["InitialBalance"].Visible = false;
            dataGridView_savedUsers.Columns["isDeleted"].Visible = false;
            dataGridView_savedUsers.Columns["Area"].Visible = false;
            dataGridView_savedUsers.Columns["MealPlan"].Visible = false;
            dataGridView_savedUsers.Columns["LunchOrDinner"].Visible = false;
            dataGridView_savedUsers.Columns["CustomerPaymentHistories"].Visible = false;
            dataGridView_savedUsers.Columns["ExtraCharges"].Visible = false;
            dataGridView_savedUsers.Columns["MonthlyBills"].Visible = false;
            dataGridView_savedUsers.Columns["CustomerDue"].Visible = false;
        }
    }
}