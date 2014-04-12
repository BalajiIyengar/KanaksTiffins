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
    public partial class SearchUsers : Form
    {
        KanakTiffinsEntities db = new KanakTiffinsEntities();
        MonthCalendar currentMonth = new MonthCalendar();
        List<CustomerDetail> searchResults = new List<CustomerDetail>();
        public SearchUsers()
        {
            InitializeComponent();
        }

        //Search By User Details Clicked
        private void button_Search_UserDetails_Click(object sender, EventArgs e)
        {
            String firstName = textBox_firstName.Text.ToLower();
            String lastName = textBox_lastName.Text.ToLower();
            String areaName = comboBox_Area.SelectedValue == null ? "" : comboBox_Area.SelectedValue.ToString();            

            //Search Result (List of usernames)
            searchResults = db.CustomerDetails.Where(x => x.FirstName.Contains(firstName) && 
                                                                           x.LastName.Contains(lastName) &&
                                                                           x.Area.AreaName.Contains(areaName)
                                                                     ).ToList();
            dataGridView_searchResult.DataSource = searchResults.ToList();

            modifyDataGridView();
        }

        private void modifyDataGridView()
        {
            try
            {
                //Hide extraneous columns
                dataGridView_searchResult.Columns["CustomerId"].Visible = false;
                dataGridView_searchResult.Columns["Area"].Visible = false;
                dataGridView_searchResult.Columns["AreaId"].Visible = false;
                dataGridView_searchResult.Columns["MealPlan"].Visible = false;
                dataGridView_searchResult.Columns["MealPlanId"].Visible = false;
                dataGridView_searchResult.Columns["LunchOrDinner"].Visible = false;
                dataGridView_searchResult.Columns["LunchOrDinnerId"].Visible = false;

                if (dataGridView_searchResult.Columns.Contains("MonthlyBills")) 
                    dataGridView_searchResult.Columns["MonthlyBills"].Visible = false;

                if (dataGridView_searchResult.Columns.Contains("CustomerPaymentHistories")) 
                    dataGridView_searchResult.Columns["CustomerPaymentHistories"].Visible = false;

                if (dataGridView_searchResult.Columns.Contains("CustomerDue")) 
                    dataGridView_searchResult.Columns["CustomerDue"].Visible = false;

                //Add Area Name as a column
                if (dataGridView_searchResult.Columns["AreaName"] == null)
                {
                    dataGridView_searchResult.Columns.Add("AreaName", "AreaName");
                }

                //Populate the AreaName column
                foreach (DataGridViewRow row in dataGridView_searchResult.Rows)
                {
                    CustomerDetail customer = row.DataBoundItem as CustomerDetail;
                    row.Cells["AreaName"].Value = customer.Area.AreaName;
                }

                dataGridView_searchResult.CellClick -= userDetails;
                dataGridView_searchResult.CellClick += userDetails;
            }
            catch (Exception e)
            { MessageBox.Show(e.StackTrace); Console.WriteLine(e.StackTrace); }           
        }

        private void userDetails(object sender, DataGridViewCellEventArgs e)
        {
            //Getting the value of clicked row
            DataGridView button = sender as DataGridView;
            DataGridViewCellCollection selectedUser = button.CurrentRow.Cells as DataGridViewCellCollection;

            //Returns the selected customer ID
            int selectedCustomerId = Int32.Parse(selectedUser["CustomerId"].Value.ToString());

            UserDetail.setCustomerId(selectedCustomerId);

            UserDetail userDetail = new UserDetail();
            userDetail.Show();            
        }

        /* Search By Meal Plan Clicked */
        private void button_Search_MealPlan_Click(object sender, EventArgs e)
        {             
            int mealPlanId = comboBox_mealAmount.SelectedValue == null ? 0 : Int32.Parse(comboBox_mealAmount.SelectedValue.ToString());
            int lunchOrDinnerId = comboBox_lunchOrDinner.SelectedValue == null ? 0 : Int32.Parse(comboBox_lunchOrDinner.SelectedValue.ToString());     

            searchResults = db.CustomerDetails.Where(x=>x.MealPlanId==mealPlanId && x.LunchOrDinnerId==lunchOrDinnerId).ToList();

            dataGridView_searchResult.DataSource = searchResults.ToList();

            modifyDataGridView();
        }

        //Loading Search Users
        private void SearchUsers_Load(object sender, EventArgs e)
        {
            //Populate area dropdown
            List<Area> areas = new List<Area>();
            Area blankAreaValue = new Area();
            blankAreaValue.AreaId = -1;
            areas.Add(blankAreaValue);
            areas.AddRange(db.Areas.ToList());
            comboBox_Area.DataSource = areas;            
            comboBox_Area.DisplayMember = "AreaName";
            comboBox_Area.ValueMember = "AreaName";

            //Populate Meal Amount combo box
            List<MealPlan> mealPlans = new List<MealPlan>(); 
            mealPlans.AddRange(db.MealPlans.ToList());
            comboBox_mealAmount.DataSource = mealPlans;
            comboBox_mealAmount.DisplayMember = "MealAmount";
            comboBox_mealAmount.ValueMember = "MealPlanId";            

            //Populate Lunch/Dinner combo box
            List<LunchOrDinner> lunchOrDinner = new List<LunchOrDinner>();             
            lunchOrDinner.AddRange(db.LunchOrDinners.ToList());
            comboBox_lunchOrDinner.DataSource = lunchOrDinner;
            comboBox_lunchOrDinner.DisplayMember = "Name";
            comboBox_lunchOrDinner.ValueMember = "Id";
        }        
    }
}
