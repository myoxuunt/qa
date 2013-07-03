using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Xdgk.Common;

namespace VGateQuery
{
    public partial class frmGateData : Form
    {
        public frmGateData()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmGateData_Load(object sender, EventArgs e)
        {
            this.Text = Strings.title_gate_query;
            SetDataGridViewColumns(this.ucDataGridView1, this.GetType());
            FillCondition();
            this.ucCondition1.QueryEvent += new EventHandler(ucCondition1_QueryEvent);
        }

        /// <summary>
        /// 
        /// </summary>
        static internal void SetDataGridViewColumns(Xdgk.UI.Forms.UCDataGridView ucDataGridView, Type typeInAssembly)
        {
            string path = System.IO.Path.Combine(
                System.IO.Path.GetDirectoryName(typeInAssembly.Assembly.Location),
                "Config\\GateColumnConfig.xml");
            DGVColumnConfigCollection cfg = DGVColumnConfigCollectionFactory.CreateFromXml(path);
            ucDataGridView.DgvColumnConfigs = cfg;
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
            if (stationName == "<全部>")
            {
                tbl = DBI.GetDefault().GetGateDataTable(b, end);
            }
            else
            {
                tbl = DBI.GetDefault().GetGateDataTable(stationName, b, end);
            }
            this.ucDataGridView1.DataSource = tbl;
        }

        private void FillCondition()
        {
            KeyValueCollection kvs = new KeyValueCollection();
            kvs.Add(new KeyValue("<全部>", ""));
            DataTable tbl = DBI.GetDefault().GetStationDataTable("vGate100");
            foreach (DataRow row in tbl.Rows)
            {
                string k = row["StationName"].ToString();
                kvs.Add(new KeyValue(k, k));
            }


            this.ucCondition1.BindStationName(kvs);
        }
    }
}
