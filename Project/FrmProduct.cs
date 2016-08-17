using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class FrmProduct : Form
    {
        TSQLFundamentals2008Entities Entity = new TSQLFundamentals2008Entities();
        Supplier sp = new Supplier();
        Product pro = new Product();

        public FrmProduct()
        {
            InitializeComponent();
            cbSupplier.DataSource = Entity.Suppliers.ToList();
            cbSupplier.ValueMember = "supplierid";
            cbSupplier.DisplayMember = "companyname";
            cbCate.DataSource = Entity.Categories.ToList();
            cbCate.ValueMember = "categoryid";
            cbCate.DisplayMember = "categoryname";
            loadData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        bool validateInput()
        {
            string name = txtName.Text;
           
            if (name.Equals(""))
            {
                errorProvider1.SetError(txtName, "Please Input Product Name");
            }
            
            return true;
        }
        void addNewProduct()
        {
            Product pro = new Product();
            
            pro.productname = txtName.Text;
            int supplierid = int.Parse(cbSupplier.SelectedValue.ToString());
            pro.supplierid = supplierid;
            pro.categoryid = int.Parse(cbCate.SelectedValue.ToString());
            pro.unitprice = decimal.Parse(txtPrice.Text);
            if (chkDiscon.Checked)
            {
                pro.discontinued = true;
            }
            else pro.discontinued = false;
            Entity.Products.Add(pro);
            
            Entity.SaveChanges();
        }
        void loadData()
        {
            dataGridView1.DataSource = Entity.Products.ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                addNewProduct();
                MessageBox.Show("Add Successfull");
                loadData();
              
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void updateProduct()
        {
            string productid = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            int id = int.Parse(productid);
            int supplierid = int.Parse(cbSupplier.SelectedValue.ToString());
            Product pro = Entity.Products.Single(Product => Product.productid == id);
            pro.productname = txtName.Text;

            pro.supplierid = supplierid;
            pro.categoryid = int.Parse(cbCate.SelectedValue.ToString());

            pro.unitprice = decimal.Parse(txtPrice.Text);
            if (chkDiscon.Checked)
            {
                pro.discontinued = true;
            }
            else pro.discontinued = false;
            Entity.SaveChanges();
            loadData();
            MessageBox.Show("Update Successfull");

        }
        void deleteProduct()
        {
            DataGridViewRow r = dataGridView1.SelectedRows[0];
            if (dataGridView1.Rows.Count > 0)
            {
                Product pro = null;
                foreach (Product p in Entity.Products)
                {
                    if (p.productid == (int)r.Cells[0].Value)
                    {
                        pro = p;
                        break;
                    }
                }
                Entity.Products.Remove(pro);
                Entity.SaveChanges();
                loadData();
                MessageBox.Show("Delete Successfull");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateProduct();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteProduct();
        }
        void searchByName()
        {
            SearchForm sf = new SearchForm();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow r = dataGridView1.Rows[i];
                if(r.Cells[1].Value.ToString().Equals(txtSearch.Text))
                {
                    
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string sql=string.Format("Select * From Production.Products Where productname Like '%{0}%'",txtSearch.Text);
            List<Product> list = Entity.Database.SqlQuery<Product>(sql).ToList();
            dataGridView1.DataSource = list;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                DataGridViewRow r = dataGridView1.SelectedRows[0];
                lbID.Text = r.Cells[0].Value.ToString();
                cbSupplier.SelectedValue = int.Parse(r.Cells[2].Value.ToString());
                txtName.Text = r.Cells[1].Value.ToString();
                cbCate.SelectedValue = int.Parse(r.Cells[3].Value.ToString());
                txtPrice.Text = r.Cells[4].Value.ToString();
                if (r.Cells[5].Value.ToString().Equals("True"))
                {
                    chkDiscon.Checked = true;
                }
                else chkDiscon.Checked = false;

            }
        }

        private void FrmProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainProgram m = (MainProgram)this.MdiParent;
            m.productForm = null;
        }
    }
}
