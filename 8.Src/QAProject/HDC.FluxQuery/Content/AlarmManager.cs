
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
    public class AlarmManager
    {
        public event EventHandler AddedAlarm;

        private Timer _timer;
        public AlarmManager()
        {
            _timer = new Timer();
            _timer.Interval = 1000 * 3;
            _timer.Tick += new EventHandler(_timer_Tick);

        }

        public void Start()
        {
            _timer.Start();
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            DateTime from = this.StationAlarms.GetLastAlarmDateTime();

            DataTable tbl = DBI.ExecutePowerAlarmDataTable(from);
            if (tbl.Rows.Count > 0)
            {
                foreach (DataRow row in tbl.Rows)
                {
                    StationAlarm a = CreateAlarm(row);
                    this.StationAlarms.Add(a);
                }

                if (AddedAlarm != null)
                {
                    AddedAlarm(this, EventArgs.Empty);
                }

                // TODO: play sound
                //

            }
        }

        private StationAlarm CreateAlarm(DataRow row)
        {
            string name = row["StationName"].ToString();
            DateTime dt = Convert.ToDateTime(row["DT"]);
            string info = "¶Ïµç";

            return new StationAlarm(dt, name, info);
        }

        #region StationAlarms
        /// <summary>
        /// 
        /// </summary>
        public StationAlarmCollection StationAlarms
        {
            get
            {
                if (_stationAlarms == null)
                {
                    _stationAlarms = new StationAlarmCollection();
                }
                return _stationAlarms;
            }
        } private StationAlarmCollection _stationAlarms;
        #endregion //StationAlarms

    }

}
