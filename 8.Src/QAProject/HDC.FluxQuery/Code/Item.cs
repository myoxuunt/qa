using System;
using System.Data;
using System.Collections.Generic;
using System.Text;


namespace HDC.FluxQuery
{
    internal class FormatStringProvider
    {
        private FormatStringProvider()
        {

        }

        internal const string DOUBLE_FORMAT = "f2";
    }
    /// <summary>
    /// 
    /// </summary>
    public class Item
    {

        public Item()
        {

        }

        public Item(DateTime dt)
        {
            this._dt = dt;
        }

        #region DT
        /// <summary>
        /// 
        /// </summary>
        public DateTime DT
        {
            get
            {
                return _dt;
            }
        } private DateTime _dt;
        #endregion //DT

        #region BeginDT
        /// <summary>
        /// 
        /// </summary>
        public DateTime BeginDT
        {
            get
            {
                return _beginDT;
            }
            set
            {
                _beginDT = value;
            }
        } private DateTime _beginDT;
        #endregion //BeginDT

        #region EndDT
        /// <summary>
        /// 
        /// </summary>
        public DateTime EndDT
        {
            get
            {
                return _endDT;
            }
            set
            {
                _endDT = value;
            }
        } private DateTime _endDT;
        #endregion //EndDT


        #region BeginSum
        /// <summary>
        /// 
        /// </summary>
        public double BeginSum
        {
            get
            {
                return _beginSum;
            }
            set
            {
                _beginSum = value;
            }
        } private double _beginSum;
        #endregion //BeginSum

        #region EndSum
        /// <summary>
        /// 
        /// </summary>
        public double EndSum
        {
            get
            {
                return _endSum;
            }
            set
            {
                _endSum = value;
            }
        } private double _endSum;
        #endregion //EndSum

        #region Used
        /// <summary>
        /// 
        /// </summary>
        public double Used
        {
            get
            {
                return _endSum - _beginSum;
            }
        }
        #endregion //Used

        #region PowerOnCount
        /// <summary>
        /// 
        /// </summary>
        public int PowerOnCount
        {
            get
            {
                return _powerOnCount;
            }
            set
            {
                _powerOnCount = value;
            }
        } private int _powerOnCount;
        #endregion //PowerOnCount

        #region PowerOffCount
        /// <summary>
        /// 
        /// </summary>
        public int PowerOffCount
        {
            get
            {
                return _powerOffCount;
            }
            set
            {
                _powerOffCount = value;
            }
        } private int _powerOffCount;
        #endregion //PowerOffCount

        #region PowerAllCount
        /// <summary>
        /// 
        /// </summary>
        public int PowerAllCount
        {
            get
            {
                return this._powerOnCount + this._powerOffCount;
            }
        }
        #endregion //PowerAllCount

        #region HasFluxData
        /// <summary>
        /// 
        /// </summary>
        public bool HasFluxData
        {
            get
            {
                return _hasFluxData;
            }
            set
            {
                _hasFluxData = value;
            }
        } private bool _hasFluxData;
        #endregion //HasFluxData

        #region HasPowerData
        /// <summary>
        /// 
        /// </summary>
        public bool HasPowerData
        {
            get
            {
                return PowerAllCount > 0;
            }
        } 
        #endregion //HasPowerData


        public ReportItem ToReportItem(string dayOrMothDatetimeFormat, string valueDateTimeFormat)
        {
            ReportItem r = new ReportItem();
            r.DTText = this.DT.ToString(dayOrMothDatetimeFormat);
            if (this.HasFluxData)
            {
                r.BeginDTText = this.BeginDT.ToString(valueDateTimeFormat );
                r.EndDTText = this.EndDT.ToString(valueDateTimeFormat);
                r.BeginSumText = this.BeginSum.ToString(FormatStringProvider.DOUBLE_FORMAT);
                r.EndSumText = this.EndSum.ToString(FormatStringProvider.DOUBLE_FORMAT);
                r.UsedText = this.Used.ToString(FormatStringProvider.DOUBLE_FORMAT);
            }
            else
            {

            }

            if (this.HasPowerData)
            {
                r.PowerOffRateText = string.Format("{0}/{1}",
                    this.PowerOffCount, this.PowerAllCount);
            }
            return r;
        }
    }
}
