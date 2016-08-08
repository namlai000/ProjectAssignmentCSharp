using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Globalization;

namespace Project
{
    public partial class EmployeesForm : Form
    {
        TSQLFundamentals2008Entities entity = new TSQLFundamentals2008Entities();
        bool addNew = false;
        bool update = false;

        public EmployeesForm()
        {
            InitializeComponent();
            loadData();
            InitialButton();
        }

        void InitialButton()
        {
            if (addNew)
            {
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnAdd.Enabled = true;
            } else
            {
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnAdd.Enabled = false;
            }

            if (update)
            {
                btnUpdate.Enabled = true;
                btnAdd.Enabled = false;
                btnDelete.Enabled = true;
            }
        }

        void loadData()
        {
            // Load database
            dataGridView1.DataSource = entity.Employees.ToList();

            // Countries
            cbCountry.DataSource = new BindingSource(getCountriesList(), null);
            cbCountry.DisplayMember = "Key";
            cbCountry.ValueMember = "Value";

            // Titles
            cbTitle.DataSource = entity.Employees.ToList().Select(emp => emp.title).Distinct().ToList();
            cbTitle.DisplayMember = "title";

            // City
            cbCity.DataSource = entity.Employees.ToList().Select(emp => emp.city).Distinct().ToList();
            cbTitle.DisplayMember = "city";

            // Region
            cbRegion.DataSource = entity.Employees.ToList().Select(emp => emp.region).Distinct().ToList();
            cbRegion.DisplayMember = "region";

            // Manager
            List<Emp> list = entity.Database.SqlQuery<Emp>("SELECT empid AS ID, (lastname + ' ' + firstname) AS NAME FROM HR.Employees").ToList();
            Emp no = new Emp();
            no.ID = 0;
            no.NAME = "NO MANAGER";
            list.Insert(0, no);
            cbManager.DataSource = list;
            cbManager.DisplayMember = "NAME";
            cbManager.ValueMember = "ID";

            // Bind courtesy default
            radMr.Checked = true;

            // Filter
            cbFilter.Items.Clear();
            foreach (DataGridViewColumn data in dataGridView1.Columns)
            {
                cbFilter.Items.Add(data.Name);
            }
            cbFilter.SelectedIndex = 0;
        }

        SortedDictionary<string, string> getCountriesList()
        {
            SortedDictionary<string, string> cultureList = new SortedDictionary<string, string>();
            
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo culture in cultures)
            {
                RegionInfo region = new RegionInfo(culture.LCID);

                if (!(cultureList.Keys.Contains(region.EnglishName)))
                {
                    cultureList.Add(region.EnglishName, region.TwoLetterISORegionName);
                }
            }
            
            return cultureList;
        }

        string convertToEnglishName(string name)
        {
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo culture in cultures)
            {
                RegionInfo region = new RegionInfo(culture.LCID);
                if (name.Length == 2)
                {
                    if (region.TwoLetterISORegionName.Equals(name)) return region.EnglishName;
                } else
                {
                    if (region.ThreeLetterISORegionName.Equals(name)) return region.EnglishName;
                }
            }

