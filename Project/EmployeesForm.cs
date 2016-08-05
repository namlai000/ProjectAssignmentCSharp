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
