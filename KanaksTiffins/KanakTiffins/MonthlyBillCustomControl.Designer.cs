namespace KanakTiffins
{
    partial class MonthlyBillCustomControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView_monthlyBill = new System.Windows.Forms.DataGridView();
            this.label_month = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_monthlyConsumption = new System.Windows.Forms.Label();
            this.label_dailyPayments = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_payableAmount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_monthlyBill)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_monthlyBill
            // 
            this.dataGridView_monthlyBill.AllowUserToAddRows = false;
            this.dataGridView_monthlyBill.AllowUserToDeleteRows = false;
            this.dataGridView_monthlyBill.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView_monthlyBill.CausesValidation = false;
            this.dataGridView_monthlyBill.Location = new System.Drawing.Point(3, 39);
            this.dataGridView_monthlyBill.Name = "dataGridView_monthlyBill";
            this.dataGridView_monthlyBill.ReadOnly = true;
            this.dataGridView_monthlyBill.RowHeadersVisible = false;
            this.dataGridView_monthlyBill.Size = new System.Drawing.Size(520, 370);
            this.dataGridView_monthlyBill.TabIndex = 0;
            // 
            // label_month
            // 
            this.label_month.AutoSize = true;
            this.label_month.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_month.ForeColor = System.Drawing.Color.Blue;
            this.label_month.Location = new System.Drawing.Point(200, 11);
            this.label_month.Name = "label_month";
            this.label_month.Size = new System.Drawing.Size(41, 13);
            this.label_month.TabIndex = 1;
            this.label_month.Text = "label1";
            this.label_month.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(144, 411);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "This month\'s bill:    Rs. ";
            // 
            // label_monthlyConsumption
            // 
            this.label_monthlyConsumption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_monthlyConsumption.ForeColor = System.Drawing.Color.Red;
            this.label_monthlyConsumption.Location = new System.Drawing.Point(297, 411);
            this.label_monthlyConsumption.Name = "label_monthlyConsumption";
            this.label_monthlyConsumption.Size = new System.Drawing.Size(50, 13);
            this.label_monthlyConsumption.TabIndex = 4;
            this.label_monthlyConsumption.Text = "label2";
            this.label_monthlyConsumption.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_dailyPayments
            // 
            this.label_dailyPayments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_dailyPayments.ForeColor = System.Drawing.Color.Green;
            this.label_dailyPayments.Location = new System.Drawing.Point(297, 437);
            this.label_dailyPayments.Name = "label_dailyPayments";
            this.label_dailyPayments.Size = new System.Drawing.Size(50, 13);
            this.label_dailyPayments.TabIndex = 6;
            this.label_dailyPayments.Text = "label2";
            this.label_dailyPayments.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(119, 437);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Payments this month:    Rs. ";
            // 
            // label_payableAmount
            // 
            this.label_payableAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_payableAmount.Location = new System.Drawing.Point(297, 460);
            this.label_payableAmount.Name = "label_payableAmount";
            this.label_payableAmount.Size = new System.Drawing.Size(50, 13);
            this.label_payableAmount.TabIndex = 8;
            this.label_payableAmount.Text = "label2";
            this.label_payableAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(145, 460);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Payable amount:    Rs. ";
            // 
            // MonthlyBillCustomControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label_payableAmount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label_dailyPayments);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_monthlyConsumption);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_month);
            this.Controls.Add(this.dataGridView_monthlyBill);
            this.DoubleBuffered = true;
            this.Name = "MonthlyBillCustomControl";
            this.Size = new System.Drawing.Size(526, 479);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_monthlyBill)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_monthlyBill;
        private System.Windows.Forms.Label label_month;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_monthlyConsumption;
        private System.Windows.Forms.Label label_dailyPayments;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_payableAmount;
        private System.Windows.Forms.Label label5;
    }
}
