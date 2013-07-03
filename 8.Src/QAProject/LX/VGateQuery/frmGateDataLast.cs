using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VGateQuery
{
    public partial class frmGateDataLast : Form
    {
        public frmGateDataLast()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshGateDataLast();
        }

        private void RefreshGateDataLast()
        {
            this.Text = Strings.title_gate_last;
            DataTable t = DBI.GetDefault().GetGateDataLastDataTable();
            this.ucDataGridView1.DataSource = t;
        }

        private void frmGateDataLast_Load(object sender, EventArgs e)
        {
            frmGateData.SetDataGridViewColumns(this.ucDataGridView1, this.GetType());
            RefreshGateDataLast();
        }
    }
}
