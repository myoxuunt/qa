using System;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using Xdgk.Common;
using Xdgk.Common.UI.Forms;
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
            hdQueryButton.Image = QRes.ImageManager.Lightning.ToBitmap();
            hdQueryButton.Click += new EventHandler(hdQueryButton_Click);

            parentToolStrip.Items.Add(hdQueryButton);
        }
        #endregion //CreateHDQueryUI

        #region hdQueryButton_Click
        void hdQueryButton_Click(object sender, EventArgs e)
        {
            Xdgk.UI.Forms.FormHelper.ShowAndActiveFluxQuery(this.Container.MainForm, typeof(frmHDQuery));
        }
        #endregion //hdQueryButton_Click

        #region hdMenuItem_Click
        void hdMenuItem_Click(object sender, EventArgs e)
        {
            Xdgk.UI.Forms.FormHelper.ShowAndActiveFluxQuery(this.Container.MainForm, typeof(frmHDQuery));
        }
        #endregion //hdMenuItem_Click
    }

    /// <summary>
    /// 
    /// </summary>
    public class ReportContent : QA.Interface.ContentBase
    {
        public ReportContent()
        {
            this.OrderNumber = 4;
        }

        public override void Load(ToolStripMenuItem parentMenuItem, ToolStrip parentToolStrip)
        {
            ToolStripDropDownButton reportButton = new ToolStripDropDownButton();

            //reportButton.Width = 120;
            reportButton.Image = QRes.ImageManager.Report.ToBitmap ();
            reportButton.TextImageRelation = TextImageRelation.ImageAboveText;
            reportButton.Text = "统计报表";


            ToolStripButton monthReportButton = new ToolStripButton("月统计报表");
            monthReportButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            monthReportButton.Width = 100;
            monthReportButton.Click += new EventHandler(monthReportButton_Click);

            ToolStripButton yearReportButton = new ToolStripButton("年统计报表");
            yearReportButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            yearReportButton.Click += new EventHandler(yearReportButton_Click);

            reportButton.DropDownItems.Add(monthReportButton);
            reportButton.DropDownItems.Add(yearReportButton);

            parentToolStrip.Items.Add(reportButton);
        }


        void monthReportButton_Click(object sender, EventArgs e)
        {
            Xdgk.UI.Forms.FormHelper.ShowAndActiveFluxQuery(this.Container.MainForm, typeof(frmMonthReport));
        }

        void yearReportButton_Click(object sender, EventArgs e)
        {
        }

        public override void Execute(string name, ParameterCollection inParameters, ParameterCollection outParameters)
        {
            throw new NotImplementedException();
        }
    }
}
