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
        #region Members
        private AlarmManager _alarmManager;
        private ToolStripItem _alarmStatusLabel;
        #endregion //Members

        #region AlarmContent
        /// <summary>
        /// 
        /// </summary>
        public AlarmContent()
        {
            this.OrderNumber = 3;

            _alarmStatusLabel = new ToolStripStatusLabel();
            _alarmStatusLabel.Image = QRes.ImageManager.None.ToBitmap();
            _alarmStatusLabel.Click += new EventHandler(_alarmStatusLabel_Click);

            _alarmManager = new AlarmManager();
            _alarmManager.AddedAlarm += new EventHandler(_alarmManager_AddedAlarm);

        }
        #endregion //AlarmContent

        #region _alarmManager_AddedAlarm
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _alarmManager_AddedAlarm(object sender, EventArgs e)
        {
            RefreshStatus();
            PlayAlarmSound();
        }
        #endregion //_alarmManager_AddedAlarm

        #region PlayAlarmSound
        /// <summary>
        /// 
        /// </summary>
        private void PlayAlarmSound()
        {
            string file = System.IO.Path.Combine(
                System.IO.Path.GetDirectoryName(this.GetType().Assembly.Location),
                "config\\alarm.wav"
                );
            System.Media.SoundPlayer p = new System.Media.SoundPlayer(file);

            try
            {
                p.Play();
            }
            catch (Exception ex)
            {
            }
        }
        #endregion //PlayAlarmSound

        #region RefreshStatus
        /// <summary>
        /// 
        /// </summary>
        private void RefreshStatus()
        {
            if (this._alarmManager.StationAlarms.Count == 0)
            {
                _alarmStatusLabel.Image = QRes.ImageManager.None.ToBitmap();
                _alarmStatusLabel.Text = Strings.HasNotAlarm;
            }
            else
            {
                _alarmStatusLabel.Image = QRes.ImageManager.ErrorGlint;
                _alarmStatusLabel.Text = string.Format(Strings.AlarmWithCount,
                    this._alarmManager.StationAlarms.Count);
            }
        }
        #endregion //RefreshStatus

        #region Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentMenuItem"></param>
        /// <param name="parentToolStrip"></param>
        public override void Load(ToolStripMenuItem parentMenuItem, ToolStrip parentToolStrip)
        {
            // do nothing
            //
        }
        #endregion //Load

        #region Execute
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="inParameters"></param>
        /// <param name="outParameters"></param>
        public override void Execute(string name, ParameterCollection inParameters, ParameterCollection outParameters)
        {
            // do nothing
            //
        }
        #endregion //Execute

        #region Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentStrip"></param>
        public override void Load(StatusStrip parentStrip)
        {

            parentStrip.Items.Add(_alarmStatusLabel);

            RefreshStatus();

            _alarmManager.Start();
        }
        #endregion //Load

        #region _alarmStatusLabel_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _alarmStatusLabel_Click(object sender, EventArgs e)
        {
            if (this._alarmManager.HasAlarm())
            {
                frmPowerAlaram f = new frmPowerAlaram(this._alarmManager);
                f.ShowDialog();
                if (f.IsClearedAlarms)
                {
                    RefreshStatus();
                }
            }
        }
        #endregion //_alarmStatusLabel_Click
    }
}
