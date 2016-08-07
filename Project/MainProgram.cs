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
        EmployeesForm empForm = null;
        FrmOrders orderForm = null;

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

        private void formOrdersToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}
