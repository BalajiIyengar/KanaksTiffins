using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;

namespace KanakTiffins
{
    public partial class UserDetail : Form
    {
        //CustomerId of the Customer whose details are being displayed.
        static Int32 customerId;

        //Calendar for the current month.
        MonthCalendar calendar = new MonthCalendar();

        KanakTiffinsEntities db = CommonUtilities.db;
           
        public UserDetail()
        {
            InitializeComponent();
        }

        private void UserDetail_Load(object sender, EventArgs e)
        {
            CustomerDetail customerDetail = null;

            try
            {
                customerDetail = db.CustomerDetails.Where(x => x.CustomerId == customerId && x.isDeleted.Equals("N")).Single();
            }
            catch (Exception ex)
            {
                MessageBox.Show("User not found. He/She may have been deleted.", "Error");
                this.Close();
                return;
            }

            //Set values of all textboxes
            groupBox_userDetails.Text = customerDetail.FirstName + " " + customerDetail.LastName;
            textBox_address.Text = customerDetail.Address;
            textBox_email.Text = customerDetail.EmailAddress;
            textBox_area.Text = customerDetail.Area.AreaName;
            textBox_phone.Text = customerDetail.PhoneNumber;
            textBox_mealPlan.Text = customerDetail.MealPlan.MealAmount.ToString();
            textBox_lunchOrDinner.Text = customerDetail.LunchOrDinner.Name;
            textBox_deliveryCharges.Text = customerDetail.DefaultDabbawalaCharges.ToString();
            textBox_initialBalance.Text = "Rs. " + customerDetail.InitialBalance.ToString();

            //Populate the year combo box
            List<int> years = new List<int>();            
            for (int year = 2012; year <= calendar.TodayDate.Year; year++)
            {
                years.Add(year);
            }
            comboBox_year.DataSource = years;
            comboBox_year.SelectedItem = calendar.TodayDate.Year;

            //Prepare the Monthly Bills of this user, in order to view them in the panel.
            displayBillForYear(calendar.TodayDate.Year);

            //Display users balance and carryforward amount
            long dueAmount = 0;
            long carryforwardAmount = 0;
            try
            {
                dueAmount = db.CustomerDues.Where(x => x.CustomerId == customerId).Select(x => x.DueAmount).FirstOrDefault();
                carryforwardAmount = db.CustomerDues.Where(x => x.CustomerId == customerId).Select(x => x.CarryforwardAmount).FirstOrDefault();
                
                label_dueAmount.Text = dueAmount.ToString();
                label_carryForwardAmount.Text = carryforwardAmount.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }            
        }

        void thisMonthsBill_Scroll(object sender, ScrollEventArgs e)
        {
            flowLayoutPanel1.PerformLayout();
        }

        internal static void setCustomerId(int selectedCustomerId)
        {
            customerId = selectedCustomerId;
        }

        /// <summary>
        /// Displays the user's bill history
        /// </summary>
        /// <param name="year"></param>
        private void displayBillForYear(int year)
        {
            flowLayoutPanel1.Controls.Clear();

            DateTime firstDayOfYear = new DateTime(year, 1, 1);
            DateTime lastDayOfYear = new DateTime(year, 12, 31);

            //Retrieve ALL bills from MonthlyBills table, for this user.
            List<MonthlyBill> billsforThisUser = db.MonthlyBills.Where(x => x.CustomerId == customerId && x.DateTaken >= firstDayOfYear && x.DateTaken <= lastDayOfYear).ToList();
           
            if (billsforThisUser.Count == 0) //If no bill found, don't proceed.
                return;

            //Custom Controls, which will be constructed at runtime.
            List<MonthlyBillCustomControl> monthlyBillControls = new List<MonthlyBillCustomControl>();

            //Each month's bill in a year.
            for (int month = 1; month <= 12; month++)
            {
                DateTime firstDayOfMonth = new DateTime(year, month, 1);
                DateTime lastDayOfMonth = new DateTime(year, month, DateTime.DaysInMonth(year, month));

                MonthlyBillCustomControl thisMonthsBill = new MonthlyBillCustomControl();
                Label monthLabel = thisMonthsBill.Controls["label_month"] as Label;
                monthLabel.Text = firstDayOfMonth.ToShortDateString() + " - " + lastDayOfMonth.ToShortDateString();
                
                DataGridView monthlyBillGridView = thisMonthsBill.Controls["dataGridView_monthlyBill"] as DataGridView;
                
                List<MonthlyBill> thisMonth = billsforThisUser.Where(x => x.DateTaken >= firstDayOfMonth && x.DateTaken <= lastDayOfMonth).ToList();
                if (thisMonth.Count == 0) //If no bill for this month, go to the next month.
                    continue;               

                monthlyBillGridView.DataSource = thisMonth;
                monthlyBillGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                monthlyBillGridView.Columns["CustomerId"].Visible = false;
                monthlyBillGridView.Columns["CustomerDetail"].Visible = false;

                //Change the HeaderText for some columns to make them more understandable.
                monthlyBillGridView.Columns["DateTaken"].HeaderText = "Date Taken";
                monthlyBillGridView.Columns["DateTaken"].DefaultCellStyle.Format = "dd-MMM-yy";
                monthlyBillGridView.Columns["LunchAmount"].HeaderText = "Lunch";
                monthlyBillGridView.Columns["DinnerAmount"].HeaderText = "Dinner";
                monthlyBillGridView.Columns["DailyPayment"].HeaderText = "Daily Payments";
                
                highlightWeekends(thisMonth, monthlyBillGridView); //NOT WORKING - BALA PLEASE CHECK!

                //Set the values for the different variables on the Custom Control.
                Label monthlyConsumptionLabel = thisMonthsBill.Controls["label_monthlyConsumption"] as Label;
                monthlyConsumptionLabel.Text = thisMonth.Sum(x => x.LunchAmount + x.DinnerAmount).ToString();
                Label dailyPayments = thisMonthsBill.Controls["label_dailyPayments"] as Label;
                dailyPayments.Text = thisMonth.Sum(x => x.DailyPayment).ToString();                
                Label dabbawalaCharges = thisMonthsBill.Controls["label_dabbawalaCharges"] as Label;
                dabbawalaCharges.Text = db.ExtraCharges.Where(x => x.CustomerId == customerId && x.MonthId == month && x.Year == year).Single().DabbawalaCharges.ToString();
                Label deliveryCharges = thisMonthsBill.Controls["label_deliveryCharges"] as Label;
                deliveryCharges.Text = db.ExtraCharges.Where(x => x.CustomerId == customerId && x.MonthId == month && x.Year == year).Single().DeliveryCharges.ToString();
                Label payableAmount = thisMonthsBill.Controls["label_payableAmount"] as Label;
                payableAmount.Text = (Int32.Parse(monthlyConsumptionLabel.Text) + Int32.Parse(dabbawalaCharges.Text) + Int32.Parse(deliveryCharges.Text) - Int32.Parse(dailyPayments.Text)).ToString();

                thisMonthsBill.Scroll += new ScrollEventHandler(thisMonthsBill_Scroll);
                flowLayoutPanel1.Controls.Add(thisMonthsBill);
            }            
        }

        /// <summary>
        /// Highlights the Weekends - Yellow for Saturdays and Red for Sundays.
        /// </summary>
        /// <param name="thisMonthsBill"></param>
        /// <param name="dataGridView_billForThisMonth"></param>
        private void highlightWeekends(List<MonthlyBill> thisMonthsBill, DataGridView dataGridView_billForThisMonth)
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

        private void button_showBills_Click(object sender, EventArgs e)
        {
            displayBillForYear(Int32.Parse(comboBox_year.SelectedItem.ToString()));
        }

        /// <summary>
        /// Redirecting to AddNewUser form with values of this user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_editUser_Click(object sender, EventArgs e)
        {
            //If this user has been deleted in another window, display error message.
            CustomerDetail selectedCustomer = db.CustomerDetails.Where(x => x.CustomerId == customerId && x.isDeleted.Equals("N")).FirstOrDefault();
            if (selectedCustomer == null)
            {
                MessageBox.Show("User not found. He/She may have been deleted.", "Error");
                this.Close();
                return;
            }

            
            AddNewUser editUser = new AddNewUser();
            editUser.Controls["textBox_currentBalance"].Enabled = false;
            editUser.Show();
            editUser.fillFormWithValues(customerId);            
        }

        /// <summary>
        /// On Click of delete user button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void button_deleteUser_Click(object sender, EventArgs e)
        {
            //If this user has been deleted in another window, display error message.
            CustomerDetail selectedCustomer = db.CustomerDetails.Where(x => x.CustomerId == customerId && x.isDeleted.Equals("N")).FirstOrDefault();
            if (selectedCustomer == null)
            {
                MessageBox.Show("User not found. He/She may have been deleted.", "Error");
                this.Close();
                return;
            }

            DialogResult result = MessageBox.Show("Are you Sure?", "Delete User", MessageBoxButtons.YesNo);
          
            if (result == DialogResult.Yes)
            {
                try
                {                    
                    db.CustomerDetails.Where(x => x.CustomerId == customerId && x.isDeleted.Equals("N")).FirstOrDefault().isDeleted = "Y";
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.StackTrace);
                }
                MessageBox.Show("User deleted successfully.", "Success");
                this.Close();
            }
        }

        /// <summary>
        /// When the View Payment History link label is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel_paymentHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PaymentHistory paymentHistory = new PaymentHistory(customerId);
            paymentHistory.Show();
        }
    }
}
