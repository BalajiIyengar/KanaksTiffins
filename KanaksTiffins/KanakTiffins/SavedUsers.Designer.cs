namespace KanakTiffins
{
    partial class SavedUsers
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
            this.comboBox_month = new System.Windows.Forms.ComboBox();
            this.comboBox_year = new System.Windows.Forms.ComboBox();
            this.button_getSavedUsers = new System.Windows.Forms.Button();
            this.dataGridView_savedUsers = new System.Windows.Forms.DataGridView();
            this.dataGridView_unsavedUsers = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_savedUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_unsavedUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_month
            // 
            this.comboBox_month.FormattingEnabled = true;
            this.comboBox_month.Location = new System.Drawing.Point(177, 43);
            this.comboBox_month.Name = "comboBox_month";
            this.comboBox_month.Size = new System.Drawing.Size(121, 21);
            this.comboBox_month.TabIndex = 0;
            // 
            // comboBox_year
            // 
            this.comboBox_year.FormattingEnabled = true;
            this.comboBox_year.Location = new System.Drawing.Point(364, 43);
            this.comboBox_year.Name = "comboBox_year";
            this.comboBox_year.Size = new System.Drawing.Size(121, 21);
            this.comboBox_year.TabIndex = 1;
            // 
            // button_getSavedUsers
            // 
            this.button_getSavedUsers.Location = new System.Drawing.Point(291, 94);
            this.button_getSavedUsers.Name = "button_getSavedUsers";
            this.button_getSavedUsers.Size = new System.Drawing.Size(75, 23);
            this.button_getSavedUsers.TabIndex = 2;
            this.button_getSavedUsers.Text = "Get Users";
            this.button_getSavedUsers.UseVisualStyleBackColor = true;
            this.button_getSavedUsers.Click += new System.EventHandler(this.button_getSavedUsers_Click);
            // 
            // dataGridView_savedUsers
            // 
            this.dataGridView_savedUsers.AllowUserToAddRows = false;
            this.dataGridView_savedUsers.AllowUserToDeleteRows = false;
            this.dataGridView_savedUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_savedUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_savedUsers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_savedUsers.Location = new System.Drawing.Point(28, 156);
            this.dataGridView_savedUsers.Name = "dataGridView_savedUsers";
            this.dataGridView_savedUsers.ReadOnly = true;
            this.dataGridView_savedUsers.RowHeadersVisible = false;
            this.dataGridView_savedUsers.Size = new System.Drawing.Size(260, 309);
            this.dataGridView_savedUsers.TabIndex = 3;
            // 
            // dataGridView_unsavedUsers
            // 
            this.dataGridView_unsavedUsers.AllowUserToAddRows = false;
            this.dataGridView_unsavedUsers.AllowUserToDeleteRows = false;
            this.dataGridView_unsavedUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_unsavedUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_unsavedUsers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_unsavedUsers.Location = new System.Drawing.Point(351, 156);
            this.dataGridView_unsavedUsers.Name = "dataGridView_unsavedUsers";
            this.dataGridView_unsavedUsers.ReadOnly = true;
            this.dataGridView_unsavedUsers.RowHeadersVisible = false;
            this.dataGridView_unsavedUsers.Size = new System.Drawing.Size(260, 309);
            this.dataGridView_unsavedUsers.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(134, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Month";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(329, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Year";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Saved";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(471, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Unsaved";
            // 
            // SavedUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 477);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_unsavedUsers);
            this.Controls.Add(this.dataGridView_savedUsers);
            this.Controls.Add(this.button_getSavedUsers);
            this.Controls.Add(this.comboBox_year);
            this.Controls.Add(this.comboBox_month);
            this.Name = "SavedUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SavedUsers";
            this.Load += new System.EventHandler(this.SavedUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_savedUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_unsavedUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_month;
        private System.Windows.Forms.ComboBox comboBox_year;
        private System.Windows.Forms.Button button_getSavedUsers;
        private System.Windows.Forms.DataGridView dataGridView_savedUsers;
        private System.Windows.Forms.DataGridView dataGridView_unsavedUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}