namespace Project
{
    partial class SearchForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.productid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discontinued = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productid,
            this.productname,
            this.supplierid,
            this.categoryid,
            this.unitprice,
            this.discontinued});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(649, 349);
            this.dataGridView1.TabIndex = 0;
            // 
            // productid
            // 
            this.productid.HeaderText = "ID";
            this.productid.Name = "productid";
            // 
            // productname
            // 
            this.productname.HeaderText = "Name";
            this.productname.Name = "productname";
            // 
            // supplierid
            // 
            this.supplierid.HeaderText = "Supplier ID";
            this.supplierid.Name = "supplierid";
            // 
            // categoryid
            // 
            this.categoryid.HeaderText = "Category ID";
            this.categoryid.Name = "categoryid";
            // 
            // unitprice
            // 
            this.unitprice.HeaderText = "Price";
            this.unitprice.Name = "unitprice";
            // 
            // discontinued
            // 
            this.discontinued.HeaderText = "Discontinued";
            this.discontinued.Name = "discontinued";
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 373);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn productid;
        private System.Windows.Forms.DataGridViewTextBoxColumn productname;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierid;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryid;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn discontinued;
    }
}