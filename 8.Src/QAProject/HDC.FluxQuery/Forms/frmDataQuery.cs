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
                StationNameSourceProvider.GetStationNameKeyValues()
                );
            this.ucDataGridView1.DgvColumnConfigs =
                DGVColumnConfigCollectionFactory.CreateFromXml(GetConfigFilePath ());
            this.ucCondition1.QueryEvent += new EventHandler(ucCondition1_QueryEvent);
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

    public class StationNameSourceProvider
    {
        static private string FluxDeviceType_scl6 = "scl6",
            FluxDeviceType_data7203 = "Data7203";

        static public KeyValueCollection GetFluxStationStationNameKeyValues()
        {
            return GetStationNameKeyValues();
        }

        static public KeyValueCollection GetStationNameKeyValues()
        {
            KeyValueCollection kvs = new KeyValueCollection();
            DataTable tbl = DBI.GetStationDataTable(new string[] { FluxDeviceType_scl6, FluxDeviceType_data7203 });
            foreach (DataRow row in tbl.Rows)
            {
                string stationName = row["StationName"].ToString().Trim();
                if (kvs.Find(stationName) == null)
                {
                    kvs.Add(new KeyValue(stationName, row));
                }
                else
                {
                    Console.WriteLine("include station name: " + stationName);
                }
            }

            return kvs;
        }
    }
}
