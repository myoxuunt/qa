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
    public class HDContent : QA.Interface.ContentBase
    {
        public HDContent()
        {
            this.OrderNumber = 1;
        }

        public override string Name
        {
            get { return this.GetType().Name; }
        }

        public override string Description
        {
            get { return string.Empty; }
        }

        public override void Execute(string name, QA.Interface.ParameterCollection inParameters, QA.Interface.ParameterCollection outParameters)
        {
            // do nothing
        }

        public override void Load(ToolStripMenuItem parentMenuItem, ToolStrip parentToolStrip)
        {

            CreateHDQueryUI(parentMenuItem, parentToolStrip);
        }

        #region CreateHDQueryUI
        private void CreateHDQueryUI(System.Windows.Forms.ToolStripMenuItem parentMenuItem, System.Windows.Forms.ToolStrip parentToolStrip)
        {
            ToolStripItem hdMenuItem = parentMenuItem.DropDownItems.Add(Strings.mnu_hd_query);
            hdMenuItem.Click += new EventHandler(hdMenuItem_Click);


            ToolStripButton hdQueryButton = new ToolStripButton();
            hdQueryButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            hdQueryButton.TextImageRelation = TextImageRelation.ImageAboveText;
            hdQueryButton.Text = Strings.title_hd_query;
            hdQueryButton.Image = Images.Lightning.ToBitmap();
            hdQueryButton.Click += new EventHandler(hdQueryButton_Click);

            parentToolStrip.Items.Add(hdQueryButton);
        }
        #endregion //CreateHDQueryUI

        #region hdQueryButton_Click
        void hdQueryButton_Click(object sender, EventArgs e)
        {
            FormHelper.ShowAndActiveFluxQuery(this.Container.MainForm, typeof(frmHDQuery));
        }
        #endregion //hdQueryButton_Click

        #region hdMenuItem_Click
        void hdMenuItem_Click(object sender, EventArgs e)
        {
            FormHelper.ShowAndActiveFluxQuery(this.Container.MainForm, typeof(frmHDQuery));
        }
        #endregion //hdMenuItem_Click
    }

    public class AlarmContent : ContentBase
    {
        private AlarmManager _alarmManager;
        private ToolStripItem _alarmStatusLabel;

        public AlarmContent()
        {
            this.OrderNumber = 3;

            _alarmStatusLabel = new ToolStripStatusLabel();
            _alarmStatusLabel.Image = QRes.ImageManager.AlarmStatus.ToBitmap();
            _alarmStatusLabel.Click += new EventHandler(a_Click);

            _alarmManager = new AlarmManager();
            _alarmManager.AddedAlarm += new EventHandler(_alarmManager_AddedAlarm);

        }

        void _alarmManager_AddedAlarm(object sender, EventArgs e)
        {
            RefreshStatus();
        }

        private void RefreshStatus()
        {
            if (this._alarmManager.StationAlarms.Count == 0)
            {
                _alarmStatusLabel.Text = "无断电报警";
            }
            else
            {
                _alarmStatusLabel.Text = string.Format("{0} 条断电报警", this._alarmManager.StationAlarms.Count);
            }
        }

        public override void Load(ToolStripMenuItem parentMenuItem, ToolStrip parentToolStrip)
        {
            // do nothing
            //
        }

        public override void Execute(string name, ParameterCollection inParameters, ParameterCollection outParameters)
        {
            // do nothing
            //
        }

        public override void Load(StatusStrip parentStrip)
        {

            //a.AutoToolTip = true;
            //a.Width = 300;
            //a.AutoSize = false;
            //a.ForeColor = Color.Red;
            //a.BackColor = Color.Black;
            //a.Alignment = ToolStripItemAlignment.Right;
            parentStrip.Items.Add(_alarmStatusLabel);
            //parentStrip.Text = "123";

            RefreshStatus();

            _alarmManager.Start();
        }

        void a_Click(object sender, EventArgs e)
        {
            ToolStripStatusLabel a = sender as ToolStripStatusLabel;
            a.Text = DateTime.Now.ToString();
        }
    }

    public class AlarmManager
    {
        public event EventHandler AddedAlarm;

        private Timer _timer;
        public AlarmManager()
        {
            _timer = new Timer();
            _timer.Interval = 1000 * 3;
            _timer.Tick += new EventHandler(_timer_Tick);

        }

        public void Start ()
        {
            _timer.Start();
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            DateTime from = this.StationAlarms.GetLastAlarmDateTime();

            DataTable tbl = DBI.ExecutePowerAlarmDataTable(from);
            if (tbl.Rows.Count > 0)
            {
                foreach (DataRow row in tbl.Rows)
                {
                    StationAlarm a = CreateAlarm(row);
                    this.StationAlarms.Add(a);
                }

                if (AddedAlarm != null)
                {
                    AddedAlarm(this, EventArgs.Empty);
                }

                // TODO: play sound
                //

            }
        }

        private StationAlarm CreateAlarm(DataRow row)
        {
            string name = row["StationName"].ToString();
            DateTime dt = Convert.ToDateTime(row["DT"]);
            string info = "断电";

            return new StationAlarm(dt, name, info);
        }

        #region StationAlarms
        /// <summary>
        /// 
        /// </summary>
        public StationAlarmCollection StationAlarms
        {
            get
            {
                if (_stationAlarms == null)
                {
                    _stationAlarms = new StationAlarmCollection();
                }
                return _stationAlarms;
            }
        } private StationAlarmCollection _stationAlarms;
        #endregion //StationAlarms

    }

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

    /// <summary>
    /// 
    /// </summary>
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
