using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace HDC.FluxQuery
{
    abstract public class ReportFactory
    {
        protected string _stationName;
        protected DataTable _tblFlux;
        protected DataTable _tblPowerOn;
        protected DataTable _tblPowerOff;
        protected ItemCollection _items = new ItemCollection();
        public ItemCollection Items
        {
            get
            {
                return this._items;
            }
        }
        protected ReportFactory(string stationName )
        {
            this._stationName = stationName;
        }

        abstract public void Create();
    }

    public class YearReportFactory : ReportFactory 
    {
        private DateTime _year;

        public YearReportFactory(string stationName, DateTime year)
            : base ( stationName )
        {
            _year = new DateTime(year.Year, 1, 1);
        }

        public override void Create()
        {
            _tblFlux = DBI.ExecuteFluxYearReportDataTable(_stationName, _year);
            _tblPowerOn = DBI.ExecutePowerYearReportdDataTable(_stationName, _year, 1);
            _tblPowerOff = DBI.ExecutePowerYearReportdDataTable(_stationName, _year, 0);

            DateTime b = _year;
            while (true)
            {
                AddMonth(b.Month);
                b = b.AddMonths(1);
                if (b.Year != _year.Year)
                {
                    break;
                }
            }
        }

        private void AddMonth(int month)
        {
            DateTime monthOfDT = new DateTime(_year.Year, month, 1);
            Item n = new Item(monthOfDT);
            AddMonthFluxInfo(n);

            AddMonthPowerInfo(n);

            this._items.Add(n);
        }

        private bool AddMonthFluxInfo(Item n)
        {
            foreach (DataRow row in _tblFlux.Rows)
            {
                int mon = (int)row["month"];
                if (mon == n.DT.Month)
                {
                    n.BeginDT = Convert.ToDateTime(row["dtMin"]);
                    n.EndDT = Convert.ToDateTime(row["dtMax"]);
                    n.BeginSum = Convert.ToDouble(row["sumMin"]);
                    n.EndSum = Convert.ToDouble(row["sumMax"]);
                    n.HasFluxData = true;
                    return true;
                }
            }
            return false;
        }

        private void AddMonthPowerInfo(Item n)
        {
            foreach (DataRow row in _tblPowerOn.Rows)
            {
                int mon = (int)row["month"];
                if (mon == n.DT.Month )
                {
                    n.PowerOnCount = Convert.ToInt32(row["Count"]);
                }
            }

            foreach (DataRow row in _tblPowerOff.Rows)
            {
                int mon = (int)row["month"];
                if (mon == n.DT.Month)
                {
                    n.PowerOffCount = Convert.ToInt32(row["Count"]);
                }
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class MonthReportFactory : ReportFactory 
    {
        private DateTime _month;

        public MonthReportFactory(string stationName, DateTime month)
            : base ( stationName )
        {
            _month = month;
        }



        /// <summary>
        /// 
        /// </summary>
        override public void Create()
        {
            _tblFlux = DBI.ExecuteFluxMonthReportDataTable(_stationName, _month);
            _tblPowerOn = DBI.ExecutePowerMonthReportdDataTable(_stationName, _month, 1);
            _tblPowerOff = DBI.ExecutePowerMonthReportdDataTable(_stationName, _month, 0);


            DateTime b = new DateTime(_month.Year, _month.Month, 1);
            while (true)
            {
                AddDay(b.Day);
                b = b.AddDays(1d);
                if (b.Month != _month.Month)
                {
                    break;
                }
            }
        }

        private void AddDay(int day)
        {
            DateTime dayOfDT = new DateTime(this._month.Year, this._month.Month, day);
            Item n = new Item(dayOfDT);

            AddFluxInfo(n);
            AddPowerInfo(n);

            this._items.Add(n);
        }

        private void AddPowerInfo(Item n)
        {
            foreach (DataRow row in _tblPowerOn.Rows)
            {
                int day = (int)row["day"];
                if (day == n.DT.Day)
                {
                    n.PowerOnCount = Convert.ToInt32(row["Count"]);
                }
            }

            foreach (DataRow row in _tblPowerOff.Rows)
            {
                int day = (int)row["day"];
                if (day == n.DT.Day)
                {
                    n.PowerOffCount = Convert.ToInt32(row["Count"]);
                }
            }
        }

        private void AddFluxInfo(Item n)
        {
            foreach (DataRow row in _tblFlux.Rows)
            {
                int day = (int)row["day"];
                if (day == n.DT.Day)
                {
                    n.BeginDT = Convert.ToDateTime(row["dtMin"]);
                    n.EndDT = Convert.ToDateTime(row["dtMax"]);
                    n.BeginSum = Convert.ToDouble(row["sumMin"]);
                    n.EndSum = Convert.ToDouble(row["sumMax"]);
                    n.HasFluxData = true;
                }
            }
        }
    }
}
