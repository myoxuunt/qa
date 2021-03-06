using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Xdgk.Common;


namespace HDC.FluxQuery
{
    public class DBI : Xdgk.Common.DBIBase
    {

        #region DBI
        public DBI(string connString)
            : base(connString)
        {

        }
        #endregion //DBI

        #region GetDefault
        static private DBI GetDefault()
        {
            if (_dbi == null)
            {
                string c = SourceConfigManager.SourceConfigs[0].Value;
                _dbi = new DBI(c);
            }
            return _dbi;
        } static private DBI _dbi;
        #endregion //GetDefault

        #region GetStationDataTable
        static public DataTable GetStationDataTable(string deviceType)
        {
            return GetStationDataTable(new string[] { deviceType });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceTypes"></param>
        /// <returns></returns>
        static public DataTable GetStationDataTable(string[] deviceTypes)
        {
            DBI dbi = GetDefault();
            string sql = "select * from vStationDevice where DeviceType in ({0}) order by stationName";
            sql = string.Format(sql, GetIn(deviceTypes));
            return dbi.ExecuteDataTable(sql);
        }
        #endregion //GetStationDataTable

        static private string GetIn(string[] values)
        {
            string s = "'" + string.Join("','", values) + "'";
            return s;
        }

        #region ExecuteFluxDataTable
        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="e"></param>
        /// <param name="stationName"></param>
        /// <returns></returns>
        internal static DataTable ExecuteFluxDataTable(DateTime b, DateTime e, string stationName)
        {
            string sql = "select * from vFluxData where stationName = @stationName and dt >= @b and dt < @e order by dt";

            ListDictionary list = new ListDictionary();
            list.Add("stationName", stationName);
            list.Add("b", b);
            list.Add("e", e);

            return GetDefault().ExecuteDataTable(sql, list);
        }
        #endregion //ExecuteFluxDataTable

        #region ExecuteHDDataTable
        internal static DataTable ExecuteHDDataTable(string stationName, DateTime b, DateTime e)
        {
            string sql = @"
                SELECT [DeviceID], [StationID], [StationName], [DeviceName], [DeviceType], 
                [DeviceAddress], [DT], [HDDataID] , value = case when vhddata.value = 1 then '��' else '��' end
                FROM [vHDData] 
                where stationName = @stationName and dt >= @b and dt < @e order by dt";

            ListDictionary list = new ListDictionary();
            list.Add("stationName", stationName);
            list.Add("b", b);
            list.Add("e", e);

            return GetDefault().ExecuteDataTable(sql, list);
        }
        #endregion //ExecuteHDDataTable

        internal static DataTable ExecutePowerAlarmDataTable(DateTime from)
        {
            string s = "select * from vHDData where dt > @from and value = 0 order by dt";
            ListDictionary list = new ListDictionary();
            list.Add("from", from);

            return GetDefault().ExecuteDataTable(s, list);
        }

        internal static DateTime GetLastAlarmDateTime()
        {
            string s = "select max(DT) from tblHDData";
            object r = GetDefault().ExecuteScalar(s);
            if (r == null || r == DBNull.Value)
            {
                return DateTime.Now;
            }
            else
            {
                return Convert.ToDateTime(r);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_stationName"></param>
        /// <param name="_month"></param>
        /// <returns></returns>
        internal static DataTable ExecuteFluxMonthReportDataTable(string stationName, DateTime month)
        {
            DateTime b = new DateTime(month.Year, month.Month, 1);
            DateTime e = b.AddMonths(1);

            string sql = 
                @"select stationName, day(dt) as day, min(dt) as dtMin, max(dt) as dtMax, 
                min(sum) as sumMin, max(sum) as sumMax 
                from vfluxdata 
                where stationName = @stationName and dt >= @begin and dt < @end 
                group by stationname, day(dt)";

            ListDictionary list = new ListDictionary();
            list.Add("stationName", stationName);
            list.Add("begin", b);
            list.Add("end", e);

            return GetDefault().ExecuteDataTable(sql, list);
        }

        internal static DataTable ExecuteFluxYearReportDataTable(string stationName, DateTime year)
        {
            DateTime b = new DateTime(year.Year, 1, 1);
            DateTime e = b.AddYears(1);

            string sql = 
                @"select stationName, month(dt) as month, min(dt) as dtMin, max(dt) as dtMax, 
                min(sum) as sumMin, max(sum) as sumMax 
                from vfluxdata 
                where stationName = @stationName and dt >= @begin and dt < @end 
                group by stationname, month(dt)";

            ListDictionary list = new ListDictionary();
            list.Add("stationName", stationName);
            list.Add("begin", b);
            list.Add("end", e);

            return GetDefault().ExecuteDataTable(sql, list);
        }

        internal static DataTable ExecutePowerMonthReportdDataTable(string stationName, DateTime month, int expectValue)
        { 
            DateTime b = new DateTime(month.Year, month.Month, 1);
            DateTime e = b.AddMonths(1);

            string sql =
                @"select stationName, day(dt) as day, count(value) as count
                from vHDData 
                where stationName = @stationName and dt >= @begin and dt < @end and value = @value
                group by stationName, day(dt)";

            ListDictionary list = new ListDictionary();
            list.Add("stationName", stationName);
            list.Add("begin", b);
            list.Add("end", e);
            list.Add("value", expectValue);

            return GetDefault().ExecuteDataTable(sql, list);
        }

        internal static DataTable ExecutePowerYearReportdDataTable(string stationName, DateTime year, int expectValue)
        { 
            DateTime b = new DateTime(year.Year, 1, 1);
            DateTime e = b.AddYears(1);

            string sql =
                @"select stationName, month(dt) as month, count(value) as count
                from vHDData 
                where stationName = @stationName and dt >= @begin and dt < @end and value = @value
                group by stationName, month(dt)";

            ListDictionary list = new ListDictionary();
            list.Add("stationName", stationName);
            list.Add("begin", b);
            list.Add("end", e);
            list.Add("value", expectValue);

            return GetDefault().ExecuteDataTable(sql, list);
        }
    }

}
