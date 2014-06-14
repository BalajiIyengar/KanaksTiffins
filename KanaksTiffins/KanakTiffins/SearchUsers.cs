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
        KanakTiffinsEntities db = CommonUtilities.db;
        MonthCalendar currentMonth = new MonthCalendar();
        List<CustomerDetail> searchResults = new List<CustomerDetail>();
        public SearchUsers()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Search based on user's details.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Search_UserDetails_Click(object sender, EventArgs e)
        {
            String firstName = textBox_firstName.Text.ToLower();
            String lastName = textBox_lastName.Text.ToLower();
            String areaName = comboBox_Area.SelectedValue == null ? "" : comboBox_Area.SelectedValue.ToString();
            int enteredBalance = 0;
            int dummyInt = 0;

            if (textBox_balance.Text.Trim().Length != 0)
            {
                if (!Int32.TryParse(textBox_balance.Text.ToString(), out dummyInt))
                {
                    MessageBox.Show("Please Enter a valid Number", "Error");
                    return;
                }
                enteredBalance = Int32.Parse(textBox_balance.Text.Trim());
            }
            //Search Result (List of usernames)
            searchResults = CommonUtilities.getSearchResults(firstName, lastName, areaName, enteredBalance);
            dataGridView_searchResult.DataSource = searchResults;

            modifyDataGridView();
        }

        /// <summary>
        /// Hides/Adds extraneous/required columns from/to the DataGridView.
        /// </summary>
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
                dataGridView_searchResult.Columns["IsDeleted"].Visible = false;

                if (dataGridView_searchResult.Columns.Contains("ExtraCharges"))
                    dataGridView_searchResult.Columns["ExtraCharges"].Visible = false;

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
            { MessageBox.Show(e.StackTrace, "Error"); Console.WriteLine(e.StackTrace); }           
        }

        /// <summary>
        /// Called when a cell in the DataGridView (which is displaying search results) is clicked. It is used to open the UserDetail form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userDetails(object sender, DataGridViewCellEventArgs e)
        {
            //Getting the value of clicked row
            DataGridView button = sender as DataGridView;
            DataGridViewCellCollection selectedUser = button.CurrentRow.Cells as DataGridViewCellCollection;

            //Returns the selected customer ID
            int selectedCustomerId = Int32.Parse(selectedUser["CustomerId"].Value.ToString());

            UserDetail.setCustomerId(selectedCustomerId);

            //If this user has been deleted in another window, display error message.
            CustomerDetail selectedCustomer = db.CustomerDetails.Where(x => x.CustomerId == selectedCustomerId && x.isDeleted.Equals("N")).FirstOrDefault();
            if (selectedCustomer == null)
            {
                MessageBox.Show("User not found. He/She may have been deleted.", "Error");                
                return;
            }

            //Invoke the UserDetails form.
            UserDetail userDetail = new UserDetail();
            userDetail.Show();            
        }

       /// <summary>
       /// Perform a search based on Meal Plans.
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void button_Search_MealPlan_Click(object sender, EventArgs e)
        {             
            int mealPlanId = comboBox_mealAmount.SelectedValue == null ? 0 : Int32.Parse(comboBox_mealAmount.SelectedValue.ToString());
            int lunchOrDinnerId = comboBox_lunchOrDinner.SelectedValue == null ? 0 : Int32.Parse(comboBox_lunchOrDinner.SelectedValue.ToString());

            searchResults = db.CustomerDetails.Where(x => x.MealPlanId == mealPlanId && x.LunchOrDinnerId == lunchOrDinnerId && x.isDeleted.Equals("N")).OrderBy(x => x.FirstName).ToList();

            dataGridView_searchResult.DataSource = searchResults.ToList();

            modifyDataGridView();
        }
                
        private void SearchUsers_Load(object sender, EventArgs e)
        {
            //Populate area dropdown
           populateAreas();

            //Populate Meal Amount combo box
           CommonUtilities.populateMealPlans(comboBox_mealAmount);            

            //Populate Lunch/Dinner combo box
           CommonUtilities.populateLunchOrDinner(comboBox_lunchOrDinner);
        }

        /// <summary>
        /// Populates the Area combo-box.
        /// </summary>
        private void populateAreas()
        {
            List<Area> areas = new List<Area>();
            Area blankAreaValue = new Area();
            blankAreaValue.AreaId = -1;
            areas.Add(blankAreaValue);
            areas.AddRange(db.Areas.ToList());
            comboBox_Area.DataSource = areas;
            comboBox_Area.DisplayMember = "AreaName";
            comboBox_Area.ValueMember = "AreaName";
        }

        /// <summary>
        /// To reload area masters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_refreshUserDetails_Click(object sender, EventArgs e)
        {
            CommonUtilities.populateAreas(comboBox_Area);
        }

        /// <summary>
        /// To reload meal plan masters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_refreshMealPlan_Click(object sender, EventArgs e)
        {
            CommonUtilities.populateMealPlans(comboBox_mealAmount);
        }
    }
}
