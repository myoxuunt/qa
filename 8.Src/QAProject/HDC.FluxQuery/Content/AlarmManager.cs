using System;
using System.Data;
using System.Windows.Forms;

namespace HDC.FluxQuery
{
    /// <summary>
    /// 
    /// </summary>
    public class AlarmManager
    {
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler AddedAlarm;

        /// <summary>
        /// 
        /// </summary>
        private Timer _timer;

        #region AlarmManager
        /// <summary>
        /// 
        /// </summary>
        public AlarmManager()
        {
            _timer = new Timer();
            _timer.Interval = Code.FluxQueryConfig.AlarmCheckInterval;
            _timer.Tick += new EventHandler(_timer_Tick);
        }
        #endregion //AlarmManager

        #region Start
        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {
            _timer.Start();
        }
        #endregion //Start

        #region GetFromDateTime
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private DateTime GetFromDateTime()
        {
            if ( _fromDateTime == DateTime.MinValue )
            {
                _fromDateTime = DBI.GetLastAlarmDateTime();
            }
            return _fromDateTime;
        } private DateTime _fromDateTime = DateTime.MinValue;
        #endregion //GetFromDateTime

        #region _timer_Tick
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
        #endregion //_timer_Tick

        #region CreateAlarm
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private StationAlarm CreateAlarm(DataRow row)
        {
            string name = row["StationName"].ToString();
            DateTime dt = Convert.ToDateTime(row["DT"]);
            string info = Strings.PowerOff;

            return new StationAlarm(dt, name, info);
        }
        #endregion //CreateAlarm

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


        #region HasAlarm
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal bool HasAlarm()
        {
            return this.StationAlarms.Count > 0;
        }
        #endregion //HasAlarm
    }

}
