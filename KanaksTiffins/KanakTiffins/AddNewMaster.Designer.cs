namespace KanakTiffins
{
    partial class AddNewMaster
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
            this.textBox_addNewMaster = new System.Windows.Forms.TextBox();
            this.label_whichMaster = new System.Windows.Forms.Label();
            this.button_addNewArea = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_addNewMaster
            // 
            this.textBox_addNewMaster.Location = new System.Drawing.Point(96, 33);
            this.textBox_addNewMaster.Name = "textBox_addNewMaster";
            this.textBox_addNewMaster.Size = new System.Drawing.Size(100, 20);
            this.textBox_addNewMaster.TabIndex = 0;
            // 
            // label_whichMaster
            // 
            this.label_whichMaster.AutoSize = true;
            this.label_whichMaster.Location = new System.Drawing.Point(12, 36);
            this.label_whichMaster.Name = "label_whichMaster";
            this.label_whichMaster.Size = new System.Drawing.Size(0, 13);
            this.label_whichMaster.TabIndex = 1;
            // 
            // button_addNewArea
            // 
            this.button_addNewArea.Location = new System.Drawing.Point(79, 76);
            this.button_addNewArea.Name = "button_addNewArea";
            this.button_addNewArea.Size = new System.Drawing.Size(75, 23);
            this.button_addNewArea.TabIndex = 2;
            this.button_addNewArea.Text = "Submit";
            this.button_addNewArea.UseVisualStyleBackColor = true;
            this.button_addNewArea.Click += new System.EventHandler(this.button_addNewArea_Click);
            // 
            // AddNewMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 121);
            this.Controls.Add(this.button_addNewArea);
            this.Controls.Add(this.label_whichMaster);
            this.Controls.Add(this.textBox_addNewMaster);
            this.Name = "AddNewMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddNewMaster";
            this.Load += new System.EventHandler(this.AddNewMaster_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_addNewMaster;
        private System.Windows.Forms.Label label_whichMaster;
        private System.Windows.Forms.Button button_addNewArea;
    }
}