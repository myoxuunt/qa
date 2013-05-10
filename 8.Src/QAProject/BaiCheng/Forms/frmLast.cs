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
    public partial class frmLast : Form
    {
        public frmLast()
        {
            InitializeComponent();

            this.ucDataGridView1.DgvColumnConfigs = Utilities.GetFluxDataGridViewColumnConfigs();
        }

        /// <summary>
        ///
        /// </summary>
        private void Query()
        {
            BcdbDataContext db = DBFactory.Create();
            var q = from p in db.vMeasureSluiceDataLast
                    orderby p.StationName 
                    select p;

            this.ucDataGridView1.DataSource = q;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLast_Load(object sender, EventArgs e)
        {
            Query();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLast_Activated(object sender, EventArgs e)
        {
            Query();
        }

    }
}
