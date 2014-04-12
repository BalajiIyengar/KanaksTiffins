namespace KanakTiffins
{
    partial class AddNewUser
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
            this.linkLabel_addNewMealPlan = new System.Windows.Forms.LinkLabel();
            this.linkLabel_addNewArea = new System.Windows.Forms.LinkLabel();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox_lunchOrDinner = new System.Windows.Forms.ComboBox();
            this.textBox_firstName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox_area = new System.Windows.Forms.ComboBox();
            this.comboBox_typeOfLunch = new System.Windows.Forms.ComboBox();
            this.textBox_EmailId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_PhoneNumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_AvailableBalance = new System.Windows.Forms.TextBox();
            this.button_SubmitAddNewUser = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_DabbaWalaDeliveryCharges = new System.Windows.Forms.TextBox();
            this.textBox_Deposit = new System.Windows.Forms.TextBox();
            this.textBox_Address = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.textBox_lastName = new System.Windows.Forms.TextBox();
            this.lbl_lastName = new System.Windows.Forms.Label();
            this.button_edit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // linkLabel_addNewMealPlan
            // 
            this.linkLabel_addNewMealPlan.AutoSize = true;
            this.linkLabel_addNewMealPlan.Location = new System.Drawing.Point(37, 224);
            this.linkLabel_addNewMealPlan.Name = "linkLabel_addNewMealPlan";
            this.linkLabel_addNewMealPlan.Size = new System.Drawing.Size(57, 13);
            this.linkLabel_addNewMealPlan.TabIndex = 75;
            this.linkLabel_addNewMealPlan.TabStop = true;
            this.linkLabel_addNewMealPlan.Text = "Add New..";
            this.linkLabel_addNewMealPlan.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_addNewMealPlan_LinkClicked_1);
            // 
            // linkLabel_addNewArea
            // 
            this.linkLabel_addNewArea.AutoSize = true;
            this.linkLabel_addNewArea.Location = new System.Drawing.Point(281, 63);
            this.linkLabel_addNewArea.Name = "linkLabel_addNewArea";
            this.linkLabel_addNewArea.Size = new System.Drawing.Size(57, 13);
            this.linkLabel_addNewArea.TabIndex = 74;
            this.linkLabel_addNewArea.TabStop = true;
            this.linkLabel_addNewArea.Text = "Add New..";
            this.linkLabel_addNewArea.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_addNewArea_LinkClicked_1);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(262, 211);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 73;
            this.label10.Text = "Lunch/Dinner";
            // 
            // comboBox_lunchOrDinner
            // 
            this.comboBox_lunchOrDinner.FormattingEnabled = true;
            this.comboBox_lunchOrDinner.Location = new System.Drawing.Point(341, 208);
            this.comboBox_lunchOrDinner.Name = "comboBox_lunchOrDinner";
            this.comboBox_lunchOrDinner.Size = new System.Drawing.Size(121, 21);
            this.comboBox_lunchOrDinner.TabIndex = 72;
            // 
            // textBox_firstName
            // 
            this.textBox_firstName.Location = new System.Drawing.Point(110, 8);
            this.textBox_firstName.MaxLength = 50;
            this.textBox_firstName.Name = "textBox_firstName";
            this.textBox_firstName.Size = new System.Drawing.Size(121, 20);
            this.textBox_firstName.TabIndex = 71;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(47, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 70;
            this.label9.Text = "First Name";
            // 
            // comboBox_area
            // 
            this.comboBox_area.DisplayMember = "AreaName";
            this.comboBox_area.FormattingEnabled = true;
            this.comboBox_area.Location = new System.Drawing.Point(341, 47);
            this.comboBox_area.Name = "comboBox_area";
            this.comboBox_area.Size = new System.Drawing.Size(121, 21);
            this.comboBox_area.TabIndex = 68;
            this.comboBox_area.ValueMember = "AreaId";
            // 
            // comboBox_typeOfLunch
            // 
            this.comboBox_typeOfLunch.DisplayMember = "CostPerDay";
            this.comboBox_typeOfLunch.FormattingEnabled = true;
            this.comboBox_typeOfLunch.Location = new System.Drawing.Point(110, 208);
            this.comboBox_typeOfLunch.Name = "comboBox_typeOfLunch";
            this.comboBox_typeOfLunch.Size = new System.Drawing.Size(121, 21);
            this.comboBox_typeOfLunch.TabIndex = 67;
            this.comboBox_typeOfLunch.ValueMember = "MealPlanId";
            // 
            // textBox_EmailId
            // 
            this.textBox_EmailId.Location = new System.Drawing.Point(341, 122);
            this.textBox_EmailId.Name = "textBox_EmailId";
            this.textBox_EmailId.Size = new System.Drawing.Size(121, 20);
            this.textBox_EmailId.TabIndex = 66;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(289, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 65;
            this.label8.Text = "Email ID";
            // 
            // textBox_PhoneNumber
            // 
            this.textBox_PhoneNumber.Location = new System.Drawing.Point(110, 118);
            this.textBox_PhoneNumber.MaxLength = 12;
            this.textBox_PhoneNumber.Name = "textBox_PhoneNumber";
            this.textBox_PhoneNumber.Size = new System.Drawing.Size(121, 20);
            this.textBox_PhoneNumber.TabIndex = 64;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(26, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 63;
            this.label7.Text = "Phone Number";
            // 
            // textBox_AvailableBalance
            // 
            this.textBox_AvailableBalance.Location = new System.Drawing.Point(110, 165);
            this.textBox_AvailableBalance.MaxLength = 5;
            this.textBox_AvailableBalance.Name = "textBox_AvailableBalance";
            this.textBox_AvailableBalance.Size = new System.Drawing.Size(121, 20);
            this.textBox_AvailableBalance.TabIndex = 62;
            // 
            // button_SubmitAddNewUser
            // 
            this.button_SubmitAddNewUser.Location = new System.Drawing.Point(192, 249);
            this.button_SubmitAddNewUser.Name = "button_SubmitAddNewUser";
            this.button_SubmitAddNewUser.Size = new System.Drawing.Size(75, 23);
            this.button_SubmitAddNewUser.TabIndex = 61;
            this.button_SubmitAddNewUser.Text = "Submit";
            this.button_SubmitAddNewUser.UseVisualStyleBackColor = true;
            this.button_SubmitAddNewUser.Click += new System.EventHandler(this.button_SubmitAddNewUser_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(248, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 60;
            this.label5.Text = "Delivery Charges";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 59;
            this.label4.Text = "Type Of Lunch";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "Advance Balance";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(292, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 57;
            this.label1.Text = "Deposit";
            // 
            // textBox_DabbaWalaDeliveryCharges
            // 
            this.textBox_DabbaWalaDeliveryCharges.Location = new System.Drawing.Point(341, 165);
            this.textBox_DabbaWalaDeliveryCharges.Name = "textBox_DabbaWalaDeliveryCharges";
            this.textBox_DabbaWalaDeliveryCharges.Size = new System.Drawing.Size(121, 20);
            this.textBox_DabbaWalaDeliveryCharges.TabIndex = 56;
            // 
            // textBox_Deposit
            // 
            this.textBox_Deposit.Location = new System.Drawing.Point(341, 87);
            this.textBox_Deposit.MaxLength = 5;
            this.textBox_Deposit.Name = "textBox_Deposit";
            this.textBox_Deposit.Size = new System.Drawing.Size(121, 20);
            this.textBox_Deposit.TabIndex = 55;
            // 
            // textBox_Address
            // 
            this.textBox_Address.Location = new System.Drawing.Point(110, 47);
            this.textBox_Address.Multiline = true;
            this.textBox_Address.Name = "textBox_Address";
            this.textBox_Address.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Address.Size = new System.Drawing.Size(121, 53);
            this.textBox_Address.TabIndex = 53;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(294, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 52;
            this.label6.Text = "Area";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(59, 47);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(45, 13);
            this.lblAddress.TabIndex = 51;
            this.lblAddress.Text = "Address";
            // 
            // textBox_lastName
            // 
            this.textBox_lastName.Location = new System.Drawing.Point(341, 8);
            this.textBox_lastName.MaxLength = 50;
            this.textBox_lastName.Name = "textBox_lastName";
            this.textBox_lastName.Size = new System.Drawing.Size(121, 20);
            this.textBox_lastName.TabIndex = 50;
            // 
            // lbl_lastName
            // 
            this.lbl_lastName.AutoSize = true;
            this.lbl_lastName.Location = new System.Drawing.Point(280, 11);
            this.lbl_lastName.Name = "lbl_lastName";
            this.lbl_lastName.Size = new System.Drawing.Size(58, 13);
            this.lbl_lastName.TabIndex = 49;
            this.lbl_lastName.Text = "Last Name";
            // 
            // button_edit
            // 
            this.button_edit.Location = new System.Drawing.Point(192, 279);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(75, 23);
            this.button_edit.TabIndex = 76;
            this.button_edit.Text = "Edit";
            this.button_edit.UseVisualStyleBackColor = true;
            this.button_edit.Visible = false;
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click);
            // 
            // AddNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 313);
            this.Controls.Add(this.button_edit);
            this.Controls.Add(this.linkLabel_addNewMealPlan);
            this.Controls.Add(this.linkLabel_addNewArea);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBox_lunchOrDinner);
            this.Controls.Add(this.textBox_firstName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBox_area);
            this.Controls.Add(this.comboBox_typeOfLunch);
            this.Controls.Add(this.textBox_EmailId);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_PhoneNumber);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_AvailableBalance);
            this.Controls.Add(this.button_SubmitAddNewUser);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_DabbaWalaDeliveryCharges);
            this.Controls.Add(this.textBox_Deposit);
            this.Controls.Add(this.textBox_Address);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.textBox_lastName);
            this.Controls.Add(this.lbl_lastName);
            this.Name = "AddNewUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddNewUser";
            this.Load += new System.EventHandler(this.AddNewUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel_addNewMealPlan;
        private System.Windows.Forms.LinkLabel linkLabel_addNewArea;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox_lunchOrDinner;
        private System.Windows.Forms.TextBox textBox_firstName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox_area;
        private System.Windows.Forms.ComboBox comboBox_typeOfLunch;
        private System.Windows.Forms.TextBox textBox_EmailId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_PhoneNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_AvailableBalance;
        private System.Windows.Forms.Button button_SubmitAddNewUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_DabbaWalaDeliveryCharges;
        private System.Windows.Forms.TextBox textBox_Deposit;
        private System.Windows.Forms.TextBox textBox_Address;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox textBox_lastName;
        private System.Windows.Forms.Label lbl_lastName;
        private System.Windows.Forms.Button button_edit;

    }
}