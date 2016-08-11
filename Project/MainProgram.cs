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
    }
}
