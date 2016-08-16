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
            loadShiperID();
            loadData();
        }
        void loadShiperID()
        {
            cbShiperID.DataSource = entity.Shippers.ToList();
            cbShiperID.DisplayMember = "ShiperID";
        }
        void loadData()
        {
            dgvShipper.DataSource = entity.Shippers.ToList();
        }
        void Add()
        {
            Shipper shipper = new Shipper();
            shipper.shipperid = int.Parse(cbShiperID.Text);
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetAll();
        }

    }
}
