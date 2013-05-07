using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HDC.FluxQuery
{
    public partial class frmDataQuery : Form
    {
        public frmDataQuery()
        {
            InitializeComponent();
        }

        private void frmDataQuery_Load(object sender, EventArgs e)
        {
            this.ucCondition1.BindStationName();
            this.ucDataGridView1.DgvColumnConfigs = DGVColumnConfigCollectionFactory.Create(Lines);
            this.ucCondition1.QueryEvent += new EventHandler(ucCondition1_QueryEvent);
        }

        private string[] Lines
        {
            get {
                return new string[] { 
                    "dataPropertyName=StationName;Text=站名;",
                    "dataPropertyName=DT;Text=时间;Format=G",
                    "dataPropertyName=InstantFlux;Text=瞬时流量(m3/s);Format=f2",
                    "dataPropertyName=Sum;Text=累计流量(m3);Format=f3"
                };
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ucCondition1_QueryEvent(object sender, EventArgs e)
        {
            DateTime b = ucCondition1.Begin;
            DateTime end = ucCondition1.End;
            string stationName = ucCondition1.SelectedStationName;

            DataTable tbl = DBI.ExecuteFluxDataTable(b, end, stationName);
            //this.ucDataGridView1.DataGridView.AutoGenerateColumns = true;
            this.ucDataGridView1.BindDataSource(tbl);
        }
    }
}
