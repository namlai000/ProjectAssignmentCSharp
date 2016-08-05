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
        public EmployeesForm()
        {
            InitializeComponent();
            loadData();
        }

        void loadData()
        {
            // Load database
            TSQLFundamentals2008Entities entity = new TSQLFundamentals2008Entities();
            dataGridView1.DataSource = entity.Employees.ToList();

            // Countries
            cbCountry.DataSource = GetAllCountries();

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
            cbManager.DataSource = entity.Database.SqlQuery<NAMES>("SELECT empid, (lastname + ' ' + firstname) AS NAME FROM HR.Employees").ToList();
            cbManager.DisplayMember = "NAME";
            cbManager.ValueMember = "ID";
        }

        void clickRow()
        {
            DataGridViewRow r = dataGridView1.SelectedRows[0];
            txtId.Text = r.Cells[0].Value.ToString();
            txtLastName.Text = r.Cells[1].Value.ToString();
            txtFirstName.Text = r.Cells[2].Value.ToString();
            cbTitle.Text = r.Cells[3].Value.ToString();

            string cortesy = r.Cells[4].Value.ToString();
            if (cortesy.Equals("Mr")) radMr.Checked = true;
            else if (cortesy.Equals("Ms")) radMs.Checked = true;
            else if (cortesy.Equals("Mrs")) radMrs.Checked = true;
            else if (cortesy.Equals("Dr")) radDr.Checked = true;
        }

        string[] GetAllCountries()
        {
            Dictionary<string, string> objDic = new Dictionary<string, string>();

            foreach (CultureInfo ObjCultureInfo in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                RegionInfo objRegionInfo = new RegionInfo(ObjCultureInfo.Name);
                if (!objDic.ContainsKey(objRegionInfo.EnglishName))
                {
                    objDic.Add(objRegionInfo.EnglishName, objRegionInfo.TwoLetterISORegionName.ToLower());
                }
            }

            var obj = objDic.OrderBy(p => p.Key);
            var y = obj.Select(t => t.Key);
            return y.ToArray();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                clickRow();
            }
        }
    }

    class NAMES
    {
        string id;
        string name;

        public NAMES() { }

        public string ID { get; set; }
        public string NAME { get; set; }
    }
}
