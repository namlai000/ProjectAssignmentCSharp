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
    public partial class FormSearchResultSuppliers : Form
    {
        public FormSearchResultSuppliers()
        {
            InitializeComponent();
        }
        public void addCategoryInfo(params String[] values)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dataGridView1);
            for (int i = 0; i < r.Cells.Count; i++)
                r.Cells[i].Value = values[i];
            dataGridView1.Rows.Add(r);
        }
    }
}
