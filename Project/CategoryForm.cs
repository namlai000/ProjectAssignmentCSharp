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
    public partial class CategoryForm : Form
    {
        TSQLFundamentals2008Entities entity = new TSQLFundamentals2008Entities();
        public CategoryForm()
        {
            InitializeComponent();
            loadCategoryID();
            loadData();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
        void loadCategoryID()
        {
            cbCategoryID.DataSource = entity.Categories.ToList();
            cbCategoryID.DisplayMember = "CategoryID";
        }
        void loadData()
        {
            dgvCategory.DataSource = entity.Categories.ToList();
            //dgvOrderDetails.DataSource = entity.OrderDetails.ToList();
            //dgvOrderDetails.Columns["Product"].Visible = false;
            //dgvOrderDetails.Columns["Order"].Visible = false;

        }
        void Add()
        {
            Category category = new Category();
            category.categoryname = txtCategoryName.Text;
            category.description = txtDescription.Text;
            entity.Categories.Add(category);
            entity.SaveChanges();
        }
        void Update()
        {
            DataGridViewRow r = dgvCategory.SelectedRows[0];
            Category tmp = null;
            foreach (Category tmp1 in entity.Categories)
            {
                if (tmp1.categoryid == int.Parse(r.Cells[0].Value.ToString()))
                {
                    tmp = tmp1;
                    break;
                }
            }
            tmp.categoryid = int.Parse(cbCategoryID.Text);
            tmp.categoryname = txtCategoryName.Text;
            tmp.description = txtDescription.Text;
            entity.SaveChanges();
        }
        void ResetAll()
        {
            cbCategoryID.Text = "";
            txtDescription.Text = "";
            txtCategoryName.Text = "";
            txtSearch.Text = "";
        }
        void delete()
        {
            DataGridViewRow r = dgvCategory.SelectedRows[0];
            Category tmp = null;
            foreach (Category tmp1 in entity.Categories)
            {
                if (tmp1.categoryid == int.Parse(r.Cells[0].Value.ToString()))
                {
                    tmp = tmp1;
                    break;
                }
            }
            entity.Categories.Remove(tmp);
            entity.SaveChanges();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add();
            loadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Update();
            loadData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetAll();
            loadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                delete();
                loadData();
            }
            catch (Exception)
            {
                MessageBox.Show("this Category is being used! can not delete");
            }
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = dgvCategory.SelectedRows[0];
            cbCategoryID.Text = r.Cells[0].Value.ToString();
            txtCategoryName.Text = r.Cells[1].Value.ToString();
            txtDescription.Text = r.Cells[2].Value.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            List<Category> list = entity.Database.SqlQuery<Category>("SELECT * FROM Production.Categories WHERE categoryname LIKE '%" + txtSearch.Text + "%'").ToList();
            dgvCategory.DataSource = list;
        }

        private void CategoryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainProgram main = (MainProgram)this.MdiParent;
            main.catForm = null;
        }
    }
}
