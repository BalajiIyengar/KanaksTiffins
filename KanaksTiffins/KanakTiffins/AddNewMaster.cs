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
    public partial class AddNewMaster : Form
    {
        KanakTiffinsEntities db = new KanakTiffinsEntities();

        public String clickedLinkName;
        
        public AddNewMaster()
        {
            InitializeComponent();
        }

        private void button_addNewArea_Click(object sender, EventArgs e)
        {

            if (clickedLinkName.Contains("Area"))
            {

                if (textBox_addNewMaster.Text.Length == 0 )
                {
                    MessageBox.Show("Cant Be Empty");
                    return;
                }

                int textValue;
                if (Int32.TryParse(textBox_addNewMaster.Text.Trim(), out textValue))
                {
                    MessageBox.Show("Not a Valid Name");
                    return;
                }

                if (db.Areas.Select(x => x.AreaName).Contains(textBox_addNewMaster.Text))
                {
                    MessageBox.Show("Already Exists.");
                    return;
                }

                Area newArea = new Area();
                newArea.AreaName = textBox_addNewMaster.Text;
                newArea.AreaId = db.Areas.Select(x => x.AreaId).Max() + 1;
                db.Areas.AddObject(newArea); 

            
            }

            if (clickedLinkName.Contains("MealPlan"))
            {

                if (textBox_addNewMaster.Text.Length == 0 )
                {
                    MessageBox.Show("Cant Be Empty");
                    return;
                }
                
                int textValue=0;
                if (!Int32.TryParse(textBox_addNewMaster.Text.Trim(), out textValue))
                {
                    MessageBox.Show("Not a Valid Number");
                    return;
                }


                
                if (Int32.Parse(textBox_addNewMaster.Text) <= 0)
                {
                    MessageBox.Show("Cant Be a Negative Number.");
                    return;
                }

                if (db.MealPlans.Select(x => x.MealAmount).Contains(Int32.Parse(textBox_addNewMaster.Text)))
                {
                    MessageBox.Show("Already Exists.");
                    return;
                }
                MealPlan newMealPlan = new MealPlan();
                newMealPlan.MealAmount = Int32.Parse(textBox_addNewMaster.Text);
                newMealPlan.MealPlanId = db.MealPlans.Select(x => x.MealPlanId).Max() + 1;

                db.MealPlans.AddObject(newMealPlan);

            }

            db.SaveChanges();
            MessageBox.Show("Added Successfully");

            this.Close();
        }

        private void AddNewMaster_Load(object sender, EventArgs e)
        {
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
