namespace KanakTiffins
{
    partial class UserPayment
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
            this.groupBox_searchUsers = new System.Windows.Forms.GroupBox();
            this.dataGridView_searchUsers = new System.Windows.Forms.DataGridView();
            this.button_userSearch = new System.Windows.Forms.Button();
            this.comboBox_area = new System.Windows.Forms.ComboBox();
            this.textBox_lastName = new System.Windows.Forms.TextBox();
            this.textBox_firstName = new System.Windows.Forms.TextBox();
            this.groupBox_userPayment = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_area = new System.Windows.Forms.TextBox();
            this.textBox_userName = new System.Windows.Forms.TextBox();
            this.button_userPayment = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_paymentMethod = new System.Windows.Forms.TextBox();
            this.textBox_amountPaid = new System.Windows.Forms.TextBox();
            this.dateTimePicker_paidOn = new System.Windows.Forms.DateTimePicker();
            this.groupBox_searchUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_searchUsers)).BeginInit();
            this.groupBox_userPayment.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_searchUsers
            // 
            this.groupBox_searchUsers.Controls.Add(this.dataGridView_searchUsers);
            this.groupBox_searchUsers.Controls.Add(this.button_userSearch);
            this.groupBox_searchUsers.Controls.Add(this.comboBox_area);
            this.groupBox_searchUsers.Controls.Add(this.textBox_lastName);
            this.groupBox_searchUsers.Controls.Add(this.textBox_firstName);
            this.groupBox_searchUsers.Location = new System.Drawing.Point(12, 35);
            this.groupBox_searchUsers.Name = "groupBox_searchUsers";
            this.groupBox_searchUsers.Size = new System.Drawing.Size(267, 465);
            this.groupBox_searchUsers.TabIndex = 0;
            this.groupBox_searchUsers.TabStop = false;
            this.groupBox_searchUsers.Text = "Search Users";
            // 
            // dataGridView_searchUsers
            // 
            this.dataGridView_searchUsers.AllowUserToAddRows = false;
            this.dataGridView_searchUsers.AllowUserToDeleteRows = false;
            this.dataGridView_searchUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_searchUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_searchUsers.Location = new System.Drawing.Point(6, 208);
            this.dataGridView_searchUsers.Name = "dataGridView_searchUsers";
            this.dataGridView_searchUsers.RowHeadersVisible = false;
            this.dataGridView_searchUsers.Size = new System.Drawing.Size(255, 251);
            this.dataGridView_searchUsers.TabIndex = 8;
            // 
            // button_userSearch
            // 
            this.button_userSearch.Location = new System.Drawing.Point(76, 153);
            this.button_userSearch.Name = "button_userSearch";
            this.button_userSearch.Size = new System.Drawing.Size(100, 23);
            this.button_userSearch.TabIndex = 7;
            this.button_userSearch.Text = "Search";
            this.button_userSearch.UseVisualStyleBackColor = true;
            this.button_userSearch.Click += new System.EventHandler(this.button_userSearch_Click);
            // 
            // comboBox_area
            // 
            this.comboBox_area.FormattingEnabled = true;
            this.comboBox_area.Location = new System.Drawing.Point(76, 102);
            this.comboBox_area.Name = "comboBox_area";
            this.comboBox_area.Size = new System.Drawing.Size(100, 21);
            this.comboBox_area.TabIndex = 2;
            // 
            // textBox_lastName
            // 
            this.textBox_lastName.Location = new System.Drawing.Point(138, 52);
            this.textBox_lastName.Name = "textBox_lastName";
            this.textBox_lastName.Size = new System.Drawing.Size(100, 20);
            this.textBox_lastName.TabIndex = 1;
            // 
            // textBox_firstName
            // 
            this.textBox_firstName.Location = new System.Drawing.Point(17, 52);
            this.textBox_firstName.Name = "textBox_firstName";
            this.textBox_firstName.Size = new System.Drawing.Size(100, 20);
            this.textBox_firstName.TabIndex = 0;
            // 
            // groupBox_userPayment
            // 
            this.groupBox_userPayment.Controls.Add(this.dateTimePicker_paidOn);
            this.groupBox_userPayment.Controls.Add(this.label5);
            this.groupBox_userPayment.Controls.Add(this.label4);
            this.groupBox_userPayment.Controls.Add(this.textBox_area);
            this.groupBox_userPayment.Controls.Add(this.textBox_userName);
            this.groupBox_userPayment.Controls.Add(this.button_userPayment);
            this.groupBox_userPayment.Controls.Add(this.label3);
            this.groupBox_userPayment.Controls.Add(this.label2);
            this.groupBox_userPayment.Controls.Add(this.label1);
            this.groupBox_userPayment.Controls.Add(this.textBox_paymentMethod);
            this.groupBox_userPayment.Controls.Add(this.textBox_amountPaid);
            this.groupBox_userPayment.Location = new System.Drawing.Point(316, 35);
            this.groupBox_userPayment.Name = "groupBox_userPayment";
            this.groupBox_userPayment.Size = new System.Drawing.Size(267, 465);
            this.groupBox_userPayment.TabIndex = 1;
            this.groupBox_userPayment.TabStop = false;
            this.groupBox_userPayment.Text = "User Payment Details";
            this.groupBox_userPayment.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(69, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Area";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Customer Name";
            // 
            // textBox_area
            // 
            this.textBox_area.Location = new System.Drawing.Point(103, 73);
            this.textBox_area.Name = "textBox_area";
            this.textBox_area.ReadOnly = true;
            this.textBox_area.Size = new System.Drawing.Size(127, 20);
            this.textBox_area.TabIndex = 8;
            // 
            // textBox_userName
            // 
            this.textBox_userName.Location = new System.Drawing.Point(103, 36);
            this.textBox_userName.Name = "textBox_userName";
            this.textBox_userName.ReadOnly = true;
            this.textBox_userName.Size = new System.Drawing.Size(127, 20);
            this.textBox_userName.TabIndex = 7;
            // 
            // button_userPayment
            // 
            this.button_userPayment.Location = new System.Drawing.Point(78, 246);
            this.button_userPayment.Name = "button_userPayment";
            this.button_userPayment.Size = new System.Drawing.Size(75, 23);
            this.button_userPayment.TabIndex = 6;
            this.button_userPayment.Text = "Submit";
            this.button_userPayment.UseVisualStyleBackColor = true;
            this.button_userPayment.Click += new System.EventHandler(this.button_userPayment_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Payment Method";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Paid on";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Amount Paid";
            // 
            // textBox_paymentMethod
            // 
            this.textBox_paymentMethod.Location = new System.Drawing.Point(104, 187);
            this.textBox_paymentMethod.Name = "textBox_paymentMethod";
            this.textBox_paymentMethod.Size = new System.Drawing.Size(126, 20);
            this.textBox_paymentMethod.TabIndex = 2;
            // 
            // textBox_amountPaid
            // 
            this.textBox_amountPaid.Location = new System.Drawing.Point(104, 113);
            this.textBox_amountPaid.Name = "textBox_amountPaid";
            this.textBox_amountPaid.Size = new System.Drawing.Size(126, 20);
            this.textBox_amountPaid.TabIndex = 0;
            // 
            // dateTimePicker_paidOn
            // 
            this.dateTimePicker_paidOn.Location = new System.Drawing.Point(103, 146);
            this.dateTimePicker_paidOn.Name = "dateTimePicker_paidOn";
            this.dateTimePicker_paidOn.Size = new System.Drawing.Size(127, 20);
            this.dateTimePicker_paidOn.TabIndex = 12;
            // 
            // UserPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 512);
            this.Controls.Add(this.groupBox_userPayment);
            this.Controls.Add(this.groupBox_searchUsers);
            this.Name = "UserPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserPayment";
            this.Load += new System.EventHandler(this.UserPayment_Load);
            this.groupBox_searchUsers.ResumeLayout(false);
            this.groupBox_searchUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_searchUsers)).EndInit();
            this.groupBox_userPayment.ResumeLayout(false);
            this.groupBox_userPayment.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_searchUsers;
        private System.Windows.Forms.GroupBox groupBox_userPayment;
        private System.Windows.Forms.ComboBox comboBox_area;
        private System.Windows.Forms.TextBox textBox_lastName;
        private System.Windows.Forms.TextBox textBox_firstName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_paymentMethod;
        private System.Windows.Forms.TextBox textBox_amountPaid;
        private System.Windows.Forms.Button button_userPayment;
        private System.Windows.Forms.TextBox textBox_area;
        private System.Windows.Forms.TextBox textBox_userName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_userSearch;
        private System.Windows.Forms.DataGridView dataGridView_searchUsers;
        private System.Windows.Forms.DateTimePicker dateTimePicker_paidOn;
    }
}