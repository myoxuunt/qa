using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VPump100Common;
using Xdgk.Common;

namespace VPumpQuery
{
    public partial class frmPumpDataLast : Form
    {
        public frmPumpDataLast()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshPumpDataLast();
        }

        private void RefreshPumpDataLast()
        {
            this.Text = Strings.title_pump_last;
            DataTable t = DBI.GetDefault().GetPumpDataLastDataTable();
            this.ucDataGridView1.DataSource = t;
        }

        private void frmPumpDataLast_Load(object sender, EventArgs e)
        {
            Helper.SetDataGridViewColumns(this.ucDataGridView1);
            this.ucDataGridView1.DataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(
                DataGridView_CellFormatting);
            RefreshPumpDataLast();
        }

        void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            VPump100StatusCellFormatter.Format((DataGridView)sender, e);
        }
    }
}
