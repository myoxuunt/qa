using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Xdgk.Common ;

namespace HDC.FluxQuery
{
    using Path = System.IO.Path;

    public partial class frmDataQuery : Form
    {
        public frmDataQuery()
        {
            InitializeComponent();
        }

        private string GetConfigFilePath()
        {
            return Path.Combine(
                Path.GetDirectoryName(this.GetType().Assembly.Location),
                "config\\fluxColumnConfig.xml"
                );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmDataQuery_Load(object sender, EventArgs e)
        {
            this.Text = Strings.title_flux_form;

            this.ucCondition1.BindStationName(
                GetStationNameKeyValues()
                );
            this.ucDataGridView1.DgvColumnConfigs =
                DGVColumnConfigCollectionFactory.CreateFromXml(GetConfigFilePath ());
            this.ucCondition1.QueryEvent += new EventHandler(ucCondition1_QueryEvent);
        }

        private KeyValueCollection GetStationNameKeyValues()
        {
            KeyValueCollection kvs = new KeyValueCollection();
            DataTable tbl = DBI.GetStationDataTable("scl6");
            foreach (DataRow row in tbl.Rows)
            {
                kvs.Add(new KeyValue(row["StationName"].ToString().Trim(), row));
            }

            return kvs;
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
            this.ucDataGridView1.DataSource = tbl;
        }
    }
}
