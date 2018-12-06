namespace TipTrackerController
{
    partial class Form1
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
            this.insertIncome = new System.Windows.Forms.Button();
            this.tb_hourlyIncome = new System.Windows.Forms.TextBox();
            this.tb_hourlyWage = new System.Windows.Forms.TextBox();
            this.tb_hoursWorked = new System.Windows.Forms.TextBox();
            this.tb_tipsEarned = new System.Windows.Forms.TextBox();
            this.tb_dateOfIncome = new System.Windows.Forms.TextBox();
            this.dateOfIncome = new System.Windows.Forms.Label();
            this.tipsEarned = new System.Windows.Forms.Label();
            this.hoursWorked = new System.Windows.Forms.Label();
            this.hourlyWage = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // insertIncome
            // 
            this.insertIncome.Location = new System.Drawing.Point(117, 332);
            this.insertIncome.Name = "insertIncome";
            this.insertIncome.Size = new System.Drawing.Size(169, 38);
            this.insertIncome.TabIndex = 0;
            this.insertIncome.Text = "Insert Income ";
            this.insertIncome.UseVisualStyleBackColor = true;
            // 
            // tb_hourlyIncome
            // 
            this.tb_hourlyIncome.Location = new System.Drawing.Point(129, 273);
            this.tb_hourlyIncome.Name = "tb_hourlyIncome";
            this.tb_hourlyIncome.Size = new System.Drawing.Size(100, 20);
            this.tb_hourlyIncome.TabIndex = 1;
            // 
            // tb_hourlyWage
            // 
            this.tb_hourlyWage.Location = new System.Drawing.Point(129, 226);
            this.tb_hourlyWage.Name = "tb_hourlyWage";
            this.tb_hourlyWage.ReadOnly = true;
            this.tb_hourlyWage.Size = new System.Drawing.Size(100, 20);
            this.tb_hourlyWage.TabIndex = 2;
            // 
            // tb_hoursWorked
            // 
            this.tb_hoursWorked.Location = new System.Drawing.Point(129, 173);
            this.tb_hoursWorked.Name = "tb_hoursWorked";
            this.tb_hoursWorked.ReadOnly = true;
            this.tb_hoursWorked.Size = new System.Drawing.Size(100, 20);
            this.tb_hoursWorked.TabIndex = 3;
            this.tb_hoursWorked.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // tb_tipsEarned
            // 
            this.tb_tipsEarned.Location = new System.Drawing.Point(129, 114);
            this.tb_tipsEarned.Name = "tb_tipsEarned";
            this.tb_tipsEarned.ReadOnly = true;
            this.tb_tipsEarned.Size = new System.Drawing.Size(100, 20);
            this.tb_tipsEarned.TabIndex = 4;
            // 
            // tb_dateOfIncome
            // 
            this.tb_dateOfIncome.Location = new System.Drawing.Point(129, 61);
            this.tb_dateOfIncome.Name = "tb_dateOfIncome";
            this.tb_dateOfIncome.ReadOnly = true;
            this.tb_dateOfIncome.Size = new System.Drawing.Size(100, 20);
            this.tb_dateOfIncome.TabIndex = 5;
            this.tb_dateOfIncome.TextChanged += new System.EventHandler(this.tb_dateOfIncome_TextChanged);
            // 
            // dateOfIncome
            // 
            this.dateOfIncome.AutoSize = true;
            this.dateOfIncome.Location = new System.Drawing.Point(25, 64);
            this.dateOfIncome.Name = "dateOfIncome";
            this.dateOfIncome.Size = new System.Drawing.Size(82, 13);
            this.dateOfIncome.TabIndex = 6;
            this.dateOfIncome.Text = "Date Of Income";
            this.dateOfIncome.Click += new System.EventHandler(this.label1_Click);
            // 
            // tipsEarned
            // 
            this.tipsEarned.AutoSize = true;
            this.tipsEarned.Location = new System.Drawing.Point(25, 114);
            this.tipsEarned.Name = "tipsEarned";
            this.tipsEarned.Size = new System.Drawing.Size(64, 13);
            this.tipsEarned.TabIndex = 7;
            this.tipsEarned.Text = "Tips Earned";
            // 
            // hoursWorked
            // 
            this.hoursWorked.AutoSize = true;
            this.hoursWorked.Location = new System.Drawing.Point(25, 173);
            this.hoursWorked.Name = "hoursWorked";
            this.hoursWorked.Size = new System.Drawing.Size(76, 13);
            this.hoursWorked.TabIndex = 8;
            this.hoursWorked.Text = "Hours Worked";
            // 
            // hourlyWage
            // 
            this.hourlyWage.AutoSize = true;
            this.hourlyWage.Location = new System.Drawing.Point(25, 226);
            this.hourlyWage.Name = "hourlyWage";
            this.hourlyWage.Size = new System.Drawing.Size(69, 13);
            this.hourlyWage.TabIndex = 9;
            this.hourlyWage.Text = "Hourly Wage";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Hourly Income";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 382);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.hourlyWage);
            this.Controls.Add(this.hoursWorked);
            this.Controls.Add(this.tipsEarned);
            this.Controls.Add(this.dateOfIncome);
            this.Controls.Add(this.tb_dateOfIncome);
            this.Controls.Add(this.tb_tipsEarned);
            this.Controls.Add(this.tb_hoursWorked);
            this.Controls.Add(this.tb_hourlyWage);
            this.Controls.Add(this.tb_hourlyIncome);
            this.Controls.Add(this.insertIncome);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button insertIncome;
        private System.Windows.Forms.TextBox tb_hourlyIncome;
        private System.Windows.Forms.TextBox tb_hourlyWage;
        private System.Windows.Forms.TextBox tb_hoursWorked;
        private System.Windows.Forms.TextBox tb_tipsEarned;
        private System.Windows.Forms.TextBox tb_dateOfIncome;
        private System.Windows.Forms.Label dateOfIncome;
        private System.Windows.Forms.Label tipsEarned;
        private System.Windows.Forms.Label hoursWorked;
        private System.Windows.Forms.Label hourlyWage;
        private System.Windows.Forms.Label label4;
    }
}

