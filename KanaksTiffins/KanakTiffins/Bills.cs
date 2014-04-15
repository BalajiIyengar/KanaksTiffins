using System;
using System.Collections;
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
    /// This form is used for searching a particular user and viewing/saving/generating his/her monthly bills.
    /// </summary>
    public partial class Bills : Form
    {
        KanakTiffinsEntities db = CommonUtilities.db;
        
        //Calendar for the current month.
        MonthCalendar currentMonth = new MonthCalendar(); 

        //CustomerId of the Customer whose bill is being shown.
        int selectedCustomerId = -1;

        public Bills()
        {            
            InitializeComponent();
        }

        private void Bills_Load(object sender, EventArgs e)
        {
            populateAreas();

            populateMonths();

            //Populate the year combo box
            List<int> years = new List<int>();
            for (int year = 2012; year <= currentMonth.TodayDate.Year; year++)
            {
                years.Add(year);
            }
            comboBox_year.DataSource = years;
            comboBox_year.SelectedItem = currentMonth.TodayDate.Year;  
        }

        /// <summary>
        /// Populates the Area combo box.
        /// </summary>
        private void populateAreas()
        {
            List<Area> areas = new List<Area>();
            areas.Add(new Area());
            areas.AddRange(db.Areas.OrderBy(x=>x.AreaName).ToList());
            comboBox_area.DataSource = areas;
            comboBox_area.DisplayMember = "AreaName";
            comboBox_area.ValueMember = "AreaName";
        }

        /// <summary>
        /// Populates the Month combo box.
        /// </summary>
        private void populateMonths()
        {           
            comboBox_month.DataSource = db.Months.ToList();
            comboBox_month.DisplayMember = "MonthName";
            comboBox_month.ValueMember = "MonthId";
            comboBox_month.SelectedIndex = currentMonth.TodayDate.Month - 1; //Combo box index starts from 0
        }

        /// <summary>
        /// The Search button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Search_Click(object sender, EventArgs e)
        {
            //Disable the Monthly Bill gridview, which is disabled by default.
            groupBox_monthlyBill.Enabled = false;
            dataGridView_billForThisMonth.Visible = false;

            //Get hold of all form-fields.
            String firstName = textBox_firstName.Text.ToLower();
            String lastName = textBox_lastName.Text.ToLower();
            String areaName = comboBox_area.SelectedValue == null ? "" : comboBox_area.SelectedValue.ToString();

            //Query for retrieving users from the DB
            var users = db.CustomerDetails.Where(x => x.FirstName.Contains(firstName) && x.LastName.Contains(lastName) && x.isDeleted.Equals("N") && x.Area.AreaName.Contains(areaName))
                                        .Select(x => new { x.CustomerId, x.FirstName, x.LastName, x.Address, x.PhoneNumber, x.Area.AreaName });           
            dataGridView_users.DataSource = users.ToList();           

            //Hide the extra column.
            dataGridView_users.Columns["CustomerId"].Visible = false;

            //Registering an event handler when a particular row is clicked.
            dataGridView_users.CellClick -= displayMonthlyBillOfThisUser;
            dataGridView_users.CellClick += displayMonthlyBillOfThisUser;
        }

        /// <summary>
        /// Fetch/Generate the monthly bill of the selected user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void displayMonthlyBillOfThisUser(object sender, DataGridViewCellEventArgs e)
        {
            //Enable the Monthly Bill gridview, which is disabled by default
            groupBox_monthlyBill.Enabled = true;
            dataGridView_billForThisMonth.Visible = true;

            //Getting the value of clicked row
            DataGridView button = sender as DataGridView;
            DataGridViewCellCollection selectedUser = button.CurrentRow.Cells as DataGridViewCellCollection;

            //Returns the selected customer ID
            selectedCustomerId = Int32.Parse(selectedUser["CustomerId"].Value.ToString());  
           
            int month = currentMonth.TodayDate.Month;
            int year = currentMonth.TodayDate.Year;
            int noOfDays = DateTime.DaysInMonth(year, month);
            
            DateTime startDate = new DateTime(year, month, 1);
            DateTime endDate = new DateTime(year, month, noOfDays);           

            //Initialize Month to current month in the combo-box.
            comboBox_month.SelectedIndex = currentMonth.TodayDate.Month - 1; //Combo box index starts from 0
            
            createMonthlyBill(startDate, endDate);       
        }

        /// <summary>
        /// Fetches the bill for this month/year. If no such bill exists, then creates a new bill and populates it with default values.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        private void createMonthlyBill(DateTime startDate, DateTime endDate)
        {
            //If there are no customers in the DB, stop here itself.            
            if (db.CustomerDetails.Where(x=>x.isDeleted.Equals("N")).Count() == 0 || selectedCustomerId == -1)
                return;

            //Retrieve this month's bill for this user.
            List<MonthlyBill> thisMonthsBill = retrieveThisUsersBill(startDate, endDate);
            
            MonthlyBill monthlyBill;

            int month = startDate.Month;
            int year = startDate.Year;
            int noOfDays = DateTime.DaysInMonth(year, month);

            label_billNotSaved.Visible = false;

            //If no records found in the DB, then fill entries manually, according to meal plan of this user.
            if (thisMonthsBill.Count() == 0)
            {
                label_billNotSaved.Visible = true;

                for (int dayNumber = 1; dayNumber <= noOfDays; dayNumber++)
                {
                    monthlyBill = new MonthlyBill();
                    monthlyBill.DateTaken = new DateTime(year, month, dayNumber); //'dayNumber' in the current month.
                    monthlyBill.CustomerId = selectedCustomerId;

                    //Lunch and Dinner initialized to 0 for sundays and saturdays
                    if (monthlyBill.DateTaken.DayOfWeek.Equals(DayOfWeek.Sunday) || monthlyBill.DateTaken.DayOfWeek.Equals(DayOfWeek.Saturday))
                    {
                        monthlyBill.LunchAmount = 0;
                        monthlyBill.DinnerAmount = 0;
                    }
                    else
                    {
                        int lunchOrDinnerId = db.CustomerDetails.Where(x => x.CustomerId == selectedCustomerId && x.isDeleted.Equals("N")).First().LunchOrDinnerId;
                        int mealAmount = db.CustomerDetails.Where(x => x.CustomerId == selectedCustomerId && x.isDeleted.Equals("N")).First().MealPlan.MealAmount;

                        switch (lunchOrDinnerId)
                        {
                            case 0: //Lunch & Dinner
                            {
                                monthlyBill.LunchAmount = mealAmount;
                                monthlyBill.DinnerAmount = mealAmount;
                                break;                                    
                            }
                            case 1: //Lunch Only
                            {
                                monthlyBill.LunchAmount = mealAmount;
                                monthlyBill.DinnerAmount = 0;
                                break;    
                            }
                            case 2: //Dinner Only
                            {
                                monthlyBill.LunchAmount = 0;
                                monthlyBill.DinnerAmount = mealAmount;
                                break;    
                            }
                            default:
                                break;
                        }
                    }
                    thisMonthsBill.Add(monthlyBill);
                }
            }

            dataGridView_billForThisMonth.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView_billForThisMonth.DataSource = thisMonthsBill;

            modifyDataGridView();    
        }

        /// <summary>
        /// Highlights Sundays with Red and Saturdays with Yellow.
        /// </summary>
        /// <param name="thisMonthsBill"></param>
        private void highlightWeekends(List<MonthlyBill> thisMonthsBill)
        {
            //Highlighting sundays and saturdays
            for (int dayNumber = 1; dayNumber <= thisMonthsBill.Count(); dayNumber++)
            {
                if (thisMonthsBill[dayNumber - 1].DateTaken.DayOfWeek.Equals(DayOfWeek.Sunday))
                {
                    dataGridView_billForThisMonth.Rows[dayNumber - 1].DefaultCellStyle.BackColor = Color.Red;
                }
                if (thisMonthsBill[dayNumber - 1].DateTaken.DayOfWeek.Equals(DayOfWeek.Saturday))
                {
                    dataGridView_billForThisMonth.Rows[dayNumber - 1].DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
        }

        /// <summary>
        /// Formats the Data Grid View so that extraneous columns are hidden.
        /// </summary>
        private void modifyDataGridView()
        {            
            try
            {
                //Hide extraneous columns
                dataGridView_billForThisMonth.Columns["CustomerId"].Visible = false;

                //Set data grid view as editable                
                dataGridView_billForThisMonth.Columns["DateTaken"].ReadOnly = true;
                dataGridView_billForThisMonth.EditMode = DataGridViewEditMode.EditOnEnter;
                dataGridView_billForThisMonth.Columns["CustomerDetail"].Visible = false;

                highlightWeekends(dataGridView_billForThisMonth.DataSource as List<MonthlyBill>);               

                try
                {
                    //Set Dabbawala charges and delivery charges 
                    int monthId = comboBox_month.SelectedIndex + 1; //combo-box index starts from 0.
                    int year = Int32.Parse(comboBox_year.SelectedItem.ToString());

                    ExtraCharge extraCharges = db.ExtraCharges.Where(x => x.CustomerId == selectedCustomerId && x.MonthId == monthId && x.Year == year).First();
                    if (extraCharges == null)
                    {
                        textBox_dabbawalaCharges.Text = db.CustomerDetails.Where(x => x.CustomerId == selectedCustomerId && x.isDeleted.Equals("N")).FirstOrDefault().DefaultDabbawalaCharges.ToString();
                        textBox_deliveryCharges.Text = "0";
                    }
                    else
                    {
                        int dabbawalaCharges = extraCharges.DabbawalaCharges;
                        textBox_dabbawalaCharges.Text = dabbawalaCharges.ToString();
                        int deliveryCharges = extraCharges.DeliveryCharges;
                        textBox_deliveryCharges.Text = deliveryCharges.ToString();
                    }                    
                }
                catch (Exception ex)
                {
                    textBox_dabbawalaCharges.Text = db.CustomerDetails.Where(x => x.CustomerId == selectedCustomerId && x.isDeleted.Equals("N")).FirstOrDefault().DefaultDabbawalaCharges.ToString();
                    textBox_deliveryCharges.Text = "0";
                }                            
            }
            catch (NullReferenceException ex)
            { MessageBox.Show(ex.StackTrace + " " + ex.Message); }                    
        }

        private void dataGridView_billForThisMonth_KeyDown(object sender, KeyEventArgs e)
        {
                e.Handled = true;
                DataGridViewCell cell = dataGridView_billForThisMonth.CurrentCell;
                dataGridView_billForThisMonth.CurrentCell = cell;
                dataGridView_billForThisMonth.BeginEdit(true);            
        }

        /// <summary>
        /// Invokes the form which allows the user to add a new customer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel_addNewUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddNewUser addNewUser = new AddNewUser();            
            addNewUser.Show();
        }

        /// <summary>
        /// Invokes the SearchUsers form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel_searchUsers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SearchUsers searchUsers = new SearchUsers();
            searchUsers.Show();
        }

        /// <summary>
        /// Save this month's bill for this user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_save_Click(object sender, EventArgs e)
        {
            saveButtonCommonFunctionality();          
        }

        /// <summary>
        /// Common functionality that needs to be invoked when either of Save/Generate Bill has been clicked.
        /// </summary>
        private void saveButtonCommonFunctionality()
        {
            if(didValidationFail())
                return;

            bool success = false;
            /* For every new Customer inserted into the DB, entries are made in 3 tables - MonthlyBills, ExtraCharges and CustomerDues.
             * Hence a transaction is required. */
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    //Saves this bill in the DB.
                    saveButtonClicked();

                    //Updates the CustomerDues table.
                    CommonUtilities.updateCustomerDues(selectedCustomerId);

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

        /// <summary>
        /// Validates the form fields while saving/generating a user's bill.
        /// </summary>
        /// <returns>Whether validation succeeded or not.</returns>
        private bool didValidationFail()
        {
            bool errorOccurred = false;
            String errorMessage = "";

            int dummyInt = 0;
            if (!Int32.TryParse(textBox_dabbawalaCharges.Text.ToString(), out dummyInt))
            {
                errorOccurred = true;
                errorMessage += "-> Invalid value for Dabbawala Charges.\n";
            }            
            if (!Int32.TryParse(textBox_deliveryCharges.Text.ToString(), out dummyInt))
            {
                errorOccurred = true;
                errorMessage += "-> Invalid value for Delivery Charges.\n";
            }

            if (errorOccurred)
                MessageBox.Show(errorMessage);

            return errorOccurred;
        }
       
        /// <summary>
        /// Saves/Updates this bill in the DB.
        /// </summary>
        private void saveButtonClicked()
        {
            try
            {
                Hashtable dates = getCurrentMonthDates();
                List<MonthlyBill> billForSelectedMonth = retrieveThisUsersBill(DateTime.Parse(dates["startDate"].ToString()), DateTime.Parse(dates["endDate"].ToString()));

                //This bill is being saved for the first time.
                if (billForSelectedMonth.Count == 0)
                {
                    foreach (MonthlyBill thisDate in dataGridView_billForThisMonth.DataSource as List<MonthlyBill>)
                    {
                        db.MonthlyBills.AddObject(thisDate);
                    }
                }

                int monthId = DateTime.Parse(dates["startDate"].ToString()).Month;
                int year = DateTime.Parse(dates["startDate"].ToString()).Year;

                //Save extra charges.
                ExtraCharge charges;
                try
                {
                    charges = db.ExtraCharges.Where(x => x.CustomerId == selectedCustomerId && x.MonthId == monthId && x.Year == year).First();
                }
                catch (InvalidOperationException ex)
                {
                    charges = new ExtraCharge();
                    charges.CustomerId = selectedCustomerId;                   
                }
                
                charges.MonthId = DateTime.Parse(dates["startDate"].ToString()).Month;
                charges.Year = DateTime.Parse(dates["startDate"].ToString()).Year;

                if (textBox_dabbawalaCharges.Text.Trim().Equals(""))
                {
                    charges.DabbawalaCharges = db.CustomerDetails.Where(x => x.CustomerId == selectedCustomerId && x.isDeleted.Equals("N")).FirstOrDefault().DefaultDabbawalaCharges;
                }
                else
                {
                    charges.DabbawalaCharges = Int32.Parse(textBox_dabbawalaCharges.Text);
                }

                if (textBox_deliveryCharges.Text.Trim().Equals(""))
                {
                    charges.DeliveryCharges = 0;
                }
                else
                {
                    charges.DeliveryCharges = Int32.Parse(textBox_deliveryCharges.Text);
                }

                //An entry in ExtraCharges is being made for the first time for this customer for this month.
                if (db.ExtraCharges.Where(x => x.CustomerId == selectedCustomerId && x.MonthId == charges.MonthId && x.Year == charges.Year).Count() == 0)
                {
                    db.ExtraCharges.AddObject(charges);                    
                }

                db.SaveChanges();

                label_billNotSaved.Visible = false;

                MessageBox.Show("Updated Successfully.");                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured while updating." + ex.Message + " " + ex.StackTrace);               
            }   
        }

        private void comboBox_month_SelectedIndexChanged(object sender, EventArgs e)
        {
            billForSelectedMonthAndYear();
        }

        private void comboBox_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            billForSelectedMonthAndYear();
        }

        /// <summary>
        /// Retrieve the bill for the selected Month/Year. This method is called whenever a new value is selected from the combo-boxes for
        /// Month/Year.
        /// </summary>
        private void billForSelectedMonthAndYear()
        {
            Hashtable dates = getCurrentMonthDates();

            //If there are no customers in the DB, stop here itself.            
            if (db.CustomerDetails.Where(x => x.isDeleted.Equals("N")).Count() == 0 || selectedCustomerId == -1)
                return;

            createMonthlyBill(DateTime.Parse(dates["startDate"].ToString()), DateTime.Parse(dates["endDate"].ToString()));
        }

        /// <summary>
        /// From the combo-boxes for Month and Year, it constructs startDate and endDate.
        /// </summary>
        /// <returns>A Hashtable containing startDate and endDate.</returns>
        private Hashtable getCurrentMonthDates()
        {
            int month = comboBox_month.SelectedIndex + 1; //in the combo box, index starts from 0
            int year = comboBox_year.SelectedValue == null ? currentMonth.TodayDate.Year : Int32.Parse(comboBox_year.SelectedValue.ToString());
            int startDay = 1;
            int endDay = DateTime.DaysInMonth(year, month);

            DateTime startDate = new DateTime(year, month, startDay);
            DateTime endDate = new DateTime(year, month, endDay);

            Hashtable dates = new Hashtable();
            dates.Add("startDate", startDate);
            dates.Add("endDate", endDate);

            return dates;
        }

        /// <summary>
        /// Retrieve a list of this user's monthly bill, based on startDate and endDate
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        private List<MonthlyBill> retrieveThisUsersBill(DateTime startDate, DateTime endDate)
        {
            List<MonthlyBill> billForSelectedMonth = db.MonthlyBills.Where(x => x.CustomerId == selectedCustomerId && (x.DateTaken >= startDate && x.DateTaken <= endDate)).ToList();
            return billForSelectedMonth;
        }

        /// <summary>
        /// Saves the current bill and Prints it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_generateBill_Click(object sender, EventArgs e)
        {
            saveButtonCommonFunctionality();

            //GENERATE A DOCUMENT TO PRINT.            
        }
        
        /// <summary>
        /// Called when the user wishes to add/delete new values to/from any of the master tables.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PopulateMaster masters = new PopulateMaster();
            masters.Show();           
        }

        /// <summary>
        /// Redirects to User Payment Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UserPayment userPayment = new UserPayment();
            userPayment.Show();
        }

        /// <summary>
        /// Opens up the Add New Area popup.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel_addNewArea_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddNewMaster newMaster = new AddNewMaster();
            newMaster.clickedLinkName = (sender as LinkLabel).Name;
            newMaster.Show();

            newMaster.FormClosed -= AddNewArea_FormClosed;
            newMaster.FormClosed += AddNewArea_FormClosed;
        }

        /// <summary>
        /// When a user adds a new value to the Areas master table, the Area combo-box should be refreshed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewArea_FormClosed(object sender, FormClosedEventArgs e)
        {
            populateAreas();            
        }                
    }
}
