namespace KanakTiffins
{
    partial class ExportBills
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
            this.radioButton_All = new System.Windows.Forms.RadioButton();
            this.radioButton_specificArea = new System.Windows.Forms.RadioButton();
            this.comboBox_specificArea = new System.Windows.Forms.ComboBox();
            this.button_export = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // radioButton_All
            // 
            this.radioButton_All.AutoSize = true;
            this.radioButton_All.Checked = true;
            this.radioButton_All.Location = new System.Drawing.Point(13, 13);
            this.radioButton_All.Name = "radioButton_All";
            this.radioButton_All.Size = new System.Drawing.Size(36, 17);
            this.radioButton_All.TabIndex = 0;
            this.radioButton_All.TabStop = true;
            this.radioButton_All.Text = "All";
            this.radioButton_All.UseVisualStyleBackColor = true;
            this.radioButton_All.CheckedChanged += new System.EventHandler(this.radioButton_All_CheckedChanged);
            // 
            // radioButton_specificArea
            // 
            this.radioButton_specificArea.AutoSize = true;
            this.radioButton_specificArea.Location = new System.Drawing.Point(13, 36);
            this.radioButton_specificArea.Name = "radioButton_specificArea";
            this.radioButton_specificArea.Size = new System.Drawing.Size(86, 17);
            this.radioButton_specificArea.TabIndex = 1;
            this.radioButton_specificArea.Text = "Select Area: ";
            this.radioButton_specificArea.UseVisualStyleBackColor = true;
            this.radioButton_specificArea.CheckedChanged += new System.EventHandler(this.radioButton_specificArea_CheckedChanged);
            // 
            // comboBox_specificArea
            // 
            this.comboBox_specificArea.FormattingEnabled = true;
            this.comboBox_specificArea.Location = new System.Drawing.Point(95, 36);
            this.comboBox_specificArea.Name = "comboBox_specificArea";
            this.comboBox_specificArea.Size = new System.Drawing.Size(121, 21);
            this.comboBox_specificArea.TabIndex = 2;
            this.comboBox_specificArea.Visible = false;
            // 
            // button_export
            // 
            this.button_export.Location = new System.Drawing.Point(73, 64);
            this.button_export.Name = "button_export";
            this.button_export.Size = new System.Drawing.Size(75, 23);
            this.button_export.TabIndex = 3;
            this.button_export.Text = "Export";
            this.button_export.UseVisualStyleBackColor = true;
            this.button_export.Click += new System.EventHandler(this.button_export_Click);
            // 
            // ExportBills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 93);
            this.Controls.Add(this.button_export);
            this.Controls.Add(this.comboBox_specificArea);
            this.Controls.Add(this.radioButton_specificArea);
            this.Controls.Add(this.radioButton_All);
            this.Name = "ExportBills";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Area";
            this.Load += new System.EventHandler(this.PrintBills_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton_All;
        private System.Windows.Forms.RadioButton radioButton_specificArea;
        private System.Windows.Forms.ComboBox comboBox_specificArea;
        private System.Windows.Forms.Button button_export;
    }
}