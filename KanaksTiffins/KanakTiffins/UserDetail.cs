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
        static Int32 customerId;
        MonthCalendar calendar = new MonthCalendar();

        KanakTiffinsEntities db = new KanakTiffinsEntities();

        public UserDetail()
        {
            InitializeComponent();
        }


        
        

        private void UserDetail_Load(object sender, EventArgs e)
        {

            CustomerDetail customerDetail = db.CustomerDetails.Where(x => x.CustomerId == customerId).Single();

            //Set values of all textboxes
            groupBox_userDetails.Text = customerDetail.FirstName + " " + customerDetail.LastName;
            textBox_address.Text = customerDetail.Address;
            textBox_email.Text = customerDetail.EmailAddress;
            textBox_area.Text = customerDetail.Area.AreaName;
            textBox_phone.Text = customerDetail.PhoneNumber;
            textBox_mealPlan.Text = customerDetail.MealPlan.MealAmount.ToString();
            textBox_lunchOrDinner.Text = customerDetail.LunchOrDinner.Name;
            textBox_deliveryCharges.Text = customerDetail.DabbawalaCharges.ToString();

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
            {}            
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
            List<MonthlyBill> billsforThisUser = db.MonthlyBills.Where(x => x.CustomerId == customerId && x.DateTaken >= firstDayOfYear && x.DateTaken <= lastDayOfYear).ToList();
            if (billsforThisUser.Count == 0)
                return;
            List<MonthlyBillCustomControl> monthlyBillControls = new List<MonthlyBillCustomControl>();
            for (int month = 1; month <= 12; month++)
            {
                DateTime firstDayOfMonth = new DateTime(year, month, 1);
                DateTime lastDayOfMonth = new DateTime(year, month, DateTime.DaysInMonth(year, month));

                MonthlyBillCustomControl thisMonthsBill = new MonthlyBillCustomControl();
                Label monthLabel = thisMonthsBill.Controls["label_month"] as Label;
                monthLabel.Text = firstDayOfMonth.ToShortDateString() + " - " + lastDayOfMonth.ToShortDateString();
                DataGridView monthlyBillGridView = thisMonthsBill.Controls["dataGridView_monthlyBill"] as DataGridView;
                List<MonthlyBill> thisMonth = billsforThisUser.Where(x => x.DateTaken >= firstDayOfMonth && x.DateTaken <= lastDayOfMonth).ToList();
                if (thisMonth.Count == 0)
                    continue;               

                monthlyBillGridView.DataSource = thisMonth;
                monthlyBillGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                monthlyBillGridView.Columns["CustomerId"].Visible = false;
                monthlyBillGridView.Columns["CustomerDetail"].Visible = false;                

                highlightWeekends(thisMonth, monthlyBillGridView);

                Label monthlyConsumptionLabel = thisMonthsBill.Controls["label_monthlyConsumption"] as Label;
                monthlyConsumptionLabel.Text = thisMonth.Sum(x => x.LunchAmount + x.DinnerAmount).ToString();
                Label dailyPayments = thisMonthsBill.Controls["label_dailyPayments"] as Label;
                dailyPayments.Text = thisMonth.Sum(x => x.DailyPayment).ToString();
                Label payableAmount = thisMonthsBill.Controls["label_payableAmount"] as Label;
                payableAmount.Text = (Int32.Parse(monthlyConsumptionLabel.Text) - Int32.Parse(dailyPayments.Text)).ToString();

                thisMonthsBill.Scroll += new ScrollEventHandler(thisMonthsBill_Scroll);
                flowLayoutPanel1.Controls.Add(thisMonthsBill);
            }            
        }

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
            AddNewUser editUser = new AddNewUser();
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
             DialogResult result = MessageBox.Show("Are you Sure?", "Delete User", MessageBoxButtons.YesNo);
          

          // DbTransaction transaction = db.Connection.BeginTransaction();

            if (result == DialogResult.Yes)
            {
                //Transaction to be included
                
                    try
                    {

                        db.CustomerDues.DeleteObject(db.CustomerDues.Where(x => x.CustomerId == customerId).FirstOrDefault());
                        db.MonthlyBills.DeleteObject(db.MonthlyBills.Where(x => x.CustomerId == customerId).FirstOrDefault());
                        db.CustomerPaymentHistories.DeleteObject(db.CustomerPaymentHistories.Where(x => x.CustomerId == customerId).FirstOrDefault());
                        db.CustomerDetails.DeleteObject(db.CustomerDetails.Where(x => x.CustomerId == customerId).FirstOrDefault());

                        db.SaveChanges();
                     //   transaction.Commit();

                    }
                    catch (Exception ex)
                    {
                      //  transaction.Rollback();
                        Console.Write(ex.StackTrace);
                    }
            }
        }
    
    }

}
