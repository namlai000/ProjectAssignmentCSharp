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
    public partial class FormSuppler : Form
    {
        TSQLFundamentals2008Entities Entity = new TSQLFundamentals2008Entities();
        public FormSuppler()
        {
            InitializeComponent();
            loadsup();
        }
        void loadsup()
        {
            
            foreach(Supplier sp in Entity.Suppliers){
                if (sp.region == null)
                {
                    sp.region = "";
                }
                if (sp.fax == null)
                {
                    sp.fax = "";
                }
            }
            dataGridView1.DataSource = Entity.Suppliers.ToList();

        }
        void add()
        {
            
            Entity.SaveChanges();
        }
        bool validateInput()
        {
            string name = txtAddress.Text.Trim();
            string contname = txtContactName.Text.Trim();
            string title = txtTitle.Text.Trim();
            string city = txtCity.Text.Trim();
            string address = txtAddress.Text.Trim();
            string region = txtRegion.Text.Trim();
            string code = txtPostalCode.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string country = txtCountry.Text.Trim();
            string fax = txtFax.Text.Trim();
            bool bError = false;
            if (name.Length == 0)
            {
                bError = true;
            }
            if (contname.Length == 0)
            {
                bError = true;
            }
            if (title.Length == 0)
            {
                bError = true;
            }
            if (city.Length == 0)
            {
                bError = true;
            }
            if (address.Length == 0)
            {
                bError = true;
            }
            if (region.Length == 0)
            {
                bError = true;
            }
            if (code.Length == 0)
            {
                bError = true;
            }
            if (phone.Length == 0)
            {
                bError = true;
            }
            if (country.Length == 0)
            {
                bError = true;
            }
            if (fax.Length == 0)
            {
                bError = true;
            }
            if (bError == true)
            {
                return false;
            } else errorProvider1.Clear();
            return true;
        }
        
        void update()
        {
            DataGridViewRow r = dataGridView1.SelectedRows[0];
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (validateInput() == false)
            {
                return;
            }
            else try
                {
                    add();
                    loadsup();
                    MessageBox.Show("Added successfully!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                btnAdd.Enabled = false;

                DataGridViewRow r = dataGridView1.SelectedRows[0];
                lblID.Text = r.Cells["supplierid"].Value.ToString();
                txtName.Text = r.Cells["companyname"].Value.ToString();
                txtContactName.Text = r.Cells["contactname"].Value.ToString();
                txtAddress.Text = r.Cells["address"].Value.ToString();
                txtCity.Text = r.Cells["city"].Value.ToString();
                txtFax.Text = r.Cells["fax"].Value.ToString();
                txtPhone.Text = r.Cells["phone"].Value.ToString();
                txtPostalCode.Text = r.Cells["postalcode"].Value.ToString();
                txtRegion.Text = r.Cells["region"].Value.ToString();
                txtTitle.Text = r.Cells["contacttitle"].Value.ToString();
                txtCountry.Text = r.Cells["country"].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (validateInput() == false) return;
            try
            {
                update();
                MessageBox.Show("Update Successful!");

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = dataGridView1.SelectedRows[0];
            Supplier sup = null;

            foreach(Supplier s in Entity.Suppliers)
            {
                if (s.supplierid== (int)r.Cells[0].Value)

                {
                    sup = s;
                    break;
                }
            }

            Entity.Suppliers.Remove(sup);

            Entity.SaveChanges();
        }
        void SearchByName()
        {
            FormSearchResultSuppliers frm = new FormSearchResultSuppliers();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow r = dataGridView1.Rows[i];
                if (r.Cells[1].Value.ToString().Contains(txtSearchName.Text))
                {
                    frm.addCategoryInfo(r.Cells[0].Value.ToString(),
                        r.Cells[1].Value.ToString(),
                        r.Cells[2].Value.ToString(),
                        r.Cells[3].Value.ToString(),
                        r.Cells[4].Value.ToString(),
                        r.Cells[5].Value.ToString(),
                        r.Cells[6].Value.ToString(),
                        r.Cells[7].Value.ToString(),
                        r.Cells[8].Value.ToString(),
                        r.Cells[9].Value.ToString(),
                        r.Cells[10].Value.ToString());
                }
            }
            frm.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchByName();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            dataGridView1.ClearSelection();
            lblID.ResetText();
            txtAddress.ResetText();
            txtCity.ResetText();
            txtContactName.ResetText();
            txtCountry.ResetText();
            txtFax.ResetText();
            txtName.ResetText();
            txtPhone.ResetText();
            txtPostalCode.ResetText();
            txtRegion.ResetText();
            txtTitle.ResetText();
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void FormSuppler_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainProgram Parent = (MainProgram)this.MdiParent;
            Parent.supForm = null;
        }
    }
}