            return null;
        }

        void clickRow()
        {
            DataGridViewRow r = dataGridView1.SelectedRows[0];
            txtId.Text = r.Cells[0].Value.ToString();
            txtLastName.Text = r.Cells[1].Value.ToString();
            txtFirstName.Text = r.Cells[2].Value.ToString();
            cbTitle.Text = r.Cells[3].Value.ToString();

            string cortesy = r.Cells[4].Value.ToString();
            if (cortesy.Equals("Mr.")) radMr.Checked = true;
            else if (cortesy.Equals("Ms.")) radMs.Checked = true;
            else if (cortesy.Equals("Mrs.")) radMrs.Checked = true;
            else if (cortesy.Equals("Dr.")) radDr.Checked = true;

            dtpBirthdate.Value = DateTime.Parse(r.Cells[5].Value.ToString());
            dtpHiredate.Value = DateTime.Parse(r.Cells[6].Value.ToString());
            txtaddress.Text = r.Cells[7].Value.ToString();
            cbCity.Text = r.Cells[8].Value.ToString();
            cbRegion.Text = r.Cells[9].Value == null ? "" : r.Cells[9].Value.ToString();
            txtPostalCode.Text = r.Cells[10].Value == null ? "" : r.Cells[10].Value.ToString();
            cbCountry.Text = convertToEnglishName(r.Cells[11].Value.ToString());
            txtPhone.Text = r.Cells[12].Value.ToString();

            int manager = r.Cells[13].Value == null ? 0 : int.Parse(r.Cells[13].Value.ToString());
            string sql = string.Format("SELECT (lastname + ' ' + firstname) FROM HR.Employees WHERE empid={0}", manager);
            List<string> managerName = entity.Database.SqlQuery<string>(sql).ToList();
            cbManager.Text = "NO MANAGER";
            foreach (string name in managerName)
            {
                cbManager.Text = name;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                clickRow();
                update = true;
                addNew = false;
                InitialButton();
            }
        }

        bool checkValid()
        {
            errorProvider1.Clear();
            bool error = false;
            if (txtLastName.Text.Equals("")) { errorProvider1.SetError(txtLastName, "No empty allow"); error = true; }
            if (txtFirstName.Text.Equals("")) { errorProvider1.SetError(txtFirstName, "No empty allow"); error = true; }
            if (cbTitle.Text.Equals("")) { errorProvider1.SetError(cbTitle, "No empty allow"); error = true; }
            DateTime birth = dtpBirthdate.Value;
            DateTime hire = dtpHiredate.Value;
            if ((hire.Year - birth.Year) < 18) { errorProvider1.SetError(dtpBirthdate, "Employee must be older than 18"); error = true; }
            if (txtaddress.Text.Equals("")) { errorProvider1.SetError(txtaddress, "No empty allow"); error = true; }
            if (cbCity.Text.Equals("")) { errorProvider1.SetError(cbCity, "No empty allow"); error = true; }
            if (!txtPhone.MaskCompleted) { errorProvider1.SetError(txtPhone, "Invalid phone"); error = true; }

            if (error) return false;
            return true;
        }

        void addData()
        {
            Employee emp = new Employee();
            emp.lastname = txtLastName.Text;
            emp.firstname = txtFirstName.Text;
            emp.title = cbTitle.Text;

            string titleofcortesy = null;
            if (radMr.Checked) titleofcortesy = "Mr.";
            else if (radMrs.Checked) titleofcortesy = "Mrs.";
            else if (radMs.Checked) titleofcortesy = "Ms.";
            else titleofcortesy = "Dr.";
            emp.titleofcourtesy = titleofcortesy;

            emp.birthdate = dtpBirthdate.Value;
            emp.hiredate = dtpHiredate.Value;
            emp.address = txtaddress.Text;
            emp.city = cbCity.Text;
            emp.region = string.IsNullOrEmpty(cbRegion.Text) ? null: cbRegion.Text;
            emp.postalcode = string.IsNullOrEmpty(txtPostalCode.Text) ? null : txtPostalCode.Text;
            emp.country = cbCountry.SelectedValue.ToString();
            emp.phone = txtPhone.Text;

            int id = int.Parse(cbManager.SelectedValue.ToString());
            if (id != 0) emp.mgrid = id;

            entity.Employees.Add(emp);
            entity.SaveChanges();
        }

        void updateEmployee()
        {
            int id = int.Parse(txtId.Text);
            Employee emp = entity.Employees.First(x => x.empid == id);

            emp.lastname = txtLastName.Text;
            emp.firstname = txtFirstName.Text;
            emp.title = cbTitle.Text;

            string titleofcortesy = null;
            if (radMr.Checked) titleofcortesy = "Mr.";
            else if (radMrs.Checked) titleofcortesy = "Mrs.";
            else if (radMs.Checked) titleofcortesy = "Ms.";
            else titleofcortesy = "Dr.";
            emp.titleofcourtesy = titleofcortesy;

            emp.birthdate = dtpBirthdate.Value;
            emp.hiredate = dtpHiredate.Value;
            emp.address = txtaddress.Text;
            emp.city = cbCity.Text;
            emp.region = string.IsNullOrEmpty(cbRegion.Text) ? null : cbRegion.Text;
            emp.postalcode = string.IsNullOrEmpty(txtPostalCode.Text) ? null : txtPostalCode.Text;
            emp.country = cbCountry.SelectedValue.ToString();
            emp.phone = txtPhone.Text;

            id = int.Parse(cbManager.SelectedValue.ToString());
            if (id != 0) emp.mgrid = id;

            entity.SaveChanges();
        }

        void deleteEmployee()
        {
            int id = int.Parse(txtId.Text);
            Employee emp = entity.Employees.First(x => x.empid == id);
            entity.Employees.Remove(emp);
            entity.SaveChanges();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkValid())
            {
                addData();
                addNew = false;
            }
            loadData();
            InitialButton();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            addNew = true;
            update = false;
            InitialButton();
            Reset.ResetAllControls(this);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteEmployee();
            addNew = false;
            update = false;
            loadData();
            Reset.ResetAllControls(this);
            InitialButton();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (checkValid())
            {
                updateEmployee();
                addNew = false;
                update = false;
            }
            loadData();
            InitialButton();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string sql = string.Format("SELECT * FROM HR.Employees WHERE {0} LIKE '%{1}%'", cbFilter.Text ,txtSearch.Text);
            List <Employee> list = entity.Database.SqlQuery<Employee>(sql).ToList();
            dataGridView1.DataSource = list;
        }
    }


    class Emp
    {
        int id;
        string name;

        public Emp() { }

        public Emp(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int ID { get; set; }
        public string NAME { get; set; }
    }

    class Reset
    {
        public static void ResetAllControls(Control form)
        {
            foreach (Control control in form.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = null;
                }

                if (control is MaskedTextBox)
                {
                    MaskedTextBox textBox = (MaskedTextBox)control;
                    textBox.Text = null;
                }

                if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    if (comboBox.Items.Count > 0)
                        comboBox.SelectedIndex = 0;
                }
            }
        }
    }
}
