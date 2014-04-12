using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KanakTiffins
{
    public partial class AddNewUser : Form
    {
        KanakTiffinsEntities db = new KanakTiffinsEntities();
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
            comboBox_lunchOrDinner.DataSource = db.LunchOrDinners.ToList();
            comboBox_lunchOrDinner.DisplayMember = "Name";
            comboBox_lunchOrDinner.ValueMember = "Id"; 
        }

        void populateMealPlans()
        {

            comboBox_typeOfLunch.DataSource = db.MealPlans.OrderBy(x=>x.MealAmount).ToList();
            comboBox_typeOfLunch.DisplayMember = "MealAmount";
            comboBox_typeOfLunch.ValueMember = "MealPlanId";            
        }

        void populateAreas()
        {

            // Populates the area combo box 
            comboBox_area.DataSource = db.Areas.OrderBy(x=>x.AreaName).ToList();
            comboBox_area.DisplayMember = "AreaName";
            comboBox_area.ValueMember = "AreaId";
        }

        

        //Home Link Clicked
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Bills homePage = new Bills();
            this.Hide();
            homePage.Show();
        }



        private void AddNewArea_FormClosed(object sender, FormClosedEventArgs e)
        {
            populateAreas();
            populateMealPlans();
        }

        public void fillFormWithValues(int selectedCustomerId)
        {
            this.selectedCustomerId = selectedCustomerId;

            button_SubmitAddNewUser.Visible = false;
            button_edit.Visible = true;

            CustomerDetail selectedCustomer = db.CustomerDetails.Where(x => x.CustomerId == selectedCustomerId).FirstOrDefault();

            textBox_firstName.Text = selectedCustomer.FirstName;
            textBox_lastName.Text = selectedCustomer.LastName;
            textBox_Address.Text = selectedCustomer.Address;
           
            textBox_PhoneNumber.Text = selectedCustomer.PhoneNumber;
            textBox_EmailId.Text = selectedCustomer.EmailAddress;
            textBox_Deposit.Text = selectedCustomer.DepositAmount.ToString();
            textBox_DabbaWalaDeliveryCharges.Text = selectedCustomer.DabbawalaCharges.ToString();

            comboBox_area.SelectedValue = selectedCustomer.AreaId;
            comboBox_typeOfLunch.SelectedValue = selectedCustomer.MealPlanId;
            comboBox_lunchOrDinner.SelectedValue = selectedCustomer.LunchOrDinnerId;
        }

        private void button_SubmitAddNewUser_Click_1(object sender, EventArgs e)
        {

            /* Validation to be Added */


            /* Retrieve all the values from the form and insert into Database */

            CustomerDetail customerDetail = new CustomerDetail();

            /* Fetch the last Customer Id */
            int lastInsertedCustomerId = db.CustomerDetails.Select(x => x.CustomerId).Max();
            customerDetail.CustomerId = lastInsertedCustomerId + 1;

            fetchFormValues(customerDetail);            

            //Have to think about adding Balance.

            bool exceptionOccured = false;
            try
            {
                db.CustomerDetails.AddObject(customerDetail);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                exceptionOccured = true;
            }

            if (!exceptionOccured)
            {
                MessageBox.Show("User Added Successfully");
            }

            else
            {
                MessageBox.Show("Something Went Wrong.Could be a case of Duplicate Entries.");
            }
        }

        private void fetchFormValues(CustomerDetail customerDetail)
        {
            customerDetail.EmailAddress = textBox_EmailId.Text;
            customerDetail.FirstName = textBox_firstName.Text;
            customerDetail.LastName = textBox_lastName.Text;
            customerDetail.Address = textBox_Address.Text;
            customerDetail.AreaId = Int32.Parse(comboBox_area.SelectedValue.ToString());
            customerDetail.MealPlanId = Int32.Parse(comboBox_typeOfLunch.SelectedValue.ToString());
            customerDetail.DepositAmount = textBox_Deposit.Text.Trim() == "" ? 0 : Int32.Parse(textBox_Deposit.Text.ToString());
            customerDetail.PhoneNumber = textBox_PhoneNumber.Text;
            customerDetail.DabbawalaCharges = textBox_DabbaWalaDeliveryCharges.Text.Trim() == "" ? 0 : Int32.Parse(textBox_DabbaWalaDeliveryCharges.Text);
            customerDetail.LunchOrDinnerId = Int32.Parse(comboBox_lunchOrDinner.SelectedValue.ToString());
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            CustomerDetail selectedCustomer = db.CustomerDetails.Where(x => x.CustomerId == selectedCustomerId).FirstOrDefault();

            fetchFormValues(selectedCustomer);

            db.SaveChanges();

            MessageBox.Show("Updated Successfully.");
        }

        private void linkLabel_addNewMealPlan_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddNewMaster newMaster = new AddNewMaster();
            newMaster.clickedLinkName = (sender as LinkLabel).Name;
            newMaster.Show();
            newMaster.FormClosed -= AddNewArea_FormClosed;
            newMaster.FormClosed += AddNewArea_FormClosed;
        }

        private void linkLabel_addNewArea_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddNewMaster newMaster = new AddNewMaster();
            newMaster.clickedLinkName = (sender as LinkLabel).Name;
            newMaster.Show();
            newMaster.FormClosed -= AddNewArea_FormClosed;
            newMaster.FormClosed += AddNewArea_FormClosed;
        }

    }
}
