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
    public partial class FrmOrders : Form
    {
        TSQLFundamentals2008Entities entity = new TSQLFundamentals2008Entities();
        public FrmOrders()
        {
            InitializeComponent();
            cbShipCountry.DataSource= getCountryList();
            
            loadtable();
            loadOrderID();
            loadCustomerID();
            loadEmployeeID();
            loadShipperID();
            loadSearch();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        Boolean ValidateInput()
        {
            bool ierror = false;
            if (dtpOrderDate.Value.Subtract(dtpShippedDate.Value).TotalDays > 0)
            {
                MessageBox.Show("The ship date must be after the order date");
            }
            if (txtFreight.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtFreight, "Freight cannot be empty");
                ierror = true;
            }
            if (txtShipAddress.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtShipAddress,"Ship address cannot be empty");
                ierror = true;
            }
            else if (txtShipAddress.Text.Trim().Length > 60)
            {
                errorProvider1.SetError(txtShipAddress, "Ship address must be less than 60 characters");
                ierror = true;
            }
            if (txtShipCity.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtShipCity, "Ship city cannot be empty");
                ierror = true;
            }
            else if (txtShipCity.Text.Trim().Length > 15)
            {
                errorProvider1.SetError(txtShipCity, "Ship city must be less than 15 character");
                ierror = true;
            }
            if (txtShipName.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtShipName, "Ship name cannot be empty");
                ierror = true;
            }
            else if (txtShipName.Text.Trim().Length > 40)
            {
                errorProvider1.SetError(txtShipName, "Ship name must be less than 40 characters");
                ierror = true;
            }
            if (txtShipRegion.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtShipRegion, "Ship Region cannot be empty");
                ierror = true;
            }
            else if (txtShipRegion.Text.Trim().Length > 15)
            {
                errorProvider1.SetError(txtShipRegion, "Ship region must be less than 15 character");
                ierror = true;
            }
            if (mtxtPostalCode.MaskCompleted == false)
            {
                errorProvider1.SetError(mtxtPostalCode, "Please enter postal code properly");
                ierror = true;
            }
            if (ierror == true)
            {
                return false;
            }
            else
            {
                errorProvider1.Clear();
            }
            return true;
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
        void loadtable(){
            foreach (Order o in entity.Orders)
            {
                if (o.shipregion == null)
                {
                    o.shipregion = "";
                }
            }
            dataGridView1.DataSource = entity.Orders.ToList();
            dataGridView1.Columns["Employee"].Visible = false;
            dataGridView1.Columns["Customer"].Visible = false;
            dataGridView1.Columns["OrderDetails"].Visible = false;
            dataGridView1.Columns["Shipper"].Visible = false;
        }
        void loadOrderID()
        {
            cbOrderID.DataSource = entity.Orders.ToList();
            cbOrderID.DisplayMember = "OrderID";
        }
        void loadCustomerID()
        {
            cbCustomerID.DataSource = entity.Customers.ToList();
            cbCustomerID.DisplayMember = "CustID";
        }
        void loadEmployeeID()
        {
            cbEmployeeID.DataSource = entity.Employees.ToList();
            cbEmployeeID.DisplayMember = "EmpID";
        }
        void loadShipperID()
        {
            cbShipperID.DataSource = entity.Shippers.ToList();
            cbShipperID.DisplayMember = "ShipperID";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInput() == false)
            {
                return;
            }
            else
            {
                AddnewOrder();
                loadtable();
                MessageBox.Show("Added successful");
            }

        }
        void AddnewOrder()
        {
                Order order = new Order();
                //order.orderid = int.Parse(cbOrderID.Text);
                order.custid = int.Parse(cbCustomerID.Text);
                order.empid = int.Parse(cbEmployeeID.Text);
                order.freight = int.Parse(txtFreight.Text);
                order.orderdate = dtpOrderDate.Value;
                order.requireddate = dtpReqDate.Value;
                order.shippeddate = dtpShippedDate.Value;
                order.shipperid = int.Parse(cbShipperID.Text);
                order.shipcity = txtShipCity.Text;
                order.shipregion = txtShipRegion.Text;
                order.shipcountry = cbShipCountry.Text;
                order.shipname = txtShipName.Text;
                order.shipaddress = txtShipAddress.Text;
                order.shippostalcode = mtxtPostalCode.Text;
                //foreach (Order o in entity.Orders)
                //{
                //    if (o.orderid == order.orderid)
                //    {
                //        return false;
                //    }
                //}  
                entity.Orders.Add(order);
                entity.SaveChanges();
                //return true;         
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveOrder();
            loadtable();
            MessageBox.Show("Order Removed");
        }
        void RemoveOrder()
        {
            DataGridViewRow r = dataGridView1.SelectedRows[0];
            if (dataGridView1.Rows.Count > 0)
            {
                Order order = null;
                foreach (Order o in entity.Orders)
                {
                    if(o.orderid==(int)r.Cells[0].Value)
                    {
                        order = o;
                        break;
                    }
                }
                entity.Orders.Remove(order);
                entity.SaveChanges();
              
            }
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateInput() == true)
            {
                return;
            }
            else
            {
                try
                {
                    UpdateOrders();
                    loadtable();
                    MessageBox.Show("Update successful"); 
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        void UpdateOrders()
        {
            DataGridViewRow r = dataGridView1.SelectedRows[0];
            Order tmp = null;
            foreach (Order tmp1 in entity.Orders)
            {
                if (tmp1.orderid == int.Parse(r.Cells[0].Value.ToString()))
                {
                    tmp = tmp1;
                    break;
                }
            }
            tmp.orderid = int.Parse(cbOrderID.Text);
            tmp.custid = int.Parse(cbCustomerID.Text);
            tmp.empid = int.Parse(cbEmployeeID.Text);
            tmp.freight = int.Parse(txtFreight.Text);
            tmp.orderdate = dtpOrderDate.Value;
            tmp.requireddate = dtpReqDate.Value;
            tmp.shippeddate = dtpShippedDate.Value;
            tmp.shipperid = int.Parse(cbShipperID.Text);
            tmp.shipcity = txtShipCity.Text;
            tmp.shipregion = txtShipRegion.Text;
            tmp.shipcountry = cbShipCountry.Text;
            tmp.shipname = txtShipName.Text;
            tmp.shipaddress = txtShipAddress.Text;
            tmp.shippostalcode = mtxtPostalCode.Text;
            entity.SaveChanges();
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DateTime dt;
                DataGridViewRow r = dataGridView1.SelectedRows[0];
                cbOrderID.Text = r.Cells[0].Value.ToString();
                cbCustomerID.Text = r.Cells[1].Value.ToString();
                cbEmployeeID.Text = r.Cells[2].Value.ToString();
                DateTime.TryParse(r.Cells[3].Value.ToString(),out dt);
                dtpOrderDate.Value = dt;
                DateTime.TryParse(r.Cells[4].Value.ToString(), out dt);
                dtpReqDate.Value = dt;
                DateTime.TryParse(r.Cells[5].Value.ToString(), out dt);
                dtpShippedDate.Value = dt;
                cbShipperID.SelectedItem = r.Cells[6].Value;
                txtFreight.Text = r.Cells[7].Value.ToString();
                txtShipName.Text = r.Cells[8].Value.ToString();
                txtShipAddress.Text = r.Cells[9].Value.ToString();
                txtShipCity.Text = r.Cells[10].Value.ToString();
                txtShipRegion.Text = r.Cells[11].Value.ToString();
                mtxtPostalCode.Text = r.Cells[12].Value.ToString();
                cbShipCountry.SelectedItem = r.Cells[13].Value.ToString();
            }
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //string sql = string.Format("SELECT * FROM Sales.Order WHERE {0} LIKE '%{1}%'", comboBox1.ValueMember, txtSearchValue.Text);
            //List<Order> list = entity.Database.SqlQuery<Order>(sql).ToList();
            //dataGridView1.DataSource = list;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSearchValue_TextChanged(object sender, EventArgs e)
        {
            string sql = string.Format("SELECT * FROM Sales.Orders WHERE {0} LIKE '%{1}%'", comboBox1.ValueMember, txtSearchValue.Text);
            List<Order> list = entity.Database.SqlQuery<Order>(sql).ToList();
            dataGridView1.DataSource = list;
        }
        void loadSearch()
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                comboBox1.ValueMember = "orderid";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                comboBox1.ValueMember = "custid";
            }
            if (comboBox1.SelectedIndex == 2)
            {
                comboBox1.ValueMember = "empid";
            }
        }

        private void FrmOrders_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainProgram Parent = (MainProgram)this.MdiParent;
            Parent.orderForm = null;
        }
        //        Search by Order ID
        //Search by Customer ID
        //Search by Employee ID
    }
}
