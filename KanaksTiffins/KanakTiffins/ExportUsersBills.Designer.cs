namespace KanakTiffins
{
    partial class ExportUsersBills
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
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox_fromMonth = new System.Windows.Forms.ComboBox();
            this.comboBox_fromYear = new System.Windows.Forms.ComboBox();
            this.comboBox_toYear = new System.Windows.Forms.ComboBox();
            this.comboBox_toMonth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(85, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Export";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox_fromMonth
            // 
            this.comboBox_fromMonth.FormattingEnabled = true;
            this.comboBox_fromMonth.Location = new System.Drawing.Point(48, 12);
            this.comboBox_fromMonth.Name = "comboBox_fromMonth";
            this.comboBox_fromMonth.Size = new System.Drawing.Size(121, 21);
            this.comboBox_fromMonth.TabIndex = 5;
            // 
            // comboBox_fromYear
            // 
            this.comboBox_fromYear.FormattingEnabled = true;
            this.comboBox_fromYear.Location = new System.Drawing.Point(175, 12);
            this.comboBox_fromYear.Name = "comboBox_fromYear";
            this.comboBox_fromYear.Size = new System.Drawing.Size(66, 21);
            this.comboBox_fromYear.TabIndex = 6;
            // 
            // comboBox_toYear
            // 
            this.comboBox_toYear.FormattingEnabled = true;
            this.comboBox_toYear.Location = new System.Drawing.Point(175, 40);
            this.comboBox_toYear.Name = "comboBox_toYear";
            this.comboBox_toYear.Size = new System.Drawing.Size(66, 21);
            this.comboBox_toYear.TabIndex = 8;
            // 
            // comboBox_toMonth
            // 
            this.comboBox_toMonth.FormattingEnabled = true;
            this.comboBox_toMonth.Location = new System.Drawing.Point(48, 40);
            this.comboBox_toMonth.Name = "comboBox_toMonth";
            this.comboBox_toMonth.Size = new System.Drawing.Size(121, 21);
            this.comboBox_toMonth.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "To";
            // 
            // ExportUsersBills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 96);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_toYear);
            this.Controls.Add(this.comboBox_toMonth);
            this.Controls.Add(this.comboBox_fromYear);
            this.Controls.Add(this.comboBox_fromMonth);
            this.Controls.Add(this.button1);
            this.Name = "ExportUsersBills";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Range";
            this.Load += new System.EventHandler(this.ExportUsersBills_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox_fromMonth;
        private System.Windows.Forms.ComboBox comboBox_fromYear;
        private System.Windows.Forms.ComboBox comboBox_toYear;
        private System.Windows.Forms.ComboBox comboBox_toMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}