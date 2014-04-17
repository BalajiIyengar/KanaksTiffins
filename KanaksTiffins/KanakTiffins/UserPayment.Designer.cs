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
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView_searchUsers = new System.Windows.Forms.DataGridView();
            this.button_userSearch = new System.Windows.Forms.Button();
            this.comboBox_area = new System.Windows.Forms.ComboBox();
            this.textBox_lastName = new System.Windows.Forms.TextBox();
            this.textBox_firstName = new System.Windows.Forms.TextBox();
            this.groupBox_userPayment = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_carryForwardAmount = new System.Windows.Forms.TextBox();
            this.textBox_dueAmount = new System.Windows.Forms.TextBox();
            this.dateTimePicker_paidOn = new System.Windows.Forms.DateTimePicker();
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
            this.dataGridView_PaymentHistory = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox_searchUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_searchUsers)).BeginInit();
            this.groupBox_userPayment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PaymentHistory)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_searchUsers
            // 
            this.groupBox_searchUsers.Controls.Add(this.label8);
            this.groupBox_searchUsers.Controls.Add(this.label7);
            this.groupBox_searchUsers.Controls.Add(this.label6);
            this.groupBox_searchUsers.Controls.Add(this.dataGridView_searchUsers);
            this.groupBox_searchUsers.Controls.Add(this.button_userSearch);
            this.groupBox_searchUsers.Controls.Add(this.comboBox_area);
            this.groupBox_searchUsers.Controls.Add(this.textBox_lastName);
            this.groupBox_searchUsers.Controls.Add(this.textBox_firstName);
            this.groupBox_searchUsers.Location = new System.Drawing.Point(12, 12);
            this.groupBox_searchUsers.Name = "groupBox_searchUsers";
            this.groupBox_searchUsers.Size = new System.Drawing.Size(351, 488);
            this.groupBox_searchUsers.TabIndex = 0;
            this.groupBox_searchUsers.TabStop = false;
            this.groupBox_searchUsers.Text = "Search Users";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(89, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Area";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(61, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Last Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(61, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "First Name";
            // 
            // dataGridView_searchUsers
            // 
            this.dataGridView_searchUsers.AllowUserToAddRows = false;
            this.dataGridView_searchUsers.AllowUserToDeleteRows = false;
            this.dataGridView_searchUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_searchUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_searchUsers.Location = new System.Drawing.Point(6, 234);
            this.dataGridView_searchUsers.Name = "dataGridView_searchUsers";
            this.dataGridView_searchUsers.RowHeadersVisible = false;
            this.dataGridView_searchUsers.Size = new System.Drawing.Size(339, 248);
            this.dataGridView_searchUsers.TabIndex = 8;
            // 
            // button_userSearch
            // 
            this.button_userSearch.Location = new System.Drawing.Point(123, 150);
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
            this.comboBox_area.Location = new System.Drawing.Point(124, 96);
            this.comboBox_area.Name = "comboBox_area";
            this.comboBox_area.Size = new System.Drawing.Size(100, 21);
            this.comboBox_area.TabIndex = 2;
            // 
            // textBox_lastName
            // 
            this.textBox_lastName.Location = new System.Drawing.Point(123, 55);
            this.textBox_lastName.Name = "textBox_lastName";
            this.textBox_lastName.Size = new System.Drawing.Size(100, 20);
            this.textBox_lastName.TabIndex = 1;
            // 
            // textBox_firstName
            // 
            this.textBox_firstName.Location = new System.Drawing.Point(123, 16);
            this.textBox_firstName.Name = "textBox_firstName";
            this.textBox_firstName.Size = new System.Drawing.Size(100, 20);
            this.textBox_firstName.TabIndex = 0;
            // 
            // groupBox_userPayment
            // 
            this.groupBox_userPayment.Controls.Add(this.label9);
            this.groupBox_userPayment.Controls.Add(this.label10);
            this.groupBox_userPayment.Controls.Add(this.textBox_carryForwardAmount);
            this.groupBox_userPayment.Controls.Add(this.textBox_dueAmount);
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
            this.groupBox_userPayment.Location = new System.Drawing.Point(369, 12);
            this.groupBox_userPayment.Name = "groupBox_userPayment";
            this.groupBox_userPayment.Size = new System.Drawing.Size(310, 211);
            this.groupBox_userPayment.TabIndex = 1;
            this.groupBox_userPayment.TabStop = false;
            this.groupBox_userPayment.Text = "Payment Details";
            this.groupBox_userPayment.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(147, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Carryforward";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Due Amt.";
            // 
            // textBox_carryForwardAmount
            // 
            this.textBox_carryForwardAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.textBox_carryForwardAmount.Location = new System.Drawing.Point(219, 45);
            this.textBox_carryForwardAmount.Name = "textBox_carryForwardAmount";
            this.textBox_carryForwardAmount.ReadOnly = true;
            this.textBox_carryForwardAmount.Size = new System.Drawing.Size(65, 20);
            this.textBox_carryForwardAmount.TabIndex = 14;
            // 
            // textBox_dueAmount
            // 
            this.textBox_dueAmount.ForeColor = System.Drawing.Color.Red;
            this.textBox_dueAmount.Location = new System.Drawing.Point(62, 42);
            this.textBox_dueAmount.Name = "textBox_dueAmount";
            this.textBox_dueAmount.ReadOnly = true;
            this.textBox_dueAmount.Size = new System.Drawing.Size(65, 20);
            this.textBox_dueAmount.TabIndex = 13;
            // 
            // dateTimePicker_paidOn
            // 
            this.dateTimePicker_paidOn.Location = new System.Drawing.Point(98, 123);
            this.dateTimePicker_paidOn.Name = "dateTimePicker_paidOn";
            this.dateTimePicker_paidOn.Size = new System.Drawing.Size(127, 20);
            this.dateTimePicker_paidOn.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(184, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Area";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Name";
            // 
            // textBox_area
            // 
            this.textBox_area.Location = new System.Drawing.Point(219, 13);
            this.textBox_area.Name = "textBox_area";
            this.textBox_area.ReadOnly = true;
            this.textBox_area.Size = new System.Drawing.Size(82, 20);
            this.textBox_area.TabIndex = 8;
            // 
            // textBox_userName
            // 
            this.textBox_userName.Location = new System.Drawing.Point(62, 13);
            this.textBox_userName.Name = "textBox_userName";
            this.textBox_userName.ReadOnly = true;
            this.textBox_userName.Size = new System.Drawing.Size(109, 20);
            this.textBox_userName.TabIndex = 7;
            // 
            // button_userPayment
            // 
            this.button_userPayment.Location = new System.Drawing.Point(125, 180);
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
            this.label3.Location = new System.Drawing.Point(6, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Payment Method";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Paid on";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Amount Paid";
            // 
            // textBox_paymentMethod
            // 
            this.textBox_paymentMethod.Location = new System.Drawing.Point(99, 154);
            this.textBox_paymentMethod.Name = "textBox_paymentMethod";
            this.textBox_paymentMethod.Size = new System.Drawing.Size(126, 20);
            this.textBox_paymentMethod.TabIndex = 2;
            // 
            // textBox_amountPaid
            // 
            this.textBox_amountPaid.Location = new System.Drawing.Point(99, 96);
            this.textBox_amountPaid.Name = "textBox_amountPaid";
            this.textBox_amountPaid.Size = new System.Drawing.Size(126, 20);
            this.textBox_amountPaid.TabIndex = 0;
            // 
            // dataGridView_PaymentHistory
            // 
            this.dataGridView_PaymentHistory.AllowUserToAddRows = false;
            this.dataGridView_PaymentHistory.AllowUserToDeleteRows = false;
            this.dataGridView_PaymentHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_PaymentHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_PaymentHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_PaymentHistory.Location = new System.Drawing.Point(3, 16);
            this.dataGridView_PaymentHistory.Name = "dataGridView_PaymentHistory";
            this.dataGridView_PaymentHistory.RowHeadersVisible = false;
            this.dataGridView_PaymentHistory.Size = new System.Drawing.Size(307, 251);
            this.dataGridView_PaymentHistory.TabIndex = 17;
            this.dataGridView_PaymentHistory.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView_PaymentHistory);
            this.groupBox1.Location = new System.Drawing.Point(369, 230);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 270);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment History";
            this.groupBox1.Visible = false;
            // 
            // UserPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 512);
            this.Controls.Add(this.groupBox1);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PaymentHistory)).EndInit();
            this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_carryForwardAmount;
        private System.Windows.Forms.TextBox textBox_dueAmount;
        private System.Windows.Forms.DataGridView dataGridView_PaymentHistory;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}