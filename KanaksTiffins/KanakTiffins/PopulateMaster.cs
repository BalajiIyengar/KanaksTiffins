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
            CommonUtilities.populateAreas(comboBox_areas);
            CommonUtilities.populateMealPlans(comboBox_mealPlans);
        }

          /// <summary>
          /// To add a new Area
          /// </summary>
          /// <param name="sender"></param>
          /// <param name="e"></param>
     
        private void button_addArea_Click(object sender, EventArgs e)
        {
           //Performing Validation
           if (textBox_area.Text.Length == 0)
            {
                MessageBox.Show("Cant Be Empty", "Error");
                return;
            }
            int textValue;
            if (Int32.TryParse(textBox_area.Text.Trim(), out textValue))
            {
                MessageBox.Show("Not a Valid Name", "Error");
                return;
            }
            if (db.Areas.Select(x => x.AreaName).Contains(textBox_area.Text))
            {
                MessageBox.Show("Already Exists.", "Error");
                return;
            }

            //Validation succeeded.

            int lastAreaId = db.Areas.Select(x => x.AreaId).Max();
            Area newArea = new Area();
            newArea.AreaId = lastAreaId + 1;
            newArea.AreaName = textBox_area.Text;

            db.Areas.AddObject(newArea);

            db.SaveChanges();
            MessageBox.Show("Added Successfully", "Success");

            //Refersh the Area combo-box.
            CommonUtilities.populateAreas(comboBox_areas);
        }

        /// <summary>
        /// To add a new MealPlan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_addMealPlan_Click(object sender, EventArgs e)
        {
            //Performing validation.
            if (textBox_mealPlan.Text.Length == 0)
            {
                MessageBox.Show("Cant Be Empty", "Error");
                return;
            }
            int textValue = 0;
            if (!Int32.TryParse(textBox_mealPlan.Text.Trim(), out textValue))
            {
                MessageBox.Show("Not a Valid Number", "Error");
                return;
            }
            if (Int32.Parse(textBox_mealPlan.Text) <= 0)
            {
                MessageBox.Show("Cant Be a Negative Number.", "Error");
                return;
            }
            if (db.MealPlans.Select(x => x.MealAmount).Contains(Int32.Parse(textBox_mealPlan.Text)))
            {
                MessageBox.Show("Already Exists.", "Error");
                return;
            }
            
            //Validation succeeded.

            int lastMealPlanId = db.MealPlans.Select(x => x.MealPlanId).Max();
            MealPlan newMealPlan = new MealPlan();
            newMealPlan.MealPlanId = lastMealPlanId + 1;
            newMealPlan.MealAmount = textBox_mealPlan.Text == "" ? 0 : Int32.Parse(textBox_mealPlan.Text);

            if (newMealPlan.MealAmount == 0)
            {
                MessageBox.Show("Cannot be 0", "Error");
                return;
            }
            db.MealPlans.AddObject(newMealPlan);

            db.SaveChanges();
            MessageBox.Show("Added Successfully", "Success");

            //Refresh the MealPlan combo-box.
            CommonUtilities.populateMealPlans(comboBox_mealPlans);
        }

        /// <summary>
        /// To Delete an Area
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_deleteArea_Click(object sender, EventArgs e)
        {
            Area selectedArea = comboBox_areas.SelectedItem as Area;

            //Check whether this AreaId has already been used anywhere.
            if (db.CustomerDetails.Select(x => x.AreaId).Contains(selectedArea.AreaId))
            {
                MessageBox.Show("Cannot delete this Area (" + selectedArea.AreaName + "). It is already being used by one/many customers. Please contact the developers for more information.", "Error");
                return;
            }

            //This area can be deleted.
            db.Areas.DeleteObject(selectedArea);
            db.SaveChanges();
            CommonUtilities.populateAreas(comboBox_areas);
            MessageBox.Show("Deleted Successfully", "Success");
        }

        /// <summary>
        /// To Delete a Mealplan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_deleteMealPlan_Click(object sender, EventArgs e)
        {
            MealPlan selectedMealPlan = comboBox_mealPlans.SelectedItem as MealPlan;

            //Check whether this MealPlanId has already been used anywhere.
            if (db.CustomerDetails.Select(x => x.MealPlanId).Contains(selectedMealPlan.MealPlanId))
            {
                MessageBox.Show("Cannot delete this Meal Plan (" + selectedMealPlan.MealAmount + "). It is already being used by one/many customers. Please contact the developers for more information.", "Error");
                return;
            }

            //This Meal Plan can be deleted.
            db.MealPlans.DeleteObject(selectedMealPlan);
            db.SaveChanges();
            CommonUtilities.populateMealPlans(comboBox_mealPlans);
            MessageBox.Show("Deleted Successfully", "Success");
        }
        /// <summary>
        /// On Change of an Area, rendering appropriate value on the textboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_areas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Area selectedArea = comboBox_areas.SelectedItem as Area;
            label_editArea.Text = "Change '"+ selectedArea.AreaName +"' to: ";
            button_deleteArea.Text = "Delete '" + selectedArea.AreaName + "'";
        }

        /// <summary>
        /// On Change of a MealPlan,rendering appropriate values on the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_mealPlans_SelectedIndexChanged(object sender, EventArgs e)
        {
            MealPlan selectedMealPlan = comboBox_mealPlans.SelectedItem as MealPlan;
            label_editMealPlan.Text = "Change '" + selectedMealPlan.MealAmount + "' to: ";
            button_deleteMealPlan.Text = "Delete '" + selectedMealPlan.MealAmount + "'";
        }
    }
}
