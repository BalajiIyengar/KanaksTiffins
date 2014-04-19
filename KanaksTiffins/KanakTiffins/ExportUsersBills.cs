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
    public partial class ExportUsersBills : Form
    {
        public Int32 selectedCustomerId;

        KanakTiffinsEntities db = CommonUtilities.db;

        public ExportUsersBills()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime startDate = DateTime.Parse(dateTimePicker_startDate.Text);
            DateTime endDate = DateTime.Parse(dateTimePicker_endDate.Text);

            List<MonthlyBill> monthlyBills = db.MonthlyBills.Where(x => x.CustomerId == selectedCustomerId && x.DateTaken >= startDate && x.DateTaken <= endDate).ToList();
            if (monthlyBills.Count == 0)
            {
                MessageBox.Show("No bills found.");
                return;
            }



            String path = CommonUtilities.getFileSaveLocation();

            //if user quits the dialog box
            if (path.Trim().Length == 0)
                return;


        }
    }
}
