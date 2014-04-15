﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Transactions;

namespace KanakTiffins
{
    /// <summary>
    /// This Form is used to add a new user to the database.
    /// </summary>
    public partial class AddNewUser : Form
    {
        KanakTiffinsEntities db = CommonUtilities.db;

        /* If a user navigates to User Details > Edit, this same form pops up (With the current balance field hidden). At such a time, that user's 
         * id is required to pre-populate the fields on this form.*/
        int selectedCustomerId;
        
        public AddNewUser()
        {
            InitializeComponent();
        }
        
        private void AddNewUser_Load(object sender, EventArgs e)
        {
            //Load the dropdown values of Area and Meal Plans
            populateAreas();

            //Populate the meal plan combo box
            populateMealPlans();

            //Populate the Lunch/Dinner  combo box
            populateLunchOrDinner();
        }

        /// <summary>
        /// Used to populate the MealPlans combo-box.
        /// </summary>
        private void populateMealPlans()
        {
            comboBox_typeOfLunch.DataSource = db.MealPlans.OrderBy(x=>x.MealAmount).ToList();
            comboBox_typeOfLunch.DisplayMember = "MealAmount";
            comboBox_typeOfLunch.ValueMember = "MealPlanId";            
        }

        /// <summary>
        /// Used to populate the Area combo-box
        /// </summary>
        private void populateAreas()
        {          
            comboBox_area.DataSource = db.Areas.OrderBy(x=>x.AreaName).ToList();
            comboBox_area.DisplayMember = "AreaName";
            comboBox_area.ValueMember = "AreaId";
        }

        /// <summary>
        /// Used to populate the Lunch/Dinner combo-box.
        /// </summary>
        private void populateLunchOrDinner()
        {
            comboBox_lunchOrDinner.DataSource = db.LunchOrDinners.ToList();
            comboBox_lunchOrDinner.DisplayMember = "Name";
            comboBox_lunchOrDinner.ValueMember = "Id"; 
        }
        
        /// <summary>
        /// Pre-populates the form fields, with the values pertaining to the Customer having id as 'selectedCustomerId'
        /// </summary>
        /// <param name="selectedCustomerId">The Id of the Customer whose details have to be pre-populated.</param>
        public void fillFormWithValues(int selectedCustomerId)
        {
            this.selectedCustomerId = selectedCustomerId;
                        
            button_SubmitAddNewUser.Visible = false;
            button_edit.Visible = true;

            //Fetch the Customer from the DB and populate the form-fields.
            CustomerDetail selectedCustomer = db.CustomerDetails.Where(x => x.CustomerId == selectedCustomerId && x.isDeleted.Equals("N")).FirstOrDefault();            
            textBox_firstName.Text = selectedCustomer.FirstName;
            textBox_lastName.Text = selectedCustomer.LastName;
            textBox_Address.Text = selectedCustomer.Address;           
            textBox_PhoneNumber.Text = selectedCustomer.PhoneNumber;
            textBox_EmailId.Text = selectedCustomer.EmailAddress;
            textBox_Deposit.Text = selectedCustomer.DepositAmount.ToString();
            textBox_DabbaWalaDeliveryCharges.Text = selectedCustomer.DefaultDabbawalaCharges.ToString();
            comboBox_area.SelectedValue = selectedCustomer.AreaId;
            comboBox_typeOfLunch.SelectedValue = selectedCustomer.MealPlanId;
            comboBox_lunchOrDinner.SelectedValue = selectedCustomer.LunchOrDinnerId;
        }

        /// <summary>
        /// Validates the form-fields before insertion into the DB.
        /// </summary>
        /// <returns></returns>
        private bool validate()
        {            
            bool errorOccurred = false;
            String errorMessage = "Please correct the following errors: \n\n";

            if (textBox_firstName.Text.Trim().Equals(""))
            {
                errorOccurred = true;
                errorMessage += "-> Please enter a First Name \n";
            }
            if (errorOccurred)
            {
                MessageBox.Show(errorMessage);                
            }

            return errorOccurred;
        }

        /// <summary>
        /// Submit button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_SubmitAddNewUser_Click_1(object sender, EventArgs e)
        {
            if(validate())
                return; //Validation fails.

            //Validation successful.

            //Create a new CustomerDetail object, fetch form-field-values and insert into the DB.
            CustomerDetail customerDetail = new CustomerDetail();            
            int lastInsertedCustomerId = db.CustomerDetails.Count();
            customerDetail.CustomerId = lastInsertedCustomerId + 1; //New Customer's id.

            fetchFormValues(customerDetail);                    

            bool exceptionOccured = false;
            try
            {
                bool success = false;

                /* For every new Customer inserted into the DB, entries are made in 2 tables - CustomerDetails and CustomerDues.
                 * Hence a transaction is required. */
                using (TransactionScope transaction = new TransactionScope())
                {
                    try
                    {
                        db.CustomerDetails.AddObject(customerDetail);

                        //Pending Balance should be inserted in the CustomerDues table.
                        CustomerDue dues = new CustomerDue();
                        dues.CustomerId = customerDetail.CustomerId;
                        int dueAmount = 0;
                        Int32.TryParse(textBox_currentBalance.Text.Trim(), out dueAmount);
                        dues.DueAmount = dueAmount;

                        db.CustomerDues.AddObject(dues);

                        db.SaveChanges();
                        transaction.Complete();
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        success = false;
                    }                    
                }
                if (success)
                    db.AcceptAllChanges(); //Transaction was successful, commit all changes.
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                exceptionOccured = true;
            }

            if (!exceptionOccured)
            {
                MessageBox.Show("User added successfully.");
            }
            else
            {
                MessageBox.Show("Something went wrong.");
            }
        }

        /// <summary>
        /// Fetches values from the form-fields and populates the customerDetail object.
        /// </summary>
        /// <param name="customerDetail">The CustomerDetail object into which the form-field-values are filled.</param>
        private void fetchFormValues(CustomerDetail customerDetail)
        {
            customerDetail.EmailAddress = textBox_EmailId.Text;
            customerDetail.FirstName = textBox_firstName.Text;
            customerDetail.LastName = textBox_lastName.Text;
            customerDetail.Address = textBox_Address.Text;
            customerDetail.AreaId = Int32.Parse(comboBox_area.SelectedValue.ToString());
            customerDetail.MealPlanId = Int32.Parse(comboBox_typeOfLunch.SelectedValue.ToString());
            int depositAmount = 0;
            Int32.TryParse(textBox_Deposit.Text.Trim(), out depositAmount);
            customerDetail.DepositAmount = depositAmount;
            customerDetail.PhoneNumber = textBox_PhoneNumber.Text;            
            customerDetail.LunchOrDinnerId = Int32.Parse(comboBox_lunchOrDinner.SelectedValue.ToString());
            int defaultDabbawalaDeliveryCharges = 0;
            Int32.TryParse(textBox_DabbaWalaDeliveryCharges.Text.Trim(), out defaultDabbawalaDeliveryCharges);
            customerDetail.DefaultDabbawalaCharges = defaultDabbawalaDeliveryCharges;
            int initialBalance = 0;
            Int32.TryParse(textBox_currentBalance.Text.Trim(), out initialBalance);
            customerDetail.InitialBalance = initialBalance;
            customerDetail.isDeleted = "N";
        }

        /// <summary>
        /// The Edit button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_edit_Click(object sender, EventArgs e)
        {
            if(validate())
                return; //Validation fails.

            //Fetch the CustomerDetail object which has to be modified.
            CustomerDetail selectedCustomer = db.CustomerDetails.Where(x => x.CustomerId == selectedCustomerId && x.isDeleted.Equals("N")).FirstOrDefault();
            
            //Fetch the updated values from the form-fields.
            fetchFormValues(selectedCustomer);
            
            //Commit the changes.
            db.SaveChanges();

            MessageBox.Show("Updated Successfully.");
        }

        /// <summary>
        /// Opens up a pop-up with a text-box to add a new value for MealPlan into the MealPlans master table.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel_addNewMealPlan_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddNewMaster newMaster = new AddNewMaster();
            newMaster.clickedLinkName = (sender as LinkLabel).Name;
            newMaster.Show();
            newMaster.FormClosed -= AddNewMaster_FormClosed;
            newMaster.FormClosed += AddNewMaster_FormClosed;
        }

        /// <summary>
        /// Opens up a pop-up with a text-box to add a new value for Area into the Areas master table.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel_addNewArea_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddNewMaster newMaster = new AddNewMaster();
            newMaster.clickedLinkName = (sender as LinkLabel).Name;
            newMaster.Show();
            newMaster.FormClosed -= AddNewMaster_FormClosed;
            newMaster.FormClosed += AddNewMaster_FormClosed;
        }

        /// <summary>
        /// If a user chooses to add a new value to the Areas/MealPlans master table, then on submitting the new value in the popup,
        /// the combo-boxes shoul be refreshed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            populateAreas();
            populateMealPlans();
        }
    }
}
