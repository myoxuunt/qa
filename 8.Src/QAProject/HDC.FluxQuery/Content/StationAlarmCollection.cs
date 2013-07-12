
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
    public class StationAlarmCollection : LimitationCollection<StationAlarm>
    {
        public StationAlarmCollection()
            : base(500)
        {

        }

        public DateTime GetLastAlarmDateTime()
        {
            if (this.Count == 0)
            {
                //return DateTime.Now ;
                return DateTime.Parse("2001-1-1");
            }
            else
            {
                DateTime r = this[0].DT;

                foreach (StationAlarm alarm in this)
                {
                    if (alarm.DT > r)
                    {
                        r = alarm.DT;
                    }
                }
                return r;
            }
        }
    }

}
