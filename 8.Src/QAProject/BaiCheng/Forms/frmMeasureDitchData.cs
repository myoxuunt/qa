using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xdgk.Common;

namespace BaiCheng
{
    public partial class frmMeasureDitchData : Form
    {
        BcdbDataContext _db = DBFactory.Create();
        

        /// <summary>
        /// 
        /// </summary>
        public frmMeasureDitchData()
        {
            InitializeComponent();
            this.ucDataGridView1.DgvColumnConfigs = Utilities.GetFluxDataGridViewColumnConfigs();
            ucCondition1.BindStationName(GetKvs());
            ucCondition1.QueryEvent += new EventHandler(ucCondition1_QueryEvent);
            //db.Log = Console.Out;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Xdgk.Common.KeyValueCollection GetKvs()
        {
            var q = from s in _db.vStationDevice
                    orderby s.StationName 
                    select s ;

            KeyValueCollection kvs = new KeyValueCollection();
            foreach (var i in q)
            {
                kvs.Add(new KeyValue(i.StationName, i.StationName));
            }
            return kvs;
        }

        void ucCondition1_QueryEvent(object sender, EventArgs e)
        {
            this.btnQuery_Click(null, null);
        }

        /// <summary>
        ///
        /// </summary>
        DateTime Begin
        {
            get
            {
                return this.ucCondition1.Begin;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        object GetQuery()
        {
            string stationName = ucCondition1.SelectedStationName;

            var q = from p in _db.vMeasureSluiceData
                    where p.DT >= Begin && p.DT < this.ucCondition1.End
                        && p.StationName == stationName 
                    select p;

            return q;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(ucCondition1.SelectedStationID);
            var q = GetQuery();
            this.ucDataGridView1.DataSource = q;
        }
    }
}
