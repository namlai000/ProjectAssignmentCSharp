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
    public partial class MainProgram : Form
    {
        public EmployeesForm empForm = null;
        public FrmOrders orderForm = null;
        public FrmCustomer customerForm = null;
        public FrmProduct productForm = null;
        public FrmSupplier supplierForm = null;
        public CategoryForm catForm = null;
        public OrderDetailForm orderdetailForm = null;
        public ShipperForm shipForm = null;

        public MainProgram()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (empForm == null)
            {
                empForm = new EmployeesForm();
                empForm.MdiParent = this;
                empForm.Show();
            } else
            {
                empForm.Activate();
            }
        }

        private void formOrdersToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (orderForm == null)
            {
                orderForm = new FrmOrders();
                orderForm.MdiParent = this;
                orderForm.Show();
            }
            else
            {
                orderForm.Activate();
            }
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (customerForm == null)
            {
                customerForm = new FrmCustomer();
                customerForm.MdiParent = this;
                customerForm.Show();
            }
            else
            {
                customerForm.Activate();
            }
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
                productForm = new FrmProduct();
                productForm.MdiParent = this;
                productForm.Show();
        }

        private void suppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (supplierForm == null)
            {
                supplierForm = new FrmSupplier();
                supplierForm.MdiParent = this;
                supplierForm.Show();
            }
            else
            {
                supplierForm.Activate();
            }
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (catForm == null)
            {
                catForm = new CategoryForm();
                catForm.MdiParent = this;
                catForm.Show();
            }
            else
            {
                catForm.Activate();
            }
        }

        private void ordersDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (orderdetailForm == null)
            {
                orderdetailForm = new OrderDetailForm();
                orderdetailForm.MdiParent = this;
                orderdetailForm.Show();
            }
            else
            {
                orderdetailForm.Activate();
            }
        }

        private void shippersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (shipForm == null)
            {
                shipForm = new ShipperForm();
                shipForm.MdiParent = this;
                shipForm.Show();
            }
            else
            {
                shipForm.Activate();
            }
        }
    }
}
