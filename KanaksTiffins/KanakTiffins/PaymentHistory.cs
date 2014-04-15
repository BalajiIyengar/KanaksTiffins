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
    public partial class PaymentHistory : Form
    {
        Int32 selectedCustomerId;

        KanakTiffinsEntities db = CommonUtilities.db;

        public PaymentHistory()
        {
            InitializeComponent();
        }

        public PaymentHistory(int selectedCustomerId)
        {
            this.selectedCustomerId = selectedCustomerId;
            InitializeComponent();
        }

        private void PaymentHistory_Load(object sender, EventArgs e)
        {
            dataGridView_paymentHistory.DataSource = db.CustomerPaymentHistories.Where(x => x.CustomerId == selectedCustomerId).ToList();

            //Hide extraneous columns
            dataGridView_paymentHistory.Columns["CustomerDetail"].Visible = false;
            dataGridView_paymentHistory.Columns["CustomerId"].Visible = false;
        }
    }
}
