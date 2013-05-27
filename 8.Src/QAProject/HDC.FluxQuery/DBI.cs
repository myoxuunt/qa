
using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
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
                _dbi = new DBI(ConfigurationManager.ConnectionStrings[1].ConnectionString);
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
            //string sql = "select * from vStationDevice where DeviceType ='{0}' order by stationName";
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
            SqlCommand cmd = new SqlCommand ( sql );
            DBIBase.AddSqlParameter(cmd, "stationName", stationName);
            DBIBase.AddSqlParameter(cmd, "b", b);
            DBIBase.AddSqlParameter(cmd, "e", e);

            return GetDefault().ExecuteDataTable(cmd);
        }
        #endregion //ExecuteFluxDataTable

        #region ExecuteHDDataTable
        internal static DataTable ExecuteHDDataTable(string stationName, DateTime b, DateTime e)
        {
            string sql = @"
                SELECT [DeviceID], [StationID], [StationName], [DeviceName], [DeviceType], 
                [DeviceAddress], [DT], [HDDataID] , value = case when vhddata.value = 1 then 'ÊÇ' else '·ñ' end
                FROM [vHDData] 
                where stationName = @stationName and dt >= @b and dt < @e order by dt";
            SqlCommand cmd = new SqlCommand ( sql );
            DBIBase.AddSqlParameter(cmd, "stationName", stationName);
            DBIBase.AddSqlParameter(cmd, "b", b);
            DBIBase.AddSqlParameter(cmd, "e", e);

            return GetDefault().ExecuteDataTable(cmd);
        }
        #endregion //ExecuteHDDataTable
    }

}
