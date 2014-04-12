namespace KanakTiffins
{
    partial class UserDetail
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
            this.groupBox_billingHistory = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.comboBox_year = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_showBills = new System.Windows.Forms.Button();
            this.groupBox_userDetails = new System.Windows.Forms.GroupBox();
            this.button_deleteUser = new System.Windows.Forms.Button();
            this.button_editUser = new System.Windows.Forms.Button();
            this.textBox_deliveryCharges = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_lunchOrDinner = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_mealPlan = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_area = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_phone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_address = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label_dueAmount = new System.Windows.Forms.Label();
            this.label_carryForwardAmount = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox_billingHistory.SuspendLayout();
            this.groupBox_userDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_billingHistory
            // 
            this.groupBox_billingHistory.Controls.Add(this.flowLayoutPanel1);
            this.groupBox_billingHistory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox_billingHistory.Location = new System.Drawing.Point(0, 135);
            this.groupBox_billingHistory.Name = "groupBox_billingHistory";
            this.groupBox_billingHistory.Size = new System.Drawing.Size(1148, 521);
            this.groupBox_billingHistory.TabIndex = 6;
            this.groupBox_billingHistory.TabStop = false;
            this.groupBox_billingHistory.Text = "Billing History";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1142, 502);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // comboBox_year
            // 
            this.comboBox_year.FormattingEnabled = true;
            this.comboBox_year.Location = new System.Drawing.Point(89, 108);
            this.comboBox_year.Name = "comboBox_year";
            this.comboBox_year.Size = new System.Drawing.Size(121, 21);
            this.comboBox_year.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Select year";
            // 
            // button_showBills
            // 
            this.button_showBills.Location = new System.Drawing.Point(237, 106);
            this.button_showBills.Name = "button_showBills";
            this.button_showBills.Size = new System.Drawing.Size(75, 23);
            this.button_showBills.TabIndex = 11;
            this.button_showBills.Text = "Show Bills";
            this.button_showBills.UseVisualStyleBackColor = true;
            this.button_showBills.Click += new System.EventHandler(this.button_showBills_Click);
            // 
            // groupBox_userDetails
            // 
            this.groupBox_userDetails.Controls.Add(this.button_deleteUser);
            this.groupBox_userDetails.Controls.Add(this.button_editUser);
            this.groupBox_userDetails.Controls.Add(this.textBox_deliveryCharges);
            this.groupBox_userDetails.Controls.Add(this.label8);
            this.groupBox_userDetails.Controls.Add(this.textBox_lunchOrDinner);
            this.groupBox_userDetails.Controls.Add(this.label7);
            this.groupBox_userDetails.Controls.Add(this.textBox_mealPlan);
            this.groupBox_userDetails.Controls.Add(this.label6);
            this.groupBox_userDetails.Controls.Add(this.textBox_area);
            this.groupBox_userDetails.Controls.Add(this.label4);
            this.groupBox_userDetails.Controls.Add(this.textBox_email);
            this.groupBox_userDetails.Controls.Add(this.label3);
            this.groupBox_userDetails.Controls.Add(this.textBox_phone);
            this.groupBox_userDetails.Controls.Add(this.label2);
            this.groupBox_userDetails.Controls.Add(this.textBox_address);
            this.groupBox_userDetails.Controls.Add(this.label1);
            this.groupBox_userDetails.Location = new System.Drawing.Point(3, 2);
            this.groupBox_userDetails.Name = "groupBox_userDetails";
            this.groupBox_userDetails.Size = new System.Drawing.Size(1142, 100);
            this.groupBox_userDetails.TabIndex = 12;
            this.groupBox_userDetails.TabStop = false;
            this.groupBox_userDetails.Text = "Username";
            // 
            // button_deleteUser
            // 
            this.button_deleteUser.Location = new System.Drawing.Point(1061, 45);
            this.button_deleteUser.Name = "button_deleteUser";
            this.button_deleteUser.Size = new System.Drawing.Size(75, 23);
            this.button_deleteUser.TabIndex = 15;
            this.button_deleteUser.Text = "Delete";
            this.button_deleteUser.UseVisualStyleBackColor = true;
            this.button_deleteUser.Click += new System.EventHandler(this.button_deleteUser_Click);
            // 
            // button_editUser
            // 
            this.button_editUser.Location = new System.Drawing.Point(1061, 71);
            this.button_editUser.Name = "button_editUser";
            this.button_editUser.Size = new System.Drawing.Size(75, 23);
            this.button_editUser.TabIndex = 14;
            this.button_editUser.Text = "Edit";
            this.button_editUser.UseVisualStyleBackColor = true;
            this.button_editUser.Click += new System.EventHandler(this.button_editUser_Click);
            // 
            // textBox_deliveryCharges
            // 
            this.textBox_deliveryCharges.Location = new System.Drawing.Point(795, 71);
            this.textBox_deliveryCharges.Name = "textBox_deliveryCharges";
            this.textBox_deliveryCharges.ReadOnly = true;
            this.textBox_deliveryCharges.Size = new System.Drawing.Size(145, 20);
            this.textBox_deliveryCharges.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(702, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Delivery Charges";
            // 
            // textBox_lunchOrDinner
            // 
            this.textBox_lunchOrDinner.Location = new System.Drawing.Point(795, 45);
            this.textBox_lunchOrDinner.Name = "textBox_lunchOrDinner";
            this.textBox_lunchOrDinner.ReadOnly = true;
            this.textBox_lunchOrDinner.Size = new System.Drawing.Size(145, 20);
            this.textBox_lunchOrDinner.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(716, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Lunch/Dinner";
            // 
            // textBox_mealPlan
            // 
            this.textBox_mealPlan.Location = new System.Drawing.Point(795, 16);
            this.textBox_mealPlan.Name = "textBox_mealPlan";
            this.textBox_mealPlan.ReadOnly = true;
            this.textBox_mealPlan.Size = new System.Drawing.Size(145, 20);
            this.textBox_mealPlan.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(735, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Meal Plan";
            // 
            // textBox_area
            // 
            this.textBox_area.Location = new System.Drawing.Point(428, 45);
            this.textBox_area.Name = "textBox_area";
            this.textBox_area.ReadOnly = true;
            this.textBox_area.Size = new System.Drawing.Size(146, 20);
            this.textBox_area.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(393, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Area";
            // 
            // textBox_email
            // 
            this.textBox_email.Location = new System.Drawing.Point(428, 16);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.ReadOnly = true;
            this.textBox_email.Size = new System.Drawing.Size(146, 20);
            this.textBox_email.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(390, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Email";
            // 
            // textBox_phone
            // 
            this.textBox_phone.Location = new System.Drawing.Point(428, 71);
            this.textBox_phone.Name = "textBox_phone";
            this.textBox_phone.ReadOnly = true;
            this.textBox_phone.Size = new System.Drawing.Size(146, 20);
            this.textBox_phone.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(384, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Phone";
            // 
            // textBox_address
            // 
            this.textBox_address.Location = new System.Drawing.Point(60, 19);
            this.textBox_address.Multiline = true;
            this.textBox_address.Name = "textBox_address";
            this.textBox_address.ReadOnly = true;
            this.textBox_address.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_address.Size = new System.Drawing.Size(204, 75);
            this.textBox_address.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Address";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(390, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(156, 18);
            this.label9.TabIndex = 13;
            this.label9.Text = "Due Amount:    Rs. ";
            // 
            // label_dueAmount
            // 
            this.label_dueAmount.AutoSize = true;
            this.label_dueAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_dueAmount.ForeColor = System.Drawing.Color.Red;
            this.label_dueAmount.Location = new System.Drawing.Point(552, 108);
            this.label_dueAmount.Name = "label_dueAmount";
            this.label_dueAmount.Size = new System.Drawing.Size(17, 18);
            this.label_dueAmount.TabIndex = 14;
            this.label_dueAmount.Text = "0";
            // 
            // label_carryForwardAmount
            // 
            this.label_carryForwardAmount.AutoSize = true;
            this.label_carryForwardAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_carryForwardAmount.ForeColor = System.Drawing.Color.Green;
            this.label_carryForwardAmount.Location = new System.Drawing.Point(887, 108);
            this.label_carryForwardAmount.Name = "label_carryForwardAmount";
            this.label_carryForwardAmount.Size = new System.Drawing.Size(17, 18);
            this.label_carryForwardAmount.TabIndex = 16;
            this.label_carryForwardAmount.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(657, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(224, 18);
            this.label12.TabIndex = 15;
            this.label12.Text = "Carryforward Amount:    Rs. ";
            // 
            // UserDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 656);
            this.Controls.Add(this.label_carryForwardAmount);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label_dueAmount);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox_userDetails);
            this.Controls.Add(this.button_showBills);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_year);
            this.Controls.Add(this.groupBox_billingHistory);
            this.Name = "UserDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Details";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UserDetail_Load);
            this.groupBox_billingHistory.ResumeLayout(false);
            this.groupBox_billingHistory.PerformLayout();
            this.groupBox_userDetails.ResumeLayout(false);
            this.groupBox_userDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_billingHistory;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox comboBox_year;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_showBills;
        private System.Windows.Forms.GroupBox groupBox_userDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_address;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_phone;
        private System.Windows.Forms.TextBox textBox_email;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_area;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_mealPlan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_lunchOrDinner;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_deliveryCharges;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_editUser;
        private System.Windows.Forms.Button button_deleteUser;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label_dueAmount;
        private System.Windows.Forms.Label label_carryForwardAmount;
        private System.Windows.Forms.Label label12;
    }
}