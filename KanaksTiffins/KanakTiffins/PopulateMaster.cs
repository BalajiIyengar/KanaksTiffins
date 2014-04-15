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
    public partial class PopulateMaster : Form
    {
        KanakTiffinsEntities db = CommonUtilities.db;

        public PopulateMaster()
        {
            InitializeComponent();
        }

        private void PopulateMaster_Load(object sender, EventArgs e)
        {
            loadAreas();
            loadMealPlans();
        }

        /// <summary>
        /// Used to populate the Area combo-box.
        /// </summary>
        private void loadAreas()
        {
            comboBox_areas.DataSource = db.Areas.OrderBy(x => x.AreaName).ToList();
            comboBox_areas.DisplayMember = "AreaName";
            comboBox_areas.ValueMember = "AreaName";
        }
        /// <summary>
        /// Used to populate the Meal Plan combo-box.
        /// </summary>
        private void loadMealPlans()
        {
            comboBox_mealPlans.DataSource = db.MealPlans.OrderBy(x => x.MealAmount).ToList();
            comboBox_mealPlans.DisplayMember = "MealAmount";
            comboBox_mealPlans.ValueMember = "MealPlanId";
        }
        
        private void button_addArea_Click(object sender, EventArgs e)
        {
           //Performing Validation
           if (textBox_area.Text.Length == 0)
            {
                MessageBox.Show("Cant Be Empty");
                return;
            }
            int textValue;
            if (Int32.TryParse(textBox_area.Text.Trim(), out textValue))
            {
                MessageBox.Show("Not a Valid Name");
                return;
            }
            if (db.Areas.Select(x => x.AreaName).Contains(textBox_area.Text))
            {
                MessageBox.Show("Already Exists.");
                return;
            }

            //Validation succeeded.

            int lastAreaId = db.Areas.Select(x => x.AreaId).Max();
            Area newArea = new Area();
            newArea.AreaId = lastAreaId + 1;
            newArea.AreaName = textBox_area.Text;

            db.Areas.AddObject(newArea);

            db.SaveChanges();
            MessageBox.Show("Added Successfully");

            //Refersh the Area combo-box.
            loadAreas();
        }

        private void button_addMealPlan_Click(object sender, EventArgs e)
        {
            //Performing validation.
            if (textBox_mealPlan.Text.Length == 0)
            {
                MessageBox.Show("Cant Be Empty");
                return;
            }
            int textValue = 0;
            if (!Int32.TryParse(textBox_mealPlan.Text.Trim(), out textValue))
            {
                MessageBox.Show("Not a Valid Number");
                return;
            }
            if (Int32.Parse(textBox_mealPlan.Text) <= 0)
            {
                MessageBox.Show("Cant Be a Negative Number.");
                return;
            }
            if (db.MealPlans.Select(x => x.MealAmount).Contains(Int32.Parse(textBox_mealPlan.Text)))
            {
                MessageBox.Show("Already Exists.");
                return;
            }
            
            //Validation succeeded.

            int lastMealPlanId = db.MealPlans.Select(x => x.MealPlanId).Max();
            MealPlan newMealPlan = new MealPlan();
            newMealPlan.MealPlanId = lastMealPlanId + 1;
            newMealPlan.MealAmount = textBox_mealPlan.Text == "" ? 0 : Int32.Parse(textBox_mealPlan.Text);

            if (newMealPlan.MealAmount == 0)
            {
                MessageBox.Show("Cannot be 0");
                return;
            }
            db.MealPlans.AddObject(newMealPlan);

            db.SaveChanges();
            MessageBox.Show("Added Successfully");

            //Refresh the MealPlan combo-box.
            loadMealPlans();
        }

        private void button_deleteArea_Click(object sender, EventArgs e)
        {
            Area selectedArea = comboBox_areas.SelectedItem as Area;

            //Check whether this AreaId has already been used anywhere.
            if (db.CustomerDetails.Select(x => x.AreaId).Contains(selectedArea.AreaId))
            {
                MessageBox.Show("Cannot delete this Area ("+selectedArea.AreaName+"). It is already being used by one/many customers. Please contact the developers for more information.");
                return;
            }

            //This area can be deleted.
            db.Areas.DeleteObject(selectedArea);
            db.SaveChanges();
            loadAreas();
            MessageBox.Show("Deleted Successfully");
        }

        private void button_deleteMealPlan_Click(object sender, EventArgs e)
        {
            MealPlan selectedMealPlan = comboBox_mealPlans.SelectedItem as MealPlan;

            //Check whether this MealPlanId has already been used anywhere.
            if (db.CustomerDetails.Select(x => x.MealPlanId).Contains(selectedMealPlan.MealPlanId))
            {
                MessageBox.Show("Cannot delete this Meal Plan ("+selectedMealPlan.MealAmount+"). It is already being used by one/many customers. Please contact the developers for more information.");
                return;
            }

            //This Meal Plan can be deleted.
            db.MealPlans.DeleteObject(selectedMealPlan);
            db.SaveChanges();
            loadMealPlans();
            MessageBox.Show("Deleted Successfully");
        }

        private void comboBox_areas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Area selectedArea = comboBox_areas.SelectedItem as Area;
            label_editArea.Text = "Change '"+ selectedArea.AreaName +"' to: ";
            button_deleteArea.Text = "Delete '" + selectedArea.AreaName + "'";
        }

        private void comboBox_mealPlans_SelectedIndexChanged(object sender, EventArgs e)
        {
            MealPlan selectedMealPlan = comboBox_mealPlans.SelectedItem as MealPlan;
            label_editMealPlan.Text = "Change '" + selectedMealPlan.MealAmount + "' to: ";
            button_deleteMealPlan.Text = "Delete '" + selectedMealPlan.MealAmount + "'";
        }
    }
}
