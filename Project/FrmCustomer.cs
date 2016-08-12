using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Project
{
    public partial class FrmCustomer : Form
    {
        TSQLFundamentals2008Entities entity = new TSQLFundamentals2008Entities();
        public FrmCustomer()
        {
            InitializeComponent();
            foreach (Customer c in entity.Customers)
            {
                if (c.region == null)
                {
                    c.region = "";
                }
                if (c.fax == null)
                {
                    c.fax = "";
                }
            }
            loadTable();
            cbCountry.DataSource = getCountryList();
            loadCompName();
            loadtitle();

        }
        
        void loadTable()
        {
            dataGridView1.DataSource = entity.Customers.ToList();
        }
        void loadCompName()
        {
            cbCompanyName.DataSource = entity.Customers.ToList();
            cbCompanyName.DisplayMember = "companyname";
        }
        void loadtitle()
        {
            cbContactTitle.DataSource = entity.Customers.ToList().Select(cus => cus.contacttitle).Distinct().ToList();
            cbContactTitle.DisplayMember = "contacttitle";
        }
        public static List<String> getCountryList()
        {
            List<String> clist = new List<string>();
            CultureInfo[] getinfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo ci in getinfo)
            {
                RegionInfo getRInfo = new RegionInfo(ci.LCID);
                if (!(clist.Contains(getRInfo.EnglishName)))
                {
                    clist.Add(getRInfo.EnglishName);
                }
            }
            clist.Sort();
            return clist;
        }
        bool validateInput()
        {
            bool inputerr = false;
            if (txtContactName.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtContactName, "Contact name can't be empty");
                inputerr = true;
            }
            else if (txtContactName.Text.Trim().Length > 30)
            {
                errorProvider1.SetError(txtContactName, "Contact name must be less than 30 chracters");
                inputerr = true;
            }
            if (cbCompanyName.Text.Trim().Length > 40)
            {
                errorProvider1.SetError(cbCompanyName, "Company name must be less than 40 characters");
                inputerr = true;
            }
            if (cbContactTitle.Text.Trim().Length > 30)
            {
                errorProvider1.SetError(cbContactTitle, "Contact title must be less than 30 characters");
                inputerr = true;
            }
            if (txtAddress.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtAddress, "Customer address can't be empty");
                inputerr = true;
            }
            else if (txtAddress.Text.Trim().Length > 60)
            {
                errorProvider1.SetError(txtAddress, "address must be less than 60 characters");
                inputerr = true;
            }
            if (txtCity.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtCity, "City name cannot be empty");
                inputerr = true;
            }
            else if (txtCity.Text.Trim().Length > 15)
            {
                errorProvider1.SetError(txtCity, "City name must be less than 15 characters");
                inputerr = true;
            }
            if (txtRegion.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtRegion, "Enter customer region");
                inputerr = true;
            }
            else if (txtRegion.Text.Trim().Length > 15)
            {
                errorProvider1.SetError(txtRegion, "Region must be less than 15 characters");
                inputerr = true;
            }
            if (!mtxtPostalCode.MaskCompleted)
            {
                errorProvider1.SetError(mtxtPostalCode, "Please enter the postal code");
                inputerr = true;
            }
            if (txtPhone.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtPhone, "Please enter phone number");
                inputerr = true;
            } else if (txtPhone.Text.Trim().Length > 24)
            {
                errorProvider1.SetError(txtPhone, "Phone number must be less than 24 digits");
                inputerr = true;
            }
            if (txtFax.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtFax, "Please enter fax number");
                inputerr = true;
            }
            else if (txtFax.Text.Trim().Length > 24)
            {
                errorProvider1.SetError(txtFax, "fax number must be less than 24 digits");
                inputerr = true;
            }
            if (inputerr == true)
            {
                return false;

            }
            else
            {
                errorProvider1.Clear();
            }
            return true;
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dataGridView1.SelectedRows[0];
                cbCustID.Text = r.Cells[0].Value.ToString();
                cbCompanyName.Text = r.Cells[1].Value.ToString();
                txtContactName.Text = r.Cells[2].Value.ToString();
                cbContactTitle.Text = r.Cells[3].Value.ToString();
                txtAddress.Text = r.Cells[4].Value.ToString();
                txtCity.Text=r.Cells[5].Value.ToString();
                txtRegion.Text = r.Cells[6].Value.ToString();
                mtxtPostalCode.Text = r.Cells[7].Value.ToString();
                cbCountry.SelectedItem = r.Cells[8].Value;
                txtPhone.Text = r.Cells[9].Value.ToString();
                txtFax.Text = r.Cells[10].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (validateInput() == false)
            {
                return;
            }
            else
            {
                AddNewCustomer();
                loadTable();
                MessageBox.Show("Added successfully");
                ResetAll();
            }
        }

        void AddNewCustomer()
        {
            Customer c = new Customer();
            c.companyname = cbCompanyName.Text;
            c.contactname = txtContactName.Text;
            c.contacttitle = cbContactTitle.Text;
            c.address = txtAddress.Text;
            c.city = txtCity.Text;
            c.region = txtRegion.Text;
            c.country = cbCountry.Text;
            c.postalcode = mtxtPostalCode.Text;
            c.phone = txtPhone.Text;
            c.fax = txtFax.Text;
            entity.Customers.Add(c);
            entity.SaveChanges();
        }
        void ResetAll()
        {
            cbCompanyName.ResetText();
            txtContactName.ResetText();
            cbContactTitle.ResetText();
            txtAddress.ResetText();
            txtCity.ResetText();
            txtRegion.ResetText();
            mtxtPostalCode.ResetText();
            cbCountry.ResetText();
            txtPhone.ResetText();
            txtFax.ResetText();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveCustomer();
            loadTable();
            MessageBox.Show("Customer Removed");
        }
        void RemoveCustomer()
        {
            DataGridViewRow r = dataGridView1.SelectedRows[0];
            if (dataGridView1.Rows.Count > 0)
            {
                Customer cus = null;
                foreach (Customer c in entity.Customers)
                {
                    if (c.custid == (int)r.Cells[0].Value)
                    {
                        cus = c;
                    }
                }
                entity.Customers.Remove(cus);
                entity.SaveChanges();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (validateInput() == false)
            {
                return;
            }
            else
            {
                try
                {
                    UpdateCust();
                    loadTable();
                    MessageBox.Show("Update successful");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        void UpdateCust()
        {
            DataGridViewRow r = dataGridView1.SelectedRows[0];
            Customer tmp = null;
            foreach(Customer tmp1 in entity.Customers)
            {
                if (tmp1.custid == (int)r.Cells[0].Value)
                {
                    tmp = tmp1;
                }
            }

            tmp.companyname = cbCompanyName.Text;
            tmp.contactname = txtContactName.Text;
            tmp.contacttitle = cbContactTitle.Text;
            tmp.address = txtAddress.Text;
            tmp.city = txtCity.Text;
            tmp.region = txtRegion.Text;
            tmp.country = cbCountry.Text;
            tmp.postalcode = mtxtPostalCode.Text;
            tmp.phone = txtPhone.Text;
            tmp.fax = txtFax.Text;
            entity.SaveChanges();
        }
        private void FrmCustomer_Load(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetAll();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Search by CustomerID")
            {
                comboBox1.ValueMember = "custid";
            }
            if (comboBox1.SelectedItem == "Search by Contact Name")
            {
                comboBox1.ValueMember = "contactname";
            }
            if(comboBox1.SelectedItem == "Search by Contact Title")
            {
                comboBox1.ValueMember = "contacttitle";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sql = string.Format("SELECT * FROM Sales.Customers WHERE {0} LIKE '%{1}%'", comboBox1.ValueMember, txtsearch.Text);
            List<Customer> list = entity.Database.SqlQuery<Customer>(sql).ToList();
            dataGridView1.DataSource = list;
        }
        
    }
    
}
