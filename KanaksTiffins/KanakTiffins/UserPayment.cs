using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace KanakTiffins
{
    public partial class UserPayment : Form
    {
        KanakTiffinsEntities db = CommonUtilities.db;
        public Int32 selectedCustomerId;
        public bool hasComeFromUserDetail = false;
        
        public UserPayment()
        {
            InitializeComponent();
        }

        private void UserPayment_Load(object sender, EventArgs e)
        {
           //Checking if the request came from User Detail Page
            if (hasComeFromUserDetail)
            {
                //Loading the page with values along with certain groupbox property modifications
                groupBox_searchUsers.Visible = false;
                groupBox_userPayment.Visible = true;
                groupBox_userPayment.Dock = DockStyle.Top;
                groupBox1.Dock = DockStyle.Bottom;
                groupBox1.Visible = true;
                dataGridView_PaymentHistory.Visible = true;

                retrieveUserDetails();
            }
            else
            {
                CommonUtilities.populateAreas(comboBox_area);
            }           
        }

        /// <summary>
        /// Returns a list of customers(if present) for the criteria mentioned.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_userSearch_Click(object sender, EventArgs e)
        {
            String firstName = textBox_firstName.Text.ToLower();
            String lastName = textBox_lastName.Text.ToLower();
            String areaName = comboBox_area.SelectedValue == null ? "" : comboBox_area.SelectedValue.ToString();

            //Search Result (List of usernames)
            dataGridView_searchUsers.DataSource = db.CustomerDetails.Where(x => x.FirstName.Contains(firstName) && x.LastName.Contains(lastName) && x.isDeleted.Equals("N") && x.Area.AreaName.Contains(areaName)).OrderBy(x=>x.FirstName).ToList();
            hideUnnecessaryColumns();   
        }

        /// <summary>
        /// Used to Hide Unnecessary(Extra) Columns fetched from database.
        /// </summary>
        private void hideUnnecessaryColumns()
        {
            dataGridView_searchUsers.CellClick -= userDetails;
            dataGridView_searchUsers.CellClick += userDetails;
            dataGridView_searchUsers.Columns["CustomerId"].Visible = false;
            dataGridView_searchUsers.Columns["EmailAddress"].Visible = false;
            dataGridView_searchUsers.Columns["Address"].Visible = false;
            dataGridView_searchUsers.Columns["DepositAmount"].Visible = false;            
            dataGridView_searchUsers.Columns["Area"].Visible = false;
            dataGridView_searchUsers.Columns["AreaId"].Visible = false;
            dataGridView_searchUsers.Columns["MealPlan"].Visible = false;
            dataGridView_searchUsers.Columns["MealPlanId"].Visible = false;
            dataGridView_searchUsers.Columns["LunchOrDinner"].Visible = false;
            dataGridView_searchUsers.Columns["LunchOrDinnerId"].Visible = false;
            dataGridView_searchUsers.Columns["isDeleted"].Visible = false;

            if (dataGridView_searchUsers.Columns.Contains("ExtraCharges"))
                dataGridView_searchUsers.Columns["ExtraCharges"].Visible = false;

            if (dataGridView_searchUsers.Columns.Contains("MonthlyBills"))
                dataGridView_searchUsers.Columns["MonthlyBills"].Visible = false;

            if (dataGridView_searchUsers.Columns.Contains("CustomerPaymentHistories"))
                dataGridView_searchUsers.Columns["CustomerPaymentHistories"].Visible = false;

            if (dataGridView_searchUsers.Columns.Contains("CustomerDue"))
                dataGridView_searchUsers.Columns["CustomerDue"].Visible = false;
        }

        /// <summary>
        /// Loads the User Details on Click of a User Id.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userDetails(object sender, DataGridViewCellEventArgs e)
        {            
            //Getting the value of clicked row
            DataGridView dataGridView = sender as DataGridView;
            DataGridViewCellCollection selectedUser = dataGridView.CurrentRow.Cells as DataGridViewCellCollection;

            //Returns the selected customer ID
            selectedCustomerId = Int32.Parse(selectedUser["CustomerId"].Value.ToString());
            retrieveUserDetails();

            groupBox_userPayment.Visible = true;
            groupBox1.Visible = true;
            dataGridView_PaymentHistory.Visible = true;
        }
        
        /// <summary>
        /// Retrieves the User details based on customer id.
        /// </summary>
        private void retrieveUserDetails()
        {
            CustomerDetail customerDetail = db.CustomerDetails.Where(x => x.CustomerId == selectedCustomerId && x.isDeleted.Equals("N")).Single();

            textBox_userName.Text = customerDetail.FirstName + " " + customerDetail.LastName;
            textBox_area.Text = customerDetail.Area.AreaName;
            textBox_dueAmount.Text = customerDetail.CustomerDue == null ? "0" : customerDetail.CustomerDue.DueAmount.ToString();
            textBox_carryForwardAmount.Text = customerDetail.CustomerDue == null ? "0" : customerDetail.CustomerDue.CarryforwardAmount.ToString();
                       
            displayPaymentHistory();
        }
        
        /// <summary>
        /// Updates the User Payment History on Submit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_userPayment_Click(object sender, EventArgs e)
        {            
            //Validation To check for Empty Values
            if (textBox_amountPaid.Text.Trim().Length == 0 || textBox_paymentMethod.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please Enter the Amount and Payment Mode", "Error");
                return;
            }

            //If payment amount is not an integer
            int paymentAmount = 0;
            Int32.TryParse(textBox_amountPaid.Text, out paymentAmount);
            if (paymentAmount == 0)
            {
                MessageBox.Show("Payment amount should be a positive integer greater than 0", "Error");
                return;
            }

            //Validation to check for Special Characters
            var withoutSpecial = new string(textBox_amountPaid.Text.Where(c => Char.IsLetterOrDigit(c) || Char.IsWhiteSpace(c)).ToArray());
            if (textBox_amountPaid.Text != withoutSpecial)
            {
                MessageBox.Show("Amount Paid Contains Special Characters", "Error");
                return;
            }
            DateTime theEnteredDate =  DateTime.Parse(dateTimePicker_paidOn.Text);

            //To check if any payment was made on the same date
            if (db.CustomerPaymentHistories.Where(x => x.CustomerId == selectedCustomerId).ToList().Select(x => x.PaidOn).Contains(theEnteredDate))
            {
                MessageBox.Show("You've Already Entered A Payment Record on the Same day.Please verify.", "Error");
                return;
            }

            CustomerPaymentHistory paymentDetails = new CustomerPaymentHistory();
            paymentDetails.CustomerId = selectedCustomerId;
            paymentDetails.PaidAmount = Int32.Parse(textBox_amountPaid.Text);
            paymentDetails.PaidOn = theEnteredDate;
            paymentDetails.PaymentMethod = textBox_paymentMethod.Text;

            db.CustomerPaymentHistories.AddObject(paymentDetails);
            db.SaveChanges();

            MessageBox.Show("Added Payment Details Successfully", "Success");           

            displayPaymentHistory();

            //Update CustomerDues
            CommonUtilities.updateCustomerDues(selectedCustomerId);

            //Update values in text boxes
            textBox_dueAmount.Text = db.CustomerDues.Where(x => x.CustomerId == selectedCustomerId).First().DueAmount.ToString();
            textBox_carryForwardAmount.Text = db.CustomerDues.Where(x => x.CustomerId == selectedCustomerId).First().CarryforwardAmount.ToString();            
        }

        private void displayPaymentHistory()
        {
            //Payment history for this user
            dataGridView_PaymentHistory.DataSource = db.CustomerPaymentHistories.Where(x => x.CustomerId == selectedCustomerId).ToList();
            
            dataGridView_PaymentHistory.CellClick -= editPaymentHistory;
            dataGridView_PaymentHistory.CellClick += editPaymentHistory;
            
            dataGridView_PaymentHistory.Columns["CustomerId"].Visible = false;
            dataGridView_PaymentHistory.Columns["CustomerDetail"].Visible = false;
        }

        private void editPaymentHistory(object sender, DataGridViewCellEventArgs e)
        {
            db.SaveChanges();
            CommonUtilities.updateCustomerDues(selectedCustomerId);
        }       
    }
}