using System;
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
           CommonUtilities.populateAreas(comboBox_area);

            //Populate the meal plan combo box
           CommonUtilities.populateMealPlans(comboBox_typeOfLunch);

            //Populate the Lunch/Dinner  combo box
           CommonUtilities.populateLunchOrDinner(comboBox_lunchOrDinner);
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
            comboBox_area.SelectedItem = selectedCustomer.Area;
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
            String errorMessage = "";

            if (textBox_firstName.Text.Trim().Equals(""))
            {
                errorOccurred = true;
                errorMessage += "-> Please enter First Name \n";
            }
            if (comboBox_area.Text.Trim().Equals(""))
            {
                errorOccurred = true;
                errorMessage += "-> Please select an Area \n";
            }

            long result;
            if(textBox_PhoneNumber.Text.Trim().Length != 0  )
            {
                if(!long.TryParse(textBox_PhoneNumber.Text, out result))
                {
                errorOccurred = true;
                errorMessage += "-> Please Enter a Valid Phone Number \n";
                }
            }

            if (textBox_EmailId.Text.Trim().Length != 0)
            {
                if (!(textBox_EmailId.Text.Contains("@") && textBox_EmailId.Text.Contains(".") && (textBox_EmailId.Text.IndexOf(".") - textBox_EmailId.Text.IndexOf("@")  > 1)))
                {
                    errorOccurred = true;
                    errorMessage += "-> Please Enter a Valid Email Id \n";
                }
            }

            int deposit;
            if (textBox_Deposit.Text.Trim().Length != 0)
            {
                if (!Int32.TryParse(textBox_Deposit.Text, out deposit))
                {
                    errorOccurred = true;
                    errorMessage += "-> Please Enter a Valid Deposit \n";
                }
            }

            int balance;
            if (textBox_currentBalance.Text.Trim().Length != 0)
            {
                if (!Int32.TryParse(textBox_currentBalance.Text, out balance))
                {
                    errorOccurred = true;
                    errorMessage += "-> Please Enter a Valid Balance \n";
                }
            }

            int delivery;
            if (textBox_DabbaWalaDeliveryCharges.Text.Trim().Length != 0)
            {
                if (!Int32.TryParse(textBox_DabbaWalaDeliveryCharges.Text, out delivery))
                {
                    errorOccurred = true;
                    errorMessage += "-> Please Enter a Valid Delivery Charge \n";
                }
            }

            if (errorOccurred)
            {
                MessageBox.Show(errorMessage, "Error");                
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
                MessageBox.Show("User added successfully.", "Success");                
            }
            else
            {
                MessageBox.Show("Something went wrong.", "Error");
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

            String selectedAreaName = comboBox_area.SelectedValue.ToString();
            if (selectedAreaName != null)
            {
                int areaId = db.Areas.Where(x => x.AreaName.Equals(selectedAreaName)).First().AreaId;
                customerDetail.AreaId = areaId;
            }
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

            MessageBox.Show("Updated Successfully.", "Success");
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
           CommonUtilities.populateAreas(comboBox_area);
           CommonUtilities.populateMealPlans(comboBox_typeOfLunch);
        }
    }
}
