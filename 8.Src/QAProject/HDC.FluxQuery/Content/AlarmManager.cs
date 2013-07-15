
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
            _timer.Interval = 1000 * 30;
            _timer.Tick += new EventHandler(_timer_Tick);

        }

        public void Start()
        {
            _timer.Start();
        }

        private DateTime GetFromDateTime()
        {
            if ( _fromDateTime == DateTime.MinValue )
            {
                _fromDateTime = DBI.GetLastAlarmDateTime();
            }
            return _fromDateTime;
        } private DateTime _fromDateTime = DateTime.MinValue;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _timer_Tick(object sender, EventArgs e)
        {
            DateTime from = GetFromDateTime();

            DataTable tbl = DBI.ExecutePowerAlarmDataTable(from);
            if (tbl.Rows.Count > 0)
            {
                foreach (DataRow row in tbl.Rows)
                {
                    StationAlarm a = CreateAlarm(row);
                    this.StationAlarms.Add(a);
                }
                _fromDateTime = this.StationAlarms.GetLastAlarmDateTime();

                if (AddedAlarm != null)
                {
                    AddedAlarm(this, EventArgs.Empty);
                }
            }
        }


        private StationAlarm CreateAlarm(DataRow row)
        {
            string name = row["StationName"].ToString();
            DateTime dt = Convert.ToDateTime(row["DT"]);
            string info = Strings.PowerOff;

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


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal bool HasAlarm()
        {
            return this.StationAlarms.Count > 0;
        }
    }

}
