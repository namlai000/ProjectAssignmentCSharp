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
    public partial class ShipperForm : Form
    {
        TSQLFundamentals2008Entities entity = new TSQLFundamentals2008Entities();
        public ShipperForm()
        {
            InitializeComponent();
            loadData();
        }
        void loadShiperID()
        {
            cbShiperID.DataSource = entity.Shippers.ToList();
            cbShiperID.DisplayMember = "shipperid";
            loadShiperID();
        }
        void loadData()
        {
            dgvShipper.DataSource = entity.Shippers.ToList();
        }
        void Add()
        {
            Shipper shipper = new Shipper();
            shipper.phone = txtPhone.Text;
            shipper.companyname = txtCompanyName.Text;
            entity.Shippers.Add(shipper);
            entity.SaveChanges();
        }
        void Update()
        {
            DataGridViewRow r = dgvShipper.SelectedRows[0];
            Shipper tmp = null;
            foreach (Shipper tmp1 in entity.Shippers)
            {
                if (tmp1.shipperid == int.Parse(r.Cells[0].Value.ToString()))
                {
                    tmp = tmp1;
                    break;
                }
            }
            tmp.shipperid = int.Parse(cbShiperID.Text);
            tmp.companyname = txtCompanyName.Text;
            tmp.phone = txtPhone.Text;
            entity.SaveChanges();
        }
        void ResetAll()
        {
            cbShiperID.Text = "";
            txtCompanyName.Text = "";
            txtPhone.Text = "";
            txtSearch.Text = "";
        }

        void Delete()
        {
            DataGridViewRow r = dgvShipper.SelectedRows[0];
            Shipper tmp = null;
            foreach (Shipper tmp1 in entity.Shippers)
            {
                if (tmp1.shipperid == int.Parse(r.Cells[0].Value.ToString()))
                {
                    tmp = tmp1;
                    break;
                }
            }
            entity.Shippers.Remove(tmp);
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
                Delete();
                loadData();
            }
            catch (Exception)
            {
                MessageBox.Show("This shipper can not be deleted!");
            }
            
        }

        private void dgvShipper_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = dgvShipper.SelectedRows[0];
            Shipper tmp = null;
            foreach (Shipper tmp1 in entity.Shippers)
            {
                if (tmp1.shipperid == int.Parse(r.Cells[0].Value.ToString()))
                {
                    tmp = tmp1;
                    break;
                }
            }
            cbShiperID.Text = tmp.shipperid.ToString();
            txtCompanyName.Text = tmp.companyname;
            txtPhone.Text = tmp.phone;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvShipper.DataSource = entity.Database.SqlQuery<Shipper>("SELECT * FROM Sales.Shippers WHERE companyname LIKE '%" + txtSearch.Text +"%'").ToList();
        }
    }
}
