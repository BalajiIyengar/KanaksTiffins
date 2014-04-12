﻿using System;
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
        KanakTiffinsEntities db = new KanakTiffinsEntities();
        private Int32 selectedCustomerId;

        public UserPayment()
        {
            InitializeComponent();
        }

        private void UserPayment_Load(object sender, EventArgs e)
        {
            loadAreas();
        }

        /// <summary>
        /// Used to Populate Area DropDown to Search Users.
        /// </summary>
        private void loadAreas()
        {
            comboBox_area.DataSource = db.Areas.OrderBy(x => x.AreaName).ToList();
            comboBox_area.DisplayMember = "AreaName";
            comboBox_area.ValueMember = "AreaName";
        
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
             dataGridView_searchUsers.DataSource  = db.CustomerDetails.Where(x => x.FirstName.Contains(firstName) && x.LastName.Contains(lastName) && x.Area.AreaName.Contains(areaName)).ToList();
             hideIncessantColumns();
             groupBox_userPayment.Visible = false;
             
         
        }

        /// <summary>
        /// Used to Hide Incessant(Extra/Unnecessary) Columns fetched from database.
        /// </summary>
        private void hideIncessantColumns()
        {

            dataGridView_searchUsers.CellClick -= userDetails;
            dataGridView_searchUsers.CellClick += userDetails;
            dataGridView_searchUsers.Columns["CustomerId"].Visible = false;
            dataGridView_searchUsers.Columns["EmailAddress"].Visible = false;
            dataGridView_searchUsers.Columns["Address"].Visible = false;
            dataGridView_searchUsers.Columns["DepositAmount"].Visible = false;
            dataGridView_searchUsers.Columns["DabbawalaCharges"].Visible = false;
            dataGridView_searchUsers.Columns["Area"].Visible = false;
            dataGridView_searchUsers.Columns["AreaId"].Visible = false;
            dataGridView_searchUsers.Columns["MealPlan"].Visible = false;
            dataGridView_searchUsers.Columns["MealPlanId"].Visible = false;
            dataGridView_searchUsers.Columns["LunchOrDinner"].Visible = false;
            dataGridView_searchUsers.Columns["LunchOrDinnerId"].Visible = false;


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
            groupBox_userPayment.Visible = true;
            
           
            //Getting the value of clicked row
            DataGridView button = sender as DataGridView;
            DataGridViewCellCollection selectedUser = button.CurrentRow.Cells as DataGridViewCellCollection;

            //Returns the selected customer ID
            this.selectedCustomerId = Int32.Parse(selectedUser["CustomerId"].Value.ToString());

            CustomerDetail customerDetail = db.CustomerDetails.Where(x=>x.CustomerId == this.selectedCustomerId).Single();

            textBox_userName.Text = customerDetail.FirstName + " " + customerDetail.LastName;
            textBox_area.Text = customerDetail.Area.AreaName;
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
                MessageBox.Show("None of the Parameters can be Zero or Empty");
                return;
            }

            //Validation to check for Special Characters
            var withoutSpecial = new string(textBox_amountPaid.Text.Where(c => Char.IsLetterOrDigit(c) || Char.IsWhiteSpace(c)).ToArray());
            if (textBox_amountPaid.Text != withoutSpecial)
            {
                MessageBox.Show("Amount Paid Contains Special Characters");
                return;
            }

            CustomerPaymentHistory paymentDetails = new CustomerPaymentHistory();
            paymentDetails.CustomerId = this.selectedCustomerId;
            paymentDetails.PaidAmount = Int32.Parse(textBox_amountPaid.Text);
            paymentDetails.PaidOn = DateTime.Parse(dateTimePicker_paidOn.Text);
            paymentDetails.PaymentMethod = textBox_paymentMethod.Text;

            db.CustomerPaymentHistories.AddObject(paymentDetails);
            db.SaveChanges();

            MessageBox.Show("Added Payment Details Successfully");

            groupBox_userPayment.Visible = false;
        }
    }
}