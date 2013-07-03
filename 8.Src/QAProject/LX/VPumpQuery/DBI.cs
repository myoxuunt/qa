using System;
using System.Collections.Specialized;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Xdgk.Common;

namespace VPumpQuery
{
    /// <summary>
    /// 
    /// </summary>
    public class DBI : DBIBase 
    {
        #region GetDefault
        static public DBI GetDefault()
        {
            if (_dbi == null)
            {
                string c = SourceConfigManager.SourceConfigs[0].Value;
                _dbi = new DBI(c);
            }
            return _dbi;
        } static private DBI _dbi;
        #endregion //GetDefault

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connString"></param>
        public DBI(string connString)
            : base(connString)
        {

        }

        public DataTable GetStationDataTable(string deviceType)
        {
            string s = @"select * from tblStation inner join tblDevice 
                        on tblStation.StationID = tblDevice.StationID
                        where tblDevice.DeviceType = @deviceType
                        order by stationName";

            ListDictionary list = new ListDictionary();
            list.Add("deviceType", deviceType);
            return base.ExecuteDataTable(s, list);

        }


        public DataTable GetPumpDataLastDataTable()
        {
            string s = "select * from vPumpDataLast order by stationName";
            return ExecuteDataTable(s);
        }

        public DataTable GetPumpDataTable(string stationName, DateTime b, DateTime e)
        {
            string s = @"select * from vPumpData 
                        where stationName = @stationName and 
                        DT >= @b and DT < @e
                        order by stationName";

            ListDictionary list = new ListDictionary();
            list.Add("stationName", stationName );
            list.Add("b", b);
            list.Add("e", e);

            return ExecuteDataTable(s, list);
        }

        public DataTable GetPumpDataTable(DateTime b, DateTime e)
        {
            string s = @"select * from vPumpData 
                        where DT >= @b and DT < @e
                        order by stationName";

            ListDictionary list = new ListDictionary();
            list.Add("b", b);
            list.Add("e", e);

            return ExecuteDataTable(s, list);
        }
    }
}
