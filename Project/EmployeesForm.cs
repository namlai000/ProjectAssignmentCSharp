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

        public EmployeesForm()
        {
            InitializeComponent();
            loadData();
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
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cbCountry.SelectedValue.ToString());
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
}
