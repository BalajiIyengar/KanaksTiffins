namespace KanakTiffins
{
    partial class PopulateMaster
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_editArea = new System.Windows.Forms.Label();
            this.textBox_editArea = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_deleteArea = new System.Windows.Forms.Button();
            this.button_addArea = new System.Windows.Forms.Button();
            this.textBox_area = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_areas = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label_editMealPlan = new System.Windows.Forms.Label();
            this.textBox_editMealPlan = new System.Windows.Forms.TextBox();
            this.label_ = new System.Windows.Forms.Label();
            this.button_deleteMealPlan = new System.Windows.Forms.Button();
            this.button_addMealPlan = new System.Windows.Forms.Button();
            this.textBox_mealPlan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_mealPlans = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_editArea);
            this.groupBox1.Controls.Add(this.textBox_editArea);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button_deleteArea);
            this.groupBox1.Controls.Add(this.button_addArea);
            this.groupBox1.Controls.Add(this.textBox_area);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox_areas);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 233);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Areas";
            // 
            // label_editArea
            // 
            this.label_editArea.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_editArea.AutoEllipsis = true;
            this.label_editArea.AutoSize = true;
            this.label_editArea.Location = new System.Drawing.Point(49, 122);
            this.label_editArea.Name = "label_editArea";
            this.label_editArea.Size = new System.Drawing.Size(65, 13);
            this.label_editArea.TabIndex = 9;
            this.label_editArea.Text = "New Value: ";
            // 
            // textBox_editArea
            // 
            this.textBox_editArea.Location = new System.Drawing.Point(120, 140);
            this.textBox_editArea.Name = "textBox_editArea";
            this.textBox_editArea.Size = new System.Drawing.Size(121, 20);
            this.textBox_editArea.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "New Value: ";
            // 
            // button_deleteArea
            // 
            this.button_deleteArea.AutoSize = true;
            this.button_deleteArea.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_deleteArea.Location = new System.Drawing.Point(145, 185);
            this.button_deleteArea.Name = "button_deleteArea";
            this.button_deleteArea.Size = new System.Drawing.Size(73, 23);
            this.button_deleteArea.TabIndex = 4;
            this.button_deleteArea.Text = "Delete Area";
            this.button_deleteArea.UseVisualStyleBackColor = true;
            this.button_deleteArea.Click += new System.EventHandler(this.button_deleteArea_Click);
            // 
            // button_addArea
            // 
            this.button_addArea.Location = new System.Drawing.Point(64, 185);
            this.button_addArea.Name = "button_addArea";
            this.button_addArea.Size = new System.Drawing.Size(75, 23);
            this.button_addArea.TabIndex = 3;
            this.button_addArea.Text = "Submit";
            this.button_addArea.UseVisualStyleBackColor = true;
            this.button_addArea.Click += new System.EventHandler(this.button_addArea_Click);
            // 
            // textBox_area
            // 
            this.textBox_area.Location = new System.Drawing.Point(120, 88);
            this.textBox_area.Name = "textBox_area";
            this.textBox_area.Size = new System.Drawing.Size(121, 20);
            this.textBox_area.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Existing Values";
            // 
            // comboBox_areas
            // 
            this.comboBox_areas.FormattingEnabled = true;
            this.comboBox_areas.Location = new System.Drawing.Point(120, 52);
            this.comboBox_areas.Name = "comboBox_areas";
            this.comboBox_areas.Size = new System.Drawing.Size(121, 21);
            this.comboBox_areas.TabIndex = 0;
            this.comboBox_areas.SelectedIndexChanged += new System.EventHandler(this.comboBox_areas_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label_editMealPlan);
            this.groupBox2.Controls.Add(this.textBox_editMealPlan);
            this.groupBox2.Controls.Add(this.label_);
            this.groupBox2.Controls.Add(this.button_deleteMealPlan);
            this.groupBox2.Controls.Add(this.button_addMealPlan);
            this.groupBox2.Controls.Add(this.textBox_mealPlan);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.comboBox_mealPlans);
            this.groupBox2.Location = new System.Drawing.Point(323, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(289, 233);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Meal Plans";
            // 
            // label_editMealPlan
            // 
            this.label_editMealPlan.AutoSize = true;
            this.label_editMealPlan.Location = new System.Drawing.Point(66, 122);
            this.label_editMealPlan.Name = "label_editMealPlan";
            this.label_editMealPlan.Size = new System.Drawing.Size(65, 13);
            this.label_editMealPlan.TabIndex = 8;
            this.label_editMealPlan.Text = "New Value: ";
            // 
            // textBox_editMealPlan
            // 
            this.textBox_editMealPlan.Location = new System.Drawing.Point(137, 140);
            this.textBox_editMealPlan.Name = "textBox_editMealPlan";
            this.textBox_editMealPlan.Size = new System.Drawing.Size(121, 20);
            this.textBox_editMealPlan.TabIndex = 7;
            // 
            // label_
            // 
            this.label_.AutoSize = true;
            this.label_.Location = new System.Drawing.Point(66, 87);
            this.label_.Name = "label_";
            this.label_.Size = new System.Drawing.Size(65, 13);
            this.label_.TabIndex = 6;
            this.label_.Text = "New Value: ";
            // 
            // button_deleteMealPlan
            // 
            this.button_deleteMealPlan.AutoSize = true;
            this.button_deleteMealPlan.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_deleteMealPlan.Location = new System.Drawing.Point(163, 185);
            this.button_deleteMealPlan.Name = "button_deleteMealPlan";
            this.button_deleteMealPlan.Size = new System.Drawing.Size(95, 23);
            this.button_deleteMealPlan.TabIndex = 5;
            this.button_deleteMealPlan.Text = "Delete MealPlan";
            this.button_deleteMealPlan.UseVisualStyleBackColor = true;
            this.button_deleteMealPlan.Click += new System.EventHandler(this.button_deleteMealPlan_Click);
            // 
            // button_addMealPlan
            // 
            this.button_addMealPlan.Location = new System.Drawing.Point(82, 185);
            this.button_addMealPlan.Name = "button_addMealPlan";
            this.button_addMealPlan.Size = new System.Drawing.Size(75, 23);
            this.button_addMealPlan.TabIndex = 4;
            this.button_addMealPlan.Text = "Submit";
            this.button_addMealPlan.UseVisualStyleBackColor = true;
            this.button_addMealPlan.Click += new System.EventHandler(this.button_addMealPlan_Click);
            // 
            // textBox_mealPlan
            // 
            this.textBox_mealPlan.Location = new System.Drawing.Point(137, 84);
            this.textBox_mealPlan.Name = "textBox_mealPlan";
            this.textBox_mealPlan.Size = new System.Drawing.Size(121, 20);
            this.textBox_mealPlan.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Existing Values";
            // 
            // comboBox_mealPlans
            // 
            this.comboBox_mealPlans.FormattingEnabled = true;
            this.comboBox_mealPlans.Location = new System.Drawing.Point(137, 52);
            this.comboBox_mealPlans.Name = "comboBox_mealPlans";
            this.comboBox_mealPlans.Size = new System.Drawing.Size(121, 21);
            this.comboBox_mealPlans.TabIndex = 1;
            this.comboBox_mealPlans.SelectedIndexChanged += new System.EventHandler(this.comboBox_mealPlans_SelectedIndexChanged);
            // 
            // PopulateMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 250);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PopulateMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PopulateMaster";
            this.Load += new System.EventHandler(this.PopulateMaster_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_areas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox_mealPlans;
        private System.Windows.Forms.Button button_addArea;
        private System.Windows.Forms.TextBox textBox_area;
        private System.Windows.Forms.Button button_addMealPlan;
        private System.Windows.Forms.TextBox textBox_mealPlan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_deleteArea;
        private System.Windows.Forms.Button button_deleteMealPlan;
        private System.Windows.Forms.Label label_;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_editArea;
        private System.Windows.Forms.TextBox textBox_editArea;
        private System.Windows.Forms.Label label_editMealPlan;
        private System.Windows.Forms.TextBox textBox_editMealPlan;
    }
}