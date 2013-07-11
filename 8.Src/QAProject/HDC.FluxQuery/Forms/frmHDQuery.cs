using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Xdgk.Common;

namespace HDC.FluxQuery
{
    public partial class frmHDQuery : Form
    {
        public frmHDQuery()
        {
            InitializeComponent();
        }

        private KeyValueCollection GetStationNameKeyValues()
        {
            KeyValueCollection kvs = new KeyValueCollection();
            DataTable tbl = DBI.GetStationDataTable("HDDevice");
            foreach (DataRow row in tbl.Rows)
            {
                kvs.Add(new KeyValue(row["StationName"].ToString().Trim(), row));
            }

            return kvs;
        }
        private void frmHDQuery_Load(object sender, EventArgs e)
        {
            this.Text = Strings.title_hd_query;
            this.ucCondition1.BindStationName(
GetStationNameKeyValues()
                );

            this.ucCondition1.QueryEvent += new EventHandler(ucCondition1_QueryEvent);

            this.ucDataGridView1.DgvColumnConfigs = DGVColumnConfigCollectionFactory.Create(GetLines());
        }

        private string[] GetLines()
        {
            return new string[] 
            {
                "dataPropertyName=StationName;Text=站名;",
                "dataPropertyName=DT;Text=时间;format=G;width=160",
                "dataPropertyName=value;Text=市电状态;",
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ucCondition1_QueryEvent(object sender, EventArgs e)
        {
            DataTable tbl= DBI.ExecuteHDDataTable(ucCondition1.SelectedStationName ,
                ucCondition1.Begin,
                ucCondition1.End);
            this.ucDataGridView1.DataSource = tbl;
        }
    }
}
