using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Xdgk.Common;

namespace VPumpQuery
{
    public partial class frmPumpData : Form
    {
        public frmPumpData()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPumpData_Load(object sender, EventArgs e)
        {
            this.Text = Strings.title_pump_query;
            Helper.SetDataGridViewColumns(this.ucDataGridView1);
            FillCondition();
            this.ucCondition1.QueryEvent += new EventHandler(ucCondition1_QueryEvent);
            this.ucDataGridView1.DataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(DataGridView_CellFormatting);
        }

        void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            VPump100StatusCellFormatter.Format((DataGridView)sender, e);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ucCondition1_QueryEvent(object sender, EventArgs e)
        {
            DataTable tbl = null;
            string stationName = this.ucCondition1.SelectedStationName;
            DateTime b = this.ucCondition1.Begin;
            DateTime end = this.ucCondition1.End;
            if (stationName == Strings.All)
            {
                tbl = DBI.GetDefault().GetPumpDataTable(b, end);
            }
            else
            {
                tbl = DBI.GetDefault().GetPumpDataTable(stationName, b, end);
            }
            this.ucDataGridView1.DataSource = tbl;
        }

        /// <summary>
        /// 
        /// </summary>
        private void FillCondition()
        {
            KeyValueCollection kvs = new KeyValueCollection();
            kvs.Add(new KeyValue(Strings.All, string.Empty));
            DataTable tbl = DBI.GetDefault().GetStationDataTable("vPump100");
            foreach (DataRow row in tbl.Rows)
            {
                string k = row["StationName"].ToString();
                kvs.Add(new KeyValue(k, k));
            }


            this.ucCondition1.BindStationName(kvs);
        }
    }
}
