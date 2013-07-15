
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;


namespace HDC.FluxQuery
{
    public class ItemCollection : Xdgk.Common.Collection<Item>
    {

        public ReportItemCollection ToMonthReportItems()
        {
            return ToReportItems("yyyy-MM", "yyyy-MM-dd HH:mm:ss");
        }

        public ReportItemCollection ToDayReportItems()
        {
            return ToReportItems("MM-dd", "HH:mm:ss");
        }

        private ReportItemCollection ToReportItems(string dayOrMonthDatetimeFormat,
           string valueDateTimeFormat )
        {
            ReportItemCollection r = new ReportItemCollection();
            foreach (Item n in this)
            {
                ReportItem ri = n.ToReportItem(dayOrMonthDatetimeFormat,
                    valueDateTimeFormat);
                r.Add(ri);
            }
            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ReportItem ToSumReportItem()
        {
            Item b = null;
            Item e = null;
            int powerOffCount = 0;
            int powerOnCount = 0;

            foreach (Item n in this)
            {
                if (n.HasFluxData)
                {
                    if (b == null)
                    {
                        b = n;
                    }
                    e = n;
                }

                if (n.HasPowerData)
                {
                    powerOffCount += n.PowerOffCount;
                    powerOnCount += n.PowerOnCount;
                }
            }
            int powerAllCount = powerOnCount + powerOffCount;

            ReportItem r = new ReportItem();
            r.DTText = "ºÏ¼Æ";
            if (b != null)
            {
                r.BeginDTText = b.BeginDT.ToString();
                r.EndDTText = e.EndDT.ToString();
                r.BeginSumText = b.BeginSum.ToString();
                r.EndSumText = e.EndSum.ToString();
                r.UsedText = (e.EndSum - b.BeginSum).ToString();
            }

            if (powerAllCount > 0)
            {
                r.PowerOffRateText = string.Format("{0}/{1}", powerOffCount, powerAllCount);
            }

            return r;
        }
    }
}
