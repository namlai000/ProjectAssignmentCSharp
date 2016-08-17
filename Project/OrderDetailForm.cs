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
    public partial class OrderDetailForm : Form
    {
        TSQLFundamentals2008Entities entity = new TSQLFundamentals2008Entities();
        
        public OrderDetailForm()
        {
            InitializeComponent();
            loadData();
        }
        void loadOrderID()
        {
            cbOrderID.DataSource = entity.Orders.ToList();
            cbOrderID.DisplayMember = "OrderID";
        }
        void loadProductID()
        {
            cbProductID.DataSource = entity.Products.ToList();
            cbProductID.DisplayMember = "ProductID";
        }
        void loadData()
        {
            dgvOrderDetails.DataSource = entity.OrderDetails.ToList();
            dgvOrderDetails.Columns["Product"].Visible = false;
            dgvOrderDetails.Columns["Order"].Visible = false;

            loadOrderID();
            loadProductID();

        }
        Boolean ValidateInput()
        {
            errorProvider1.Clear();
            bool error = false;
            try
            {
                int a = int.Parse(tbUnitPrice.Text);
                if (a <= 0)
                {
                    errorProvider1.SetError(tbUnitPrice, "Price must be greater than 0");
                    error = true;
                }

            }
            catch (Exception)
            {

                errorProvider1.SetError(tbUnitPrice, "Price must be digit");
                error = true;
            }
            if (nbQuantity.Value == 0)
            {
                errorProvider1.SetError(nbQuantity, "Quantity must be greater than 0");
                error = true;
            }
            try
            {
                int b = int.Parse(tbDiscount.Text);
                if (b < 0 || b > 1)
                {
                    errorProvider1.SetError(tbDiscount, "Discount must be greater than 0 and smaller than 1");
                    error = true;
                }
            }
            catch (Exception)
            {

                errorProvider1.SetError(tbDiscount, "Discount must be digit");
                error = true;
            }

            return error;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInput() == false)
            {
                try
                {
                    AddNewOrderDetail();
                }
                catch (Exception)
                {

                    MessageBox.Show("Duplicated !");
                }
                
                loadData(); ;
            }
        }
        void AddNewOrderDetail()
        {

            OrderDetail orderDetail = new OrderDetail();
            orderDetail.orderid = int.Parse(cbOrderID.Text);
            orderDetail.productid = int.Parse(cbProductID.Text);
            orderDetail.unitprice = decimal.Parse(tbUnitPrice.Text);
            orderDetail.qty = short.Parse(nbQuantity.Value.ToString());
            orderDetail.discount = decimal.Parse(tbDiscount.Text);
            entity.OrderDetails.Add(orderDetail);
            entity.SaveChanges();
        }
        
        void UpdateOrderDetails()
        {
            DataGridViewRow r = dgvOrderDetails.SelectedRows[0];
            OrderDetail tmp = null;
            foreach (OrderDetail tmp1 in entity.OrderDetails)
            {
                if (tmp1.orderid == int.Parse(r.Cells[0].Value.ToString()))
                {
                    tmp = tmp1;
                    break;
                }
            }
            tmp.orderid = int.Parse(cbOrderID.Text);
            tmp.productid = int.Parse(cbProductID.Text);
            tmp.unitprice = int.Parse(tbUnitPrice.Text);
            tmp.qty = short.Parse(nbQuantity.Value.ToString());
            tmp.discount = decimal.Parse(tbDiscount.Text);
            entity.SaveChanges();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateOrderDetails();
            loadData();
        }
        void ResetAll()
        {
            cbOrderID.Text = "";
            cbProductID.Text = "";
            tbUnitPrice.Text = "";
            nbQuantity.Value = 0;
            tbDiscount.Text = "";

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string sql = string.Format("SELECT * FROM Sales.OrderDetails WHERE orderid LIKE '%{0}%'", txtSearch.Text);
            List<OrderDetail> list = entity.Database.SqlQuery<OrderDetail>(sql).ToList();
            dgvOrderDetails.DataSource = list;
        }

        private void dgvOrderDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = dgvOrderDetails.SelectedRows[0];
            cbOrderID.Text = r.Cells[0].Value.ToString();
            cbProductID.Text = r.Cells[1].Value.ToString();
            tbUnitPrice.Text = r.Cells[2].Value.ToString();
            nbQuantity.Value = int.Parse(r.Cells[3].Value.ToString());
            tbDiscount.Text = r.Cells[4].Value.ToString();
        }
    }
}
