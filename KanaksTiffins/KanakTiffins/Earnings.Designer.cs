namespace KanakTiffins
{
    partial class Earnings
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_totalBills = new System.Windows.Forms.TextBox();
            this.textBox_totalReceived = new System.Windows.Forms.TextBox();
            this.textBox_totalBalance = new System.Windows.Forms.TextBox();
            this.comboBox_fromMonth = new System.Windows.Forms.ComboBox();
            this.comboBox_fromYear = new System.Windows.Forms.ComboBox();
            this.comboBox_toYear = new System.Windows.Forms.ComboBox();
            this.comboBox_toMonth = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_fetchEarnings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Bills";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total Received";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total Balance";
            // 
            // textBox_totalBills
            // 
            this.textBox_totalBills.Location = new System.Drawing.Point(129, 204);
            this.textBox_totalBills.Name = "textBox_totalBills";
            this.textBox_totalBills.ReadOnly = true;
            this.textBox_totalBills.Size = new System.Drawing.Size(100, 20);
            this.textBox_totalBills.TabIndex = 3;
            // 
            // textBox_totalReceived
            // 
            this.textBox_totalReceived.Location = new System.Drawing.Point(356, 204);
            this.textBox_totalReceived.Name = "textBox_totalReceived";
            this.textBox_totalReceived.ReadOnly = true;
            this.textBox_totalReceived.Size = new System.Drawing.Size(100, 20);
            this.textBox_totalReceived.TabIndex = 4;
            // 
            // textBox_totalBalance
            // 
            this.textBox_totalBalance.Location = new System.Drawing.Point(253, 259);
            this.textBox_totalBalance.Name = "textBox_totalBalance";
            this.textBox_totalBalance.ReadOnly = true;
            this.textBox_totalBalance.Size = new System.Drawing.Size(100, 20);
            this.textBox_totalBalance.TabIndex = 5;
            // 
            // comboBox_fromMonth
            // 
            this.comboBox_fromMonth.FormattingEnabled = true;
            this.comboBox_fromMonth.Location = new System.Drawing.Point(140, 25);
            this.comboBox_fromMonth.Name = "comboBox_fromMonth";
            this.comboBox_fromMonth.Size = new System.Drawing.Size(121, 21);
            this.comboBox_fromMonth.TabIndex = 6;
            // 
            // comboBox_fromYear
            // 
            this.comboBox_fromYear.FormattingEnabled = true;
            this.comboBox_fromYear.Location = new System.Drawing.Point(298, 25);
            this.comboBox_fromYear.Name = "comboBox_fromYear";
            this.comboBox_fromYear.Size = new System.Drawing.Size(121, 21);
            this.comboBox_fromYear.TabIndex = 7;
            // 
            // comboBox_toYear
            // 
            this.comboBox_toYear.FormattingEnabled = true;
            this.comboBox_toYear.Location = new System.Drawing.Point(298, 88);
            this.comboBox_toYear.Name = "comboBox_toYear";
            this.comboBox_toYear.Size = new System.Drawing.Size(121, 21);
            this.comboBox_toYear.TabIndex = 9;
            // 
            // comboBox_toMonth
            // 
            this.comboBox_toMonth.FormattingEnabled = true;
            this.comboBox_toMonth.Location = new System.Drawing.Point(140, 88);
            this.comboBox_toMonth.Name = "comboBox_toMonth";
            this.comboBox_toMonth.Size = new System.Drawing.Size(121, 21);
            this.comboBox_toMonth.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "From";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "To";
            // 
            // button_fetchEarnings
            // 
            this.button_fetchEarnings.Location = new System.Drawing.Point(237, 138);
            this.button_fetchEarnings.Name = "button_fetchEarnings";
            this.button_fetchEarnings.Size = new System.Drawing.Size(75, 23);
            this.button_fetchEarnings.TabIndex = 12;
            this.button_fetchEarnings.Text = "Get";
            this.button_fetchEarnings.UseVisualStyleBackColor = true;
            this.button_fetchEarnings.Click += new System.EventHandler(this.button_fetchEarnings_Click);
            // 
            // Earnings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 440);
            this.Controls.Add(this.button_fetchEarnings);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_toYear);
            this.Controls.Add(this.comboBox_toMonth);
            this.Controls.Add(this.comboBox_fromYear);
            this.Controls.Add(this.comboBox_fromMonth);
            this.Controls.Add(this.textBox_totalBalance);
            this.Controls.Add(this.textBox_totalReceived);
            this.Controls.Add(this.textBox_totalBills);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Earnings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Earnings";
            this.Load += new System.EventHandler(this.Earnings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_totalBills;
        private System.Windows.Forms.TextBox textBox_totalReceived;
        private System.Windows.Forms.TextBox textBox_totalBalance;
        private System.Windows.Forms.ComboBox comboBox_fromMonth;
        private System.Windows.Forms.ComboBox comboBox_fromYear;
        private System.Windows.Forms.ComboBox comboBox_toYear;
        private System.Windows.Forms.ComboBox comboBox_toMonth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_fetchEarnings;
    }
}