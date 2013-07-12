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
    public partial class frmPowerAlaram : NUnit.UiKit.FixedDialogBase  
    {
        public frmPowerAlaram(AlarmManager alarmManager)
        {
            InitializeComponent();

            this._alarmManager = alarmManager;
        }

        /// <summary>
        /// 
        /// </summary>
        public AlarmManager AlarmManager
        {
            get { return _alarmManager; }
        } private AlarmManager _alarmManager;

        private void frmPowerAlaram_Load(object sender, EventArgs e)
        {
            this.Text = Strings.PowerAlarm;

            FillAlarm();
        }

        private void FillAlarm()
        {
            // TODO:
            //
            //resourc
            string xml = Strings.AlarmColumnConfig;
            this.ucDataGridView1.DgvColumnConfigs = DGVColumnConfigCollectionFactory.CreateFromXmlString(xml);
            this.ucDataGridView1.DataSource = _alarmManager.StationAlarms;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            this._alarmManager.StationAlarms.Clear();
            this.ucDataGridView1.DataSource = null;
            this._isClearedAlarms = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsClearedAlarms
        {
            get { return _isClearedAlarms; }
        } private bool _isClearedAlarms = false;
    }
}
