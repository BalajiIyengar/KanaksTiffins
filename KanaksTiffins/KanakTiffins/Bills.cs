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

namespace KanakTiffins
{
    public partial class Bills : Form
    {
        KanakTiffinsEntities db = new KanakTiffinsEntities();
        
        MonthCalendar currentMonth = new MonthCalendar(); 

        //CustomerId whose bill is being shown
        int selectedCustomerId;

        public Bills()
        {
            selectedCustomerId = db.CustomerDetails.First().CustomerId;
            InitializeComponent();
        }

        private void Bills_Load(object sender, EventArgs e)
        {     
            // Populates the area combo box   
            List<Area> areas = new List<Area>();
            areas.Add(new Area());
            areas.AddRange(db.Areas.ToList());
            comboBox_area.DataSource = areas;
            comboBox_area.DisplayMember = "AreaName";
            comboBox_area.ValueMember = "AreaName";
            
            //Populate the month combo box
            List<String> months = new List<string>() { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
            comboBox_month.DataSource = months;            
            comboBox_month.SelectedIndex = currentMonth.TodayDate.Month-1; //Combo box index starts from 0

            //Populate the year combo box
            List<int> years = new List<int>();
            for (int year = 2012; year <= currentMonth.TodayDate.Year; year++)
            {
                years.Add(year);
            }
            comboBox_year.DataSource = years;
            comboBox_year.SelectedItem = currentMonth.TodayDate.Year;
                        
            //int[] years = new int[14];
            //int startYear = 2012;
            //for (int year = 0; year < years.Count(); year++)
            //{
            //    years[year] = startYear++;
            //}
            //comboBox_year.DataSource = years;
            //comboBox_year.SelectedItem = currentMonth.TodayDate.Year;
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            //Disable the Monthly Bill gridview which is disabled by default
            groupBox_monthlyBill.Enabled = false;
            dataGridView_billForThisMonth.Visible = false;

            //Get hold of UI elements
            String firstName = textBox_firstName.Text.ToLower();
            String lastName = textBox_lastName.Text.ToLower();
            String areaName = comboBox_area.SelectedValue == null ? "" : comboBox_area.SelectedValue.ToString();

            //Query for retrieving users from the DB
            var users = db.CustomerDetails.Where(x => x.FirstName.Contains(firstName) && x.LastName.Contains(lastName) && x.Area.AreaName.Contains(areaName))
                                        .Select(x => new { x.CustomerId, x.FirstName, x.LastName, x.Address, x.PhoneNumber, x.Area.AreaName });           
            dataGridView_users.DataSource = users.ToList();           

            dataGridView_users.Columns["CustomerId"].Visible = false;

            dataGridView_users.CellClick -= monthlyBillOfThisUser;
            dataGridView_users.CellClick += monthlyBillOfThisUser;
        }

        private void monthlyBillOfThisUser(object sender, DataGridViewCellEventArgs e)
        {
            //Enable the Monthly Bill gridview which is disabled by default
            groupBox_monthlyBill.Enabled = true;
            dataGridView_billForThisMonth.Visible = true;

            //Getting the value of clicked row
            DataGridView button = sender as DataGridView;
            DataGridViewCellCollection selectedUser = button.CurrentRow.Cells as DataGridViewCellCollection;

            //Returns the selected customer ID
            selectedCustomerId = Int32.Parse(selectedUser[0].Value.ToString());  
           
            int month = currentMonth.TodayDate.Month;
            int year = currentMonth.TodayDate.Year;
            int noOfDays = DateTime.DaysInMonth(year, month);

            String monthName = DateTime.Now.ToString("MMMM");

            DateTime startDate = new DateTime(year, month, 1);
            DateTime endDate = new DateTime(year, month, noOfDays);           

            //Initialize Month to current month in combo box
            comboBox_month.SelectedIndex = currentMonth.TodayDate.Month - 1; //Combo box index starts from 0

            createMonthlyBill(startDate, endDate);       
        }

        private void createMonthlyBill(DateTime startDate, DateTime endDate)
        {
            List<MonthlyBill> thisMonthsBill = retrieveThisUsersBill(startDate, endDate);

            MonthlyBill monthlyBill;

            int month = startDate.Month;
            int year = startDate.Year;
            int noOfDays = DateTime.DaysInMonth(year, month);

            //If no records found in the DB, then fill entries manually, according to meal plan.
            if (thisMonthsBill.Count() == 0)
            {
                label_billNotGenerated.Visible = true;

                for (int dayNumber = 1; dayNumber <= noOfDays; dayNumber++)
                {
                    monthlyBill = new MonthlyBill();
                    monthlyBill.DateTaken = new DateTime(year, month, dayNumber);
                    monthlyBill.CustomerId = selectedCustomerId;

                    //Lunch and Dinner initialized to 0 for sundays and saturdays
                    if (monthlyBill.DateTaken.DayOfWeek.Equals(DayOfWeek.Sunday) || monthlyBill.DateTaken.DayOfWeek.Equals(DayOfWeek.Saturday))
                    {
                        monthlyBill.LunchAmount = 0;
                        monthlyBill.DinnerAmount = 0;
                    }
                    else
                    {
                        int lunchOrDinnerId = db.CustomerDetails.Where(x => x.CustomerId == selectedCustomerId).FirstOrDefault().LunchOrDinnerId;
                        int mealAmount = db.CustomerDetails.Where(x => x.CustomerId == selectedCustomerId).First().MealPlan.MealAmount;

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
                    //Set Dabbawala charges 
                    int monthId = comboBox_month.SelectedIndex + 1;
                    int year = Int32.Parse(comboBox_year.SelectedItem.ToString());
                    int dabbawalaCharges = db.CustomerDetails.Where(x => x.CustomerId == selectedCustomerId).FirstOrDefault().DabbawalaCharges;
                    textBox_dabbawalaCharges.Text = dabbawalaCharges.ToString();
                }
                catch (Exception ex)
                {
                    textBox_dabbawalaCharges.Text = "";  
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

        //Add New User Link Clicked
        private void linkLabel_addNewUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddNewUser addNewUser = new AddNewUser();            
            addNewUser.Show();
        }

        //Search Users Link Clicked
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
            saveButtonClicked();
            
            //update CustomerDues table
            updateCustomerDues();
        }

        private void saveButtonClicked()
        {
            try
            {
                Hashtable dates = getCurrentMonthDates();
                List<MonthlyBill> billForSelectedMonth = retrieveThisUsersBill(DateTime.Parse(dates["startDate"].ToString()), DateTime.Parse(dates["endDate"].ToString()));

                if (billForSelectedMonth.Count == 0)
                {
                    foreach (MonthlyBill thisDate in dataGridView_billForThisMonth.DataSource as List<MonthlyBill>)
                    {
                        db.MonthlyBills.AddObject(thisDate);
                    }
                }

                db.CustomerDetails.Where(x => x.CustomerId == selectedCustomerId).First().DabbawalaCharges = Int32.Parse(textBox_dabbawalaCharges.Text) ;

                db.SaveChanges();
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

        private void billForSelectedMonthAndYear()
        {
            Hashtable dates = getCurrentMonthDates();
            label_billNotGenerated.Visible = false;

            //List<MonthlyBill> billForSelectedMonth = retrieveThisUsersBill();

            //dataGridView_billForThisMonth.EditMode = DataGridViewEditMode.EditOnEnter;
            //dataGridView_billForThisMonth.DataSource = billForSelectedMonth;

            //modifyDataGridView();

            createMonthlyBill(DateTime.Parse(dates["startDate"].ToString()), DateTime.Parse(dates["endDate"].ToString()));
        }

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

        private List<MonthlyBill> retrieveThisUsersBill(DateTime startDate, DateTime endDate)
        {
            List<MonthlyBill> billForSelectedMonth = db.MonthlyBills.Where(x => x.CustomerId == selectedCustomerId && (x.DateTaken >= startDate && x.DateTaken <= endDate)).ToList();
            return billForSelectedMonth;
        }

        private void button_generateBill_Click(object sender, EventArgs e)
        {
            //Entries for this month should be in the database before generating bill
            saveButtonClicked();           
            
            //update CustomerDues table
            updateCustomerDues();

            //GENERATE A DOCUMENT TO PRINT.

            MessageBox.Show("Generated bill successfully");
        }

        private void updateCustomerDues()
        {
            Int32 totalPayableAmount;
            try
            {
                totalPayableAmount = db.MonthlyBills.Where(x => x.CustomerId == selectedCustomerId).Sum(x => x.LunchAmount + x.DinnerAmount - x.DailyPayment);
            }
            catch (Exception ex)
            {
                totalPayableAmount = 0;
            }

            Int32 totalPaidAmount;
            try
            {
                totalPaidAmount = db.CustomerPaymentHistories.Where(x => x.CustomerId == selectedCustomerId).Sum(x => x.PaidAmount);
            }
            catch (Exception ex)
            {
                totalPaidAmount = 0;
            }          

            Int32 totalDueAmount = totalPayableAmount - totalPaidAmount;

            //Put values in CustomerDues tables
            CustomerDue updatedDues = db.CustomerDues.Where(x => x.CustomerId == selectedCustomerId).FirstOrDefault();

            if (updatedDues == null)
                updatedDues = new CustomerDue();

            updatedDues.CustomerId = selectedCustomerId;
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

            if (db.CustomerDues.Where(x => x.CustomerId == selectedCustomerId).Count() == 0)
            {
                db.CustomerDues.AddObject(updatedDues);
            }

            db.SaveChanges();
        }

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
    }
}
