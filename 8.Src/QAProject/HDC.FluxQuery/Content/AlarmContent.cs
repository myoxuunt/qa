
using System;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using Xdgk.Common;
using QA.Interface;


namespace HDC.FluxQuery
{
    public class AlarmContent : ContentBase
    {
        private AlarmManager _alarmManager;
        private ToolStripItem _alarmStatusLabel;

        public AlarmContent()
        {
            this.OrderNumber = 3;

            _alarmStatusLabel = new ToolStripStatusLabel();
            _alarmStatusLabel.Image = QRes.ImageManager.AlarmStatus.ToBitmap();
            _alarmStatusLabel.Click += new EventHandler(_alarmStatusLabel_Click);

            _alarmManager = new AlarmManager();
            _alarmManager.AddedAlarm += new EventHandler(_alarmManager_AddedAlarm);

        }

        void _alarmManager_AddedAlarm(object sender, EventArgs e)
        {
            RefreshStatus();
        }

        private void RefreshStatus()
        {
            if (this._alarmManager.StationAlarms.Count == 0)
            {
                _alarmStatusLabel.Text = "无断电报警";
            }
            else
            {
                _alarmStatusLabel.Text = string.Format("{0} 条断电报警", this._alarmManager.StationAlarms.Count);
            }
        }

        public override void Load(ToolStripMenuItem parentMenuItem, ToolStrip parentToolStrip)
        {
            // do nothing
            //
        }

        public override void Execute(string name, ParameterCollection inParameters, ParameterCollection outParameters)
        {
            // do nothing
            //
        }

        public override void Load(StatusStrip parentStrip)
        {

            //a.AutoToolTip = true;
            //a.Width = 300;
            //a.AutoSize = false;
            //a.ForeColor = Color.Red;
            //a.BackColor = Color.Black;
            //a.Alignment = ToolStripItemAlignment.Right;
            parentStrip.Items.Add(_alarmStatusLabel);
            //parentStrip.Text = "123";

            RefreshStatus();

            _alarmManager.Start();
        }

        void _alarmStatusLabel_Click(object sender, EventArgs e)
        {
            ToolStripStatusLabel a = sender as ToolStripStatusLabel;
            a.Text = DateTime.Now.ToString();

            frmPowerAlaram f = new frmPowerAlaram(this._alarmManager);
            f.ShowDialog();
            if (f.IsClearedAlarms)
            {
                RefreshStatus();
            }
        }
    }

}
