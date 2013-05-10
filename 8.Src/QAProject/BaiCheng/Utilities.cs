using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xdgk.Common ;

namespace BaiCheng
{
    internal class Utilities
    {
        private Utilities()
        {

        }

        internal static DGVColumnConfigCollection GetFluxDataGridViewColumnConfigs()
        {
            DGVColumnConfigCollection dgvs = new DGVColumnConfigCollection();
            dgvs.Add(new DGVColumnConfig("StationName", "", "站名"));
            dgvs.Add(new DGVColumnConfig("DT", "G", "时间", 160));
            dgvs.Add(new DGVColumnConfig("Height", "f2", "闸高(m)"));
            dgvs.Add(new DGVColumnConfig("BeforeWL", "f2", "闸前水位(m)"));
            dgvs.Add(new DGVColumnConfig("BehindWL", "f2", "闸后水位(m)"));
            dgvs.Add(new DGVColumnConfig("InstantFlux", "f2", "瞬时流量(m3/s)"));
            dgvs.Add(new DGVColumnConfig("RemainedAmount", "f2", "剩余水量(m3)"));
            return dgvs;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        static public KeyValueCollection GetStationNameKeyValues(BcdbDataContext db)
        {
            var q = from s in db.vStationDevice
                    orderby s.StationName 
                    select s ;

            KeyValueCollection kvs = new KeyValueCollection();
            foreach (var i in q)
            {
                kvs.Add(new KeyValue(i.StationName, i.StationName));
            }
            return kvs;
        }
    }
}
