namespace Project
{
    partial class EmployeesForm
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
            this.txtId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbTitle = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.radMr = new System.Windows.Forms.RadioButton();
            this.radMrs = new System.Windows.Forms.RadioButton();
            this.radMs = new System.Windows.Forms.RadioButton();
            this.radDr = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpBirthdate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpHiredate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbCity = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbRegion = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbManager = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employees Management";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID";
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(101, 54);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Last Name";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(101, 94);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(212, 20);
            this.txtLastName.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "First Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(101, 135);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(212, 20);
            this.txtFirstName.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Title";
            // 
            // cbTitle
            // 
            this.cbTitle.FormattingEnabled = true;
            this.cbTitle.Location = new System.Drawing.Point(101, 175);
            this.cbTitle.Name = "cbTitle";
            this.cbTitle.Size = new System.Drawing.Size(212, 21);
            this.cbTitle.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Courtesy";
            // 
            // radMr
            // 
            this.radMr.AutoSize = true;
            this.radMr.Location = new System.Drawing.Point(6, 15);
            this.radMr.Name = "radMr";
            this.radMr.Size = new System.Drawing.Size(37, 17);
            this.radMr.TabIndex = 10;
            this.radMr.TabStop = true;
            this.radMr.Text = "Mr";
            this.radMr.UseVisualStyleBackColor = true;
            // 
            // radMrs
            // 
            this.radMrs.AutoSize = true;
            this.radMrs.Location = new System.Drawing.Point(49, 15);
            this.radMrs.Name = "radMrs";
            this.radMrs.Size = new System.Drawing.Size(42, 17);
            this.radMrs.TabIndex = 11;
            this.radMrs.TabStop = true;
            this.radMrs.Text = "Mrs";
            this.radMrs.UseVisualStyleBackColor = true;
            // 
            // radMs
            // 
            this.radMs.AutoSize = true;
            this.radMs.Location = new System.Drawing.Point(139, 15);
            this.radMs.Name = "radMs";
            this.radMs.Size = new System.Drawing.Size(39, 17);
            this.radMs.TabIndex = 12;
            this.radMs.TabStop = true;
            this.radMs.Text = "Ms";
            this.radMs.UseVisualStyleBackColor = true;
            // 
            // radDr
            // 
            this.radDr.AutoSize = true;
            this.radDr.Location = new System.Drawing.Point(97, 15);
            this.radDr.Name = "radDr";
            this.radDr.Size = new System.Drawing.Size(36, 17);
            this.radDr.TabIndex = 13;
            this.radDr.TabStop = true;
            this.radDr.Text = "Dr";
            this.radDr.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radMr);
            this.groupBox1.Controls.Add(this.radMs);
            this.groupBox1.Controls.Add(this.radDr);
            this.groupBox1.Controls.Add(this.radMrs);
            this.groupBox1.Location = new System.Drawing.Point(101, 202);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 39);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(346, 261);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(607, 466);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 261);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Birthdate";
            // 
            // dtpBirthdate
            // 
            this.dtpBirthdate.CustomFormat = "";
            this.dtpBirthdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthdate.Location = new System.Drawing.Point(101, 261);
            this.dtpBirthdate.Name = "dtpBirthdate";
            this.dtpBirthdate.Size = new System.Drawing.Size(200, 20);
            this.dtpBirthdate.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 308);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Hiredate";
            // 
            // dtpHiredate
            // 
            this.dtpHiredate.CustomFormat = "";
            this.dtpHiredate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHiredate.Location = new System.Drawing.Point(101, 302);
            this.dtpHiredate.Name = "dtpHiredate";
            this.dtpHiredate.Size = new System.Drawing.Size(200, 20);
            this.dtpHiredate.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 352);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Address";
            // 
            // txtaddress
            // 
            this.txtaddress.Location = new System.Drawing.Point(101, 349);
            this.txtaddress.Multiline = true;
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(212, 81);
            this.txtaddress.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 452);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "City";
            // 
            // cbCity
            // 
            this.cbCity.FormattingEnabled = true;
            this.cbCity.Location = new System.Drawing.Point(101, 449);
            this.cbCity.Name = "cbCity";
            this.cbCity.Size = new System.Drawing.Size(212, 21);
            this.cbCity.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 491);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Region";
            // 
            // cbRegion
            // 
            this.cbRegion.FormattingEnabled = true;
            this.cbRegion.Location = new System.Drawing.Point(101, 488);
            this.cbRegion.Name = "cbRegion";
            this.cbRegion.Size = new System.Drawing.Size(212, 21);
            this.cbRegion.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 529);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Postal Code";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(101, 526);
            this.maskedTextBox1.Mask = "00000-9999";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox1.TabIndex = 27;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 565);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "Country";
            // 
            // cbCountry
            // 
            this.cbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Location = new System.Drawing.Point(101, 562);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(212, 21);
            this.cbCountry.TabIndex = 29;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 604);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 13);
            this.label14.TabIndex = 30;
            this.label14.Text = "Phone";
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Location = new System.Drawing.Point(101, 601);
            this.maskedTextBox2.Mask = "(+900) 000-000-0009";
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(149, 20);
            this.maskedTextBox2.TabIndex = 31;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(19, 645);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 13);
            this.label15.TabIndex = 32;
            this.label15.Text = "Manager";
            // 
            // cbManager
            // 
            this.cbManager.FormattingEnabled = true;
            this.cbManager.Location = new System.Drawing.Point(101, 642);
            this.cbManager.Name = "cbManager";
            this.cbManager.Size = new System.Drawing.Size(212, 21);
            this.cbManager.TabIndex = 33;
            // 
            // EmployeesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 739);
            this.Controls.Add(this.cbManager);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.maskedTextBox2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cbCountry);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cbRegion);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbCity);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtaddress);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtpHiredate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpBirthdate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbTitle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EmployeesForm";
            this.Text = "Employees";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbTitle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radMr;
        private System.Windows.Forms.RadioButton radMrs;
        private System.Windows.Forms.RadioButton radMs;
        private System.Windows.Forms.RadioButton radDr;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpBirthdate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpHiredate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbCity;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbRegion;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbCountry;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbManager;
    }
}