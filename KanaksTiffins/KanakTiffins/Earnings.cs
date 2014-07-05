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
    public partial class Earnings : Form
    {
        KanakTiffinsEntities db = CommonUtilities.db;

        public Earnings()
        {
            InitializeComponent();
        }

        private void Earnings_Load(object sender, EventArgs e)
        {
            CommonUtilities.populateMonths(comboBox_fromMonth);
            CommonUtilities.populateMonths(comboBox_toMonth);

            CommonUtilities.populateYears(comboBox_fromYear);
            CommonUtilities.populateYears(comboBox_toYear);
        }

        private void button_fetchEarnings_Click(object sender, EventArgs e)
        {
            Month selectedToMonth = comboBox_toMonth.SelectedItem as Month;
            Month selectedFromMonth = comboBox_fromMonth.SelectedItem as Month;

            int fromYear = Int32.Parse(comboBox_fromYear.Text);
            int toYear = Int32.Parse(comboBox_toYear.Text);

            DateTime startDate = new DateTime(fromYear, selectedFromMonth.MonthId, 1);
            DateTime endDate = new DateTime(toYear, selectedToMonth.MonthId, DateTime.DaysInMonth(toYear,selectedToMonth.MonthId));

            int totalAmountPaid = 0;
            int totalDailyPayments = 0;
            int totalBillAmount = 0;
            int extraCharges = 0;

            /** Calculating Dabbawala and Delivery Charges */
            if (db.ExtraCharges.Where(x => x.MonthId >= selectedFromMonth.MonthId && x.MonthId <= selectedToMonth.MonthId && x.Year >= fromYear && x.Year <= toYear).Count() > 0)
                extraCharges = db.ExtraCharges.Where(x => x.MonthId >= selectedFromMonth.MonthId && x.MonthId <= selectedToMonth.MonthId && x.Year >= fromYear && x.Year <= toYear).Sum(x => x.DabbawalaCharges + x.DeliveryCharges);

            /** Calculating User Payments */
            if(db.CustomerPaymentHistories.Where(x => x.PaidOn >= startDate && x.PaidOn <= endDate).Count() > 0)
                totalAmountPaid = db.CustomerPaymentHistories.Where(x => x.PaidOn >= startDate && x.PaidOn <= endDate).Sum(x => x.PaidAmount);

            /** Calculating User Daily Payments */
            if (db.MonthlyBills.Where(x => x.DateTaken >= startDate && x.DateTaken <= endDate).Count() > 0)
                totalDailyPayments = db.MonthlyBills.Where(x => x.DateTaken >= startDate && x.DateTaken <= endDate).Sum(x => x.DailyPayment);


            int totalAmountReceived = totalAmountPaid + totalDailyPayments;
            
            /** Calculating Total Bill Charges incuding Lunch anbd Dinner Charges + Delivery and Dabbawala Charges */
            if(db.MonthlyBills.Where(x => x.DateTaken >= startDate && x.DateTaken <= endDate).Count() > 0)
                totalBillAmount = db.MonthlyBills.Where(x => x.DateTaken >= startDate && x.DateTaken <= endDate).Sum(x => x.LunchAmount + x.DinnerAmount) + extraCharges;

            int totalBalance = totalBillAmount - totalAmountReceived;

            textBox_totalBalance.Text = totalBalance.ToString();
            textBox_totalBills.Text = totalBillAmount.ToString();
            textBox_totalReceived.Text = totalAmountReceived.ToString();
        }
    }
}
