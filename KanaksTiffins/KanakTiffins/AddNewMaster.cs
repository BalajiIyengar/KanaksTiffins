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
    /// <summary>
    /// This Form is used as a shorcut to add new values into the Master tables (Area/MealPlan). There are linklabels near
    /// Area and MealPlan combo-boxes, throughout the project. On clicking such linklabels, this form is invoked.
    /// </summary>
    public partial class AddNewMaster : Form
    {        
        KanakTiffinsEntities db = CommonUtilities.db;
        
        /// <summary>
        /// //This form is used for adding values into both Area and MealPlan master tables. this String helps differentiate between the two.
        /// </summary>
        public String clickedLinkName;
        
        public AddNewMaster()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The Submit button was clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_addNewArea_Click(object sender, EventArgs e)
        {
            //If the linklabel which led us to this form was for adding a new value for the Area master table.
            if (clickedLinkName.Contains("Area"))
            {
                //Validation
                if (textBox_addNewMaster.Text.Length == 0 )
                {
                    MessageBox.Show("Please enter a value.", "Error");
                    return;
                }
                int textValue;
                if (Int32.TryParse(textBox_addNewMaster.Text.Trim(), out textValue))
                {
                    MessageBox.Show("Please enter a valid value.", "Error");
                    return;
                }
                if (db.Areas.Select(x => x.AreaName).Contains(textBox_addNewMaster.Text))
                {
                    MessageBox.Show("This value already exists.", "Error");
                    return;
                }

                int areaId = 0;

                if (db.Areas.Count() != 0)
                areaId = db.Areas.Select(x => x.AreaId).Max();
             

                //Validation was successful.
                Area newArea = new Area();
                newArea.AreaName = textBox_addNewMaster.Text;
                newArea.AreaId = areaId + 1;
                db.Areas.AddObject(newArea);            
            }

            //If the linklabel which led us to this form was for adding a new value for the MealPlan master table.
            if (clickedLinkName.Contains("MealPlan"))
            {
                //Validation
                if (textBox_addNewMaster.Text.Length == 0 )
                {
                    MessageBox.Show("Please enter a value.", "Error");
                    return;
                }                
                int textValue=0;
                if (!Int32.TryParse(textBox_addNewMaster.Text.Trim(), out textValue))
                {
                    MessageBox.Show("Please enter a valid number.", "Error");
                    return;
                }               
                if (Int32.Parse(textBox_addNewMaster.Text) <= 0)
                {
                    MessageBox.Show("Please enter a positive value for Meal Plan.", "Error");
                    return;
                }
                if (db.MealPlans.Select(x => x.MealAmount).Contains(Int32.Parse(textBox_addNewMaster.Text)))
                {
                    MessageBox.Show("This Meal Plan already exists.", "Error");
                    return;
                }

                int lastMealPlanId = 0;
                if (db.MealPlans.Count() != 0)
                    lastMealPlanId = db.MealPlans.Select(x => x.MealPlanId).Max();

                //Validation was successful.
                MealPlan newMealPlan = new MealPlan();
                newMealPlan.MealAmount = Int32.Parse(textBox_addNewMaster.Text);
                newMealPlan.MealPlanId = lastMealPlanId + 1;
                db.MealPlans.AddObject(newMealPlan);
            }

            db.SaveChanges();
            MessageBox.Show("Added Successfully.", "Success");
            this.Close(); //close the window.
        }

        private void AddNewMaster_Load(object sender, EventArgs e)
        {
            //Initialize the value of the label.
            if (clickedLinkName.Contains("Area"))
            {
                label_whichMaster.Text = "New Area";
            }

            if (clickedLinkName.Contains("MealPlan"))
            {
                label_whichMaster.Text = "New Meal Plan";
            }
        }       
    }
}
