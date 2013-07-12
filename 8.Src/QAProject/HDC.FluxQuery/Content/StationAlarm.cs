
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
    public class StationAlarm
    {
        public StationAlarm(DateTime dt, string stationName, string alarmInfo)
        {
            if (stationName == null)
            {
                throw new ArgumentNullException("stationName");
            }
            this._dT = dt;
            this._stationName = stationName;
            this._alarmInfo = alarmInfo;
        }

        #region StationName
        /// <summary>
        /// 
        /// </summary>
        public string StationName
        {
            get
            {
                return _stationName;
            }
        } private string _stationName;
        #endregion //StationName

        #region DT
        /// <summary>
        /// 
        /// </summary>
        public DateTime DT
        {
            get
            {
                return _dT;
            }
        } private DateTime _dT;
        #endregion //DT

        #region AlarmInfo
        /// <summary>
        /// 
        /// </summary>
        public string AlarmInfo
        {
            get
            {
                if (_alarmInfo == null)
                {
                    _alarmInfo = string.Empty;
                }
                return _alarmInfo;
            }
        } private string _alarmInfo;
        #endregion //AlarmInfo
    }

}
