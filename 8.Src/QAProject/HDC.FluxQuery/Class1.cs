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
        public DBI(string connString)
            : base(connString)
        {

        }

        static private DBI GetDefault()
        {
            if (_dbi == null)
            {
                _dbi = new DBI(ConfigurationManager.ConnectionStrings[1].ConnectionString);
            }
            return _dbi;
        } static private DBI _dbi;

        static public DataTable GetStationDataTable()
        {
            DBI dbi = GetDefault();
            string sql = "select * from vStationDevice";
            return dbi.ExecuteDataTable(sql);
        }

        internal static DataTable ExecuteFluxDataTable(DateTime b, DateTime e, string stationName)
        {
            string sql = "select * from vFluxData where stationName = @stationName and dt >= @b and dt < @e";
            SqlCommand cmd = new SqlCommand ( sql );
            DBIBase.AddSqlParameter(cmd, "stationName", stationName);
            DBIBase.AddSqlParameter(cmd, "b", b);
            DBIBase.AddSqlParameter(cmd, "e", e);

            return GetDefault().ExecuteDataTable(cmd);
        }
    }

    public class DataQuery : QA.Interface.ContentBase 
    {
        public override string Name
        {
            get { return this.GetType().Name; }
        }

        public override string Description
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentMenuItem"></param>
        /// <param name="parentToolStrip"></param>
        public override void Load(System.Windows.Forms.ToolStripMenuItem parentMenuItem, 
            System.Windows.Forms.ToolStrip parentToolStrip)
        {
            Console.WriteLine(parentMenuItem.Name);
            //ToolStripMenuItem item = 
            ToolStripItem item = parentMenuItem.DropDownItems.Add("query");
            item.Click += new EventHandler(item_Click);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void item_Click(object sender, EventArgs e)
        {
            Form f = GetOrCreateForm(typeof(frmDataQuery));
            f.Show();
            f.Activate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formType"></param>
        /// <returns></returns>
        private Form GetOrCreateForm(Type formType)
        {
            Form r = null;
            foreach (Form f in this.Container.MainForm.MdiChildren)
            {
                if (f.GetType() == formType)
                {
                    r = f;
                    break;
                }
            }

            if (r == null)
            {
                r = (Form)Activator.CreateInstance(formType);
                r.MdiParent = this.Container.MainForm;
            }
            return r;
        }

        public override void Execute(string name, QA.Interface.ParameterCollection inParameters, 
            QA.Interface.ParameterCollection outParameters)
        {
        }
    }
}
