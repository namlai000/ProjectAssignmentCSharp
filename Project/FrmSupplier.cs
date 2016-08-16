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
    public partial class FrmSupplier : Form
    {
        TSQLFundamentals2008Entities Entity = new TSQLFundamentals2008Entities();
        public FrmSupplier()
        {
            InitializeComponent();
            loadsup();
        }
        void loadsup()
        {
            dataGridView1.DataSource = Entity.Suppliers.ToList();
        }
        void add()
        {
            Supplier sup = new Supplier();
            sup.address = txtAddress.Text;
            sup.city = txtCity.Text;
            sup.companyname = txtCity.Text;
            sup.contactname = txtContactName.Text;
            sup.contacttitle = txtTitle.Text;
            sup.country = txtTitle.Text;
            sup.fax = txtFax.Text;
            sup.phone = mtxtPhone.Text;
            sup.postalcode = txtPostalCode.Text;
            sup.region = txtRegion.Text;
            

            Entity.Suppliers.Add(sup);
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
            string phone = mtxtPhone.Text.Trim();
            string country = txtCountry.Text.Trim();
            string fax = txtFax.Text.Trim();
            bool bError = false;
            if (name.Length == 0)
            {
                errorProvider1.SetError(txtName, "Name cannot be empty!");
                bError = true;
            }
            if (contname.Length == 0)
            {
                errorProvider1.SetError(txtContactName,"Contact name cannot be empty!");
                bError = true;
            }
            if (title.Length == 0)
            {
                errorProvider1.SetError(txtTitle,"Title cannot be empty!");
                bError = true;
            }
            if (city.Length == 0)
            {
                errorProvider1.SetError(txtCity,"City cannot be empty!");
                bError = true;
            }
            if (address.Length == 0)
            {
                errorProvider1.SetError(txtAddress,"Address cannot be empty!");
                bError = true;
            }
            if (code.Length == 0)
            {
                errorProvider1.SetError(txtPostalCode,"Postal code cannot be empty!");
                bError = true;
            }
            if (phone.Length == 0)
            {
                errorProvider1.SetError(mtxtPhone,"Phone cannot be empty!");
                bError = true;
            }
            if (country.Length == 0)
            {
                errorProvider1.SetError(txtCountry,"Country cannot be empty!");
                bError = true;
            }
            
            if (bError == true)
            {
                return false;
            }
            else errorProvider1.Clear();
            return true;
        }

        void update()
        {
            DataGridViewRow r = dataGridView1.SelectedRows[0];
            Supplier sup = null;
            foreach (Supplier s in Entity.Suppliers)
            {
                if (s.supplierid == (int)r.Cells[0].Value)
                {
                    sup = s;
                    break;
                }
            }
            if (sup != null)
            {
                
                sup.address = txtAddress.Text;
                sup.city = txtCity.Text;
                sup.companyname = txtName.Text;
                sup.contactname = txtContactName.Text;
                sup.contacttitle = txtTitle.Text;
                sup.country = txtCountry.Text;
                sup.fax = txtFax.Text;
                sup.phone = mtxtPhone.Text;
                sup.postalcode = txtPostalCode.Text;
                sup.region = txtRegion.Text;
                Entity.SaveChanges();
                
            }
            
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
                if (r.Cells["region"].Value == null)
                {
                    txtRegion.Text = " ";
                }
                else
                {
                    txtRegion.Text = r.Cells["region"].Value.ToString();
                }
                if (r.Cells["fax"].Value == null)
                {
                    txtFax.Text = " ";
                }
                else
                {
                    txtFax.Text = r.Cells["fax"].Value.ToString();
                }
                if (r.Cells["postalcode"].Value == null)
                {
                    txtPostalCode.Text = " ";
                }
                else
                {
                    txtPostalCode.Text = r.Cells["postalcode"].Value.ToString();
                }
                //txtFax.Text = r.Cells["fax"].Value.ToString();
                mtxtPhone.Text = r.Cells["phone"].Value.ToString();
                //txtPostalCode.Text = r.Cells["postalcode"].Value.ToString();
                //txtRegion.Text = r.Cells["region"].Value.ToString();
                txtTitle.Text = r.Cells["contacttitle"].Value.ToString();
                txtCountry.Text = r.Cells["country"].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (validateInput() == false)
            { return; }
            
                update();
                loadsup();
                MessageBox.Show("Update Successful!");
            
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = dataGridView1.SelectedRows[0];
            Supplier sup = null;
            try
            {
                foreach (Supplier s in Entity.Suppliers)
                {
                    if (s.supplierid == (int)r.Cells[0].Value)
                    {
                        sup = s;
                        break;
                    }
                }

                Entity.Suppliers.Remove(sup);

                Entity.SaveChanges();
            }catch (Exception ){
                MessageBox.Show("Please delete the corresponding Product first!");
                Entity.Suppliers.Add(sup);
            }
            

        }
        void SearchByName()
        {
            FormSearchResultSuppliers frm = new FormSearchResultSuppliers();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow r = dataGridView1.Rows[i];
                if (r.Cells[1].Value.ToString().Equals(txtSearchName.Text))
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
            mtxtPhone.ResetText();
            txtPostalCode.ResetText();
            txtRegion.ResetText();
            txtTitle.ResetText();
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }
        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            // dtPro.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", ProductName, txtSearchName.Text);
        }

        private void txtRegion_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
