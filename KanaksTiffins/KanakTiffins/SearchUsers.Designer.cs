namespace KanakTiffins
{
    partial class SearchUsers
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox_mealAmount = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_lunchOrDinner = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_Search_MealPlan = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_balance = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_lastName = new System.Windows.Forms.TextBox();
            this.button_Search_UserDetails = new System.Windows.Forms.Button();
            this.comboBox_Area = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_firstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_searchResult = new System.Windows.Forms.DataGridView();
            this.button_refreshUserDetails = new System.Windows.Forms.Button();
            this.button_refreshMealPlan = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_searchResult)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_refreshMealPlan);
            this.groupBox2.Controls.Add(this.comboBox_mealAmount);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.comboBox_lunchOrDinner);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.button_Search_MealPlan);
            this.groupBox2.Location = new System.Drawing.Point(24, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(799, 56);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search By Meal Plan";
            // 
            // comboBox_mealAmount
            // 
            this.comboBox_mealAmount.FormattingEnabled = true;
            this.comboBox_mealAmount.Location = new System.Drawing.Point(80, 19);
            this.comboBox_mealAmount.Name = "comboBox_mealAmount";
            this.comboBox_mealAmount.Size = new System.Drawing.Size(121, 21);
            this.comboBox_mealAmount.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Meal amount";
            // 
            // comboBox_lunchOrDinner
            // 
            this.comboBox_lunchOrDinner.FormattingEnabled = true;
            this.comboBox_lunchOrDinner.Location = new System.Drawing.Point(323, 21);
            this.comboBox_lunchOrDinner.Name = "comboBox_lunchOrDinner";
            this.comboBox_lunchOrDinner.Size = new System.Drawing.Size(136, 21);
            this.comboBox_lunchOrDinner.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Lunch/Dinner";
            // 
            // button_Search_MealPlan
            // 
            this.button_Search_MealPlan.Location = new System.Drawing.Point(619, 23);
            this.button_Search_MealPlan.Name = "button_Search_MealPlan";
            this.button_Search_MealPlan.Size = new System.Drawing.Size(75, 23);
            this.button_Search_MealPlan.TabIndex = 9;
            this.button_Search_MealPlan.Text = "Search";
            this.button_Search_MealPlan.UseVisualStyleBackColor = true;
            this.button_Search_MealPlan.Click += new System.EventHandler(this.button_Search_MealPlan_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_refreshUserDetails);
            this.groupBox1.Controls.Add(this.textBox_balance);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_lastName);
            this.groupBox1.Controls.Add(this.button_Search_UserDetails);
            this.groupBox1.Controls.Add(this.comboBox_Area);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_firstName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(799, 53);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search By User Details ";
            // 
            // textBox_balance
            // 
            this.textBox_balance.Location = new System.Drawing.Point(543, 23);
            this.textBox_balance.Name = "textBox_balance";
            this.textBox_balance.Size = new System.Drawing.Size(70, 20);
            this.textBox_balance.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(476, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Balance >=";
            // 
            // textBox_lastName
            // 
            this.textBox_lastName.Location = new System.Drawing.Point(156, 22);
            this.textBox_lastName.Name = "textBox_lastName";
            this.textBox_lastName.Size = new System.Drawing.Size(75, 20);
            this.textBox_lastName.TabIndex = 8;
            // 
            // button_Search_UserDetails
            // 
            this.button_Search_UserDetails.Location = new System.Drawing.Point(619, 22);
            this.button_Search_UserDetails.Name = "button_Search_UserDetails";
            this.button_Search_UserDetails.Size = new System.Drawing.Size(75, 23);
            this.button_Search_UserDetails.TabIndex = 6;
            this.button_Search_UserDetails.Text = "Search";
            this.button_Search_UserDetails.UseVisualStyleBackColor = true;
            this.button_Search_UserDetails.Click += new System.EventHandler(this.button_Search_UserDetails_Click);
            // 
            // comboBox_Area
            // 
            this.comboBox_Area.DisplayMember = "AreaName";
            this.comboBox_Area.FormattingEnabled = true;
            this.comboBox_Area.Location = new System.Drawing.Point(308, 22);
            this.comboBox_Area.Name = "comboBox_Area";
            this.comboBox_Area.Size = new System.Drawing.Size(136, 21);
            this.comboBox_Area.TabIndex = 4;
            this.comboBox_Area.ValueMember = "AreaId";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Area";
            // 
            // textBox_firstName
            // 
            this.textBox_firstName.Location = new System.Drawing.Point(80, 22);
            this.textBox_firstName.Name = "textBox_firstName";
            this.textBox_firstName.Size = new System.Drawing.Size(70, 20);
            this.textBox_firstName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // dataGridView_searchResult
            // 
            this.dataGridView_searchResult.AllowUserToAddRows = false;
            this.dataGridView_searchResult.AllowUserToDeleteRows = false;
            this.dataGridView_searchResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_searchResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_searchResult.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_searchResult.Location = new System.Drawing.Point(24, 133);
            this.dataGridView_searchResult.Name = "dataGridView_searchResult";
            this.dataGridView_searchResult.RowHeadersVisible = false;
            this.dataGridView_searchResult.Size = new System.Drawing.Size(799, 357);
            this.dataGridView_searchResult.TabIndex = 7;
            this.dataGridView_searchResult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.userDetails);
            // 
            // button_refreshUserDetails
            // 
            this.button_refreshUserDetails.Location = new System.Drawing.Point(718, 23);
            this.button_refreshUserDetails.Name = "button_refreshUserDetails";
            this.button_refreshUserDetails.Size = new System.Drawing.Size(75, 22);
            this.button_refreshUserDetails.TabIndex = 79;
            this.button_refreshUserDetails.Text = "Refresh";
            this.button_refreshUserDetails.UseVisualStyleBackColor = true;
            this.button_refreshUserDetails.Click += new System.EventHandler(this.button_refreshUserDetails_Click);
            // 
            // button_refreshMealPlan
            // 
            this.button_refreshMealPlan.Location = new System.Drawing.Point(718, 23);
            this.button_refreshMealPlan.Name = "button_refreshMealPlan";
            this.button_refreshMealPlan.Size = new System.Drawing.Size(75, 22);
            this.button_refreshMealPlan.TabIndex = 80;
            this.button_refreshMealPlan.Text = "Refresh";
            this.button_refreshMealPlan.UseVisualStyleBackColor = true;
            this.button_refreshMealPlan.Click += new System.EventHandler(this.button_refreshMealPlan_Click);
            // 
            // SearchUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 502);
            this.Controls.Add(this.dataGridView_searchResult);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SearchUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SearchUsers";
            this.Load += new System.EventHandler(this.SearchUsers_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_searchResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_Search_MealPlan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_Search_UserDetails;
        private System.Windows.Forms.ComboBox comboBox_Area;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_firstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView_searchResult;
        private System.Windows.Forms.TextBox textBox_lastName;
        private System.Windows.Forms.ComboBox comboBox_mealAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_lunchOrDinner;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_balance;
        private System.Windows.Forms.Button button_refreshMealPlan;
        private System.Windows.Forms.Button button_refreshUserDetails;
    }
}