namespace KanakTiffins
{
    partial class Bills
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
            this.groupBox_searchParameters = new System.Windows.Forms.GroupBox();
            this.button_Search = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_lastName = new System.Windows.Forms.TextBox();
            this.comboBox_area = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_firstName = new System.Windows.Forms.TextBox();
            this.groupBox_users = new System.Windows.Forms.GroupBox();
            this.dataGridView_users = new System.Windows.Forms.DataGridView();
            this.groupBox_monthlyBill = new System.Windows.Forms.GroupBox();
            this.label_billNotGenerated = new System.Windows.Forms.Label();
            this.textBox_dabbawalaCharges = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_generateBill = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_year = new System.Windows.Forms.ComboBox();
            this.dataGridView_billForThisMonth = new System.Windows.Forms.DataGridView();
            this.button_save = new System.Windows.Forms.Button();
            this.label_M = new System.Windows.Forms.Label();
            this.comboBox_month = new System.Windows.Forms.ComboBox();
            this.groupBox_links = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel_searchUsers = new System.Windows.Forms.LinkLabel();
            this.linkLabel_addNewUser = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.groupBox_searchParameters.SuspendLayout();
            this.groupBox_users.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_users)).BeginInit();
            this.groupBox_monthlyBill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_billForThisMonth)).BeginInit();
            this.groupBox_links.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_searchParameters
            // 
            this.groupBox_searchParameters.Controls.Add(this.button_Search);
            this.groupBox_searchParameters.Controls.Add(this.label3);
            this.groupBox_searchParameters.Controls.Add(this.textBox_lastName);
            this.groupBox_searchParameters.Controls.Add(this.comboBox_area);
            this.groupBox_searchParameters.Controls.Add(this.label2);
            this.groupBox_searchParameters.Controls.Add(this.label1);
            this.groupBox_searchParameters.Controls.Add(this.textBox_firstName);
            this.groupBox_searchParameters.Location = new System.Drawing.Point(12, 12);
            this.groupBox_searchParameters.Name = "groupBox_searchParameters";
            this.groupBox_searchParameters.Size = new System.Drawing.Size(503, 94);
            this.groupBox_searchParameters.TabIndex = 0;
            this.groupBox_searchParameters.TabStop = false;
            this.groupBox_searchParameters.Text = "Search Parameters";
            // 
            // button_Search
            // 
            this.button_Search.Location = new System.Drawing.Point(354, 63);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(75, 23);
            this.button_Search.TabIndex = 5;
            this.button_Search.Text = "Search";
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Area";
            // 
            // textBox_lastName
            // 
            this.textBox_lastName.Location = new System.Drawing.Point(329, 20);
            this.textBox_lastName.Name = "textBox_lastName";
            this.textBox_lastName.Size = new System.Drawing.Size(100, 20);
            this.textBox_lastName.TabIndex = 3;
            // 
            // comboBox_area
            // 
            this.comboBox_area.FormattingEnabled = true;
            this.comboBox_area.Location = new System.Drawing.Point(109, 60);
            this.comboBox_area.Name = "comboBox_area";
            this.comboBox_area.Size = new System.Drawing.Size(121, 21);
            this.comboBox_area.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "First Name";
            // 
            // textBox_firstName
            // 
            this.textBox_firstName.Location = new System.Drawing.Point(109, 20);
            this.textBox_firstName.Name = "textBox_firstName";
            this.textBox_firstName.Size = new System.Drawing.Size(121, 20);
            this.textBox_firstName.TabIndex = 0;
            // 
            // groupBox_users
            // 
            this.groupBox_users.Controls.Add(this.dataGridView_users);
            this.groupBox_users.Location = new System.Drawing.Point(12, 112);
            this.groupBox_users.Name = "groupBox_users";
            this.groupBox_users.Size = new System.Drawing.Size(503, 372);
            this.groupBox_users.TabIndex = 1;
            this.groupBox_users.TabStop = false;
            this.groupBox_users.Text = "Users";
            // 
            // dataGridView_users
            // 
            this.dataGridView_users.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_users.Location = new System.Drawing.Point(6, 18);
            this.dataGridView_users.MultiSelect = false;
            this.dataGridView_users.Name = "dataGridView_users";
            this.dataGridView_users.RowHeadersVisible = false;
            this.dataGridView_users.Size = new System.Drawing.Size(491, 347);
            this.dataGridView_users.TabIndex = 0;
            // 
            // groupBox_monthlyBill
            // 
            this.groupBox_monthlyBill.Controls.Add(this.label_billNotGenerated);
            this.groupBox_monthlyBill.Controls.Add(this.textBox_dabbawalaCharges);
            this.groupBox_monthlyBill.Controls.Add(this.label5);
            this.groupBox_monthlyBill.Controls.Add(this.button_generateBill);
            this.groupBox_monthlyBill.Controls.Add(this.label4);
            this.groupBox_monthlyBill.Controls.Add(this.comboBox_year);
            this.groupBox_monthlyBill.Controls.Add(this.dataGridView_billForThisMonth);
            this.groupBox_monthlyBill.Controls.Add(this.button_save);
            this.groupBox_monthlyBill.Controls.Add(this.label_M);
            this.groupBox_monthlyBill.Controls.Add(this.comboBox_month);
            this.groupBox_monthlyBill.Enabled = false;
            this.groupBox_monthlyBill.Location = new System.Drawing.Point(521, 12);
            this.groupBox_monthlyBill.Name = "groupBox_monthlyBill";
            this.groupBox_monthlyBill.Size = new System.Drawing.Size(645, 472);
            this.groupBox_monthlyBill.TabIndex = 2;
            this.groupBox_monthlyBill.TabStop = false;
            this.groupBox_monthlyBill.Text = "Bill for this Month";
            // 
            // label_billNotGenerated
            // 
            this.label_billNotGenerated.AutoSize = true;
            this.label_billNotGenerated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_billNotGenerated.ForeColor = System.Drawing.Color.Red;
            this.label_billNotGenerated.Location = new System.Drawing.Point(337, 445);
            this.label_billNotGenerated.Name = "label_billNotGenerated";
            this.label_billNotGenerated.Size = new System.Drawing.Size(196, 15);
            this.label_billNotGenerated.TabIndex = 14;
            this.label_billNotGenerated.Text = "This bill is not yet generated !";
            this.label_billNotGenerated.Visible = false;
            // 
            // textBox_dabbawalaCharges
            // 
            this.textBox_dabbawalaCharges.Location = new System.Drawing.Point(539, 22);
            this.textBox_dabbawalaCharges.Name = "textBox_dabbawalaCharges";
            this.textBox_dabbawalaCharges.Size = new System.Drawing.Size(100, 20);
            this.textBox_dabbawalaCharges.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(430, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Dabbawala Charges";
            // 
            // button_generateBill
            // 
            this.button_generateBill.Location = new System.Drawing.Point(234, 442);
            this.button_generateBill.Name = "button_generateBill";
            this.button_generateBill.Size = new System.Drawing.Size(75, 23);
            this.button_generateBill.TabIndex = 11;
            this.button_generateBill.Text = "Generate Bill";
            this.button_generateBill.UseVisualStyleBackColor = true;
            this.button_generateBill.Click += new System.EventHandler(this.button_generateBill_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(231, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Year";
            // 
            // comboBox_year
            // 
            this.comboBox_year.FormattingEnabled = true;
            this.comboBox_year.Location = new System.Drawing.Point(266, 22);
            this.comboBox_year.Name = "comboBox_year";
            this.comboBox_year.Size = new System.Drawing.Size(121, 21);
            this.comboBox_year.TabIndex = 9;
            this.comboBox_year.SelectedIndexChanged += new System.EventHandler(this.comboBox_year_SelectedIndexChanged);
            // 
            // dataGridView_billForThisMonth
            // 
            this.dataGridView_billForThisMonth.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_billForThisMonth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_billForThisMonth.Location = new System.Drawing.Point(6, 48);
            this.dataGridView_billForThisMonth.Name = "dataGridView_billForThisMonth";
            this.dataGridView_billForThisMonth.RowHeadersVisible = false;
            this.dataGridView_billForThisMonth.ShowRowErrors = false;
            this.dataGridView_billForThisMonth.Size = new System.Drawing.Size(634, 388);
            this.dataGridView_billForThisMonth.TabIndex = 8;
            this.dataGridView_billForThisMonth.Visible = false;
            this.dataGridView_billForThisMonth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_billForThisMonth_KeyDown);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(142, 442);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 7;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // label_M
            // 
            this.label_M.AutoSize = true;
            this.label_M.Location = new System.Drawing.Point(6, 25);
            this.label_M.Name = "label_M";
            this.label_M.Size = new System.Drawing.Size(37, 13);
            this.label_M.TabIndex = 6;
            this.label_M.Text = "Month";
            // 
            // comboBox_month
            // 
            this.comboBox_month.FormattingEnabled = true;
            this.comboBox_month.Location = new System.Drawing.Point(49, 21);
            this.comboBox_month.Name = "comboBox_month";
            this.comboBox_month.Size = new System.Drawing.Size(121, 21);
            this.comboBox_month.TabIndex = 5;
            this.comboBox_month.SelectedIndexChanged += new System.EventHandler(this.comboBox_month_SelectedIndexChanged);
            // 
            // groupBox_links
            // 
            this.groupBox_links.Controls.Add(this.linkLabel2);
            this.groupBox_links.Controls.Add(this.linkLabel1);
            this.groupBox_links.Controls.Add(this.linkLabel_searchUsers);
            this.groupBox_links.Controls.Add(this.linkLabel_addNewUser);
            this.groupBox_links.Location = new System.Drawing.Point(1172, 12);
            this.groupBox_links.Name = "groupBox_links";
            this.groupBox_links.Size = new System.Drawing.Size(82, 472);
            this.groupBox_links.TabIndex = 3;
            this.groupBox_links.TabStop = false;
            this.groupBox_links.Text = "Links";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Location = new System.Drawing.Point(15, 230);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(66, 40);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Add/Delete from Masters";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel_searchUsers
            // 
            this.linkLabel_searchUsers.AutoSize = true;
            this.linkLabel_searchUsers.Location = new System.Drawing.Point(10, 160);
            this.linkLabel_searchUsers.Name = "linkLabel_searchUsers";
            this.linkLabel_searchUsers.Size = new System.Drawing.Size(71, 13);
            this.linkLabel_searchUsers.TabIndex = 1;
            this.linkLabel_searchUsers.TabStop = true;
            this.linkLabel_searchUsers.Text = "Search Users";
            this.linkLabel_searchUsers.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_searchUsers_LinkClicked);
            // 
            // linkLabel_addNewUser
            // 
            this.linkLabel_addNewUser.AutoSize = true;
            this.linkLabel_addNewUser.Location = new System.Drawing.Point(6, 73);
            this.linkLabel_addNewUser.Name = "linkLabel_addNewUser";
            this.linkLabel_addNewUser.Size = new System.Drawing.Size(76, 13);
            this.linkLabel_addNewUser.TabIndex = 0;
            this.linkLabel_addNewUser.TabStop = true;
            this.linkLabel_addNewUser.Text = "Add New User";
            this.linkLabel_addNewUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_addNewUser_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.Location = new System.Drawing.Point(6, 346);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(76, 13);
            this.linkLabel2.TabIndex = 3;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "User Payment";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // Bills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 496);
            this.Controls.Add(this.groupBox_links);
            this.Controls.Add(this.groupBox_monthlyBill);
            this.Controls.Add(this.groupBox_users);
            this.Controls.Add(this.groupBox_searchParameters);
            this.Name = "Bills";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bills";
            this.Load += new System.EventHandler(this.Bills_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnMouseClick);
            this.groupBox_searchParameters.ResumeLayout(false);
            this.groupBox_searchParameters.PerformLayout();
            this.groupBox_users.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_users)).EndInit();
            this.groupBox_monthlyBill.ResumeLayout(false);
            this.groupBox_monthlyBill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_billForThisMonth)).EndInit();
            this.groupBox_links.ResumeLayout(false);
            this.groupBox_links.PerformLayout();
            this.ResumeLayout(false);

        }

        private void OnMouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_searchParameters;
        private System.Windows.Forms.GroupBox groupBox_users;
        private System.Windows.Forms.GroupBox groupBox_monthlyBill;
        private System.Windows.Forms.GroupBox groupBox_links;
        private System.Windows.Forms.LinkLabel linkLabel_searchUsers;
        private System.Windows.Forms.LinkLabel linkLabel_addNewUser;
        private System.Windows.Forms.DataGridView dataGridView_users;
        private System.Windows.Forms.TextBox textBox_lastName;
        private System.Windows.Forms.ComboBox comboBox_area;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_firstName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_M;
        private System.Windows.Forms.ComboBox comboBox_month;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.DataGridView dataGridView_billForThisMonth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_year;
        private System.Windows.Forms.Button button_generateBill;
        private System.Windows.Forms.TextBox textBox_dabbawalaCharges;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label_billNotGenerated;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}

