using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace HDC.FluxQuery
{
    public partial class UCCondition : UserControl
    {
        static public readonly string TEXT_ALL = "<全部>";
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler QueryEvent;

        /// <summary>
        /// 
        /// </summary>
        public UCCondition()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public string SelectedStationName
        {
            get
            {
                return this.cmbStationName.Text;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int SelectedStationID
        {
            get
            {
                return (int)this.cmbStationName.SelectedValue;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void BindStationName()
        {
            //HunBeiDBDataContext db = DBFactory.Create();
            //var q = from p in db.tblStation
            //        select new
            //        {
            //            Text = p.Name,
            //            Value = p.StationID
            //            //Value = p
            //        };
            //System.Collections.IList list = q.ToList();
            //if (IsAddAll)
            //{
            //    list.Insert(0,
            //        new
            //        {
            //            Text = "<全部>",
            //            Value = -1
            //        }
            //        );

            //}
            DataTable tbl = DBI.GetStationDataTable();
            this.cmbStationName.DisplayMember = "StationName";
            this.cmbStationName.ValueMember = "StationName";
            this.cmbStationName.DataSource = tbl;

        }

        #region IsAddAll
        /// <summary>
        /// 
        /// </summary>
        public bool IsAddAll
        {
            get
            {
                return _isAddAll;
            }
            set
            {
                _isAddAll = value;
            }
        } private bool _isAddAll = true;
        #endregion //IsAddAll

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCCondition_Load(object sender, EventArgs e)
        {
            //BindStationName();
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Begin
        {
            get
            {
                return this.dtpBeginDate.Value.Date + this.dtpBeginTime.Value.TimeOfDay;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime End
        {
            get
            {
                return this.dtpEndDate.Value.Date + this.dtpEndTime.Value.TimeOfDay;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (this.QueryEvent != null)
            {
                QueryEvent(this, EventArgs.Empty);
            }
        }
    }
}
