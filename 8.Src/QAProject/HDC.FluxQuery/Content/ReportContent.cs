
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
    public class ReportContent : QA.Interface.ContentBase
    {
        public ReportContent()
        {
            this.OrderNumber = 4;
        }

        public override void Load(ToolStripMenuItem parentMenuItem, ToolStrip parentToolStrip)
        {

            ToolStripButton monthReportButton = new ToolStripButton(Strings.StatisticsMonth );
            monthReportButton.Image = QRes.ImageManager.Report.ToBitmap();
            monthReportButton.TextImageRelation = TextImageRelation.ImageAboveText;
            //monthReportButton.Width = 100;
            monthReportButton.Click += new EventHandler(monthReportButton_Click);

            ToolStripButton yearReportButton = new ToolStripButton(Strings.StatisticsYear);
            yearReportButton.Image = QRes.ImageManager.Report.ToBitmap();
            yearReportButton.TextImageRelation = TextImageRelation.ImageAboveText;
            yearReportButton.Click += new EventHandler(yearReportButton_Click);

            parentToolStrip.Items.Add(monthReportButton);
            parentToolStrip.Items.Add(yearReportButton);


            ToolStripItem menuMonth = parentMenuItem.DropDown.Items.Add(Strings.StatisticsMonthMenu);
            menuMonth.Click += new EventHandler(menuMonth_Click);

            ToolStripItem menuYear = parentMenuItem.DropDown.Items.Add(Strings.StatisticsYearMenu);
            menuYear.Click += new EventHandler(menuYear_Click);
        }

        void menuYear_Click(object sender, EventArgs e)
        {
            yearReportButton_Click(null, null);
        }

        void menuMonth_Click(object sender, EventArgs e)
        {
            monthReportButton_Click(null, null);
        }


        void monthReportButton_Click(object sender, EventArgs e)
        {
            Xdgk.UI.Forms.FormHelper.ShowAndActiveFluxQuery(
                this.Container.MainForm, 
                typeof(frmMonthReport));
        }

        void yearReportButton_Click(object sender, EventArgs e)
        {
            Xdgk.UI.Forms.FormHelper.ShowAndActiveFluxQuery(
                this.Container.MainForm,
                typeof(frmYearReport));
        }

        public override void Execute(string name, ParameterCollection inParameters, ParameterCollection outParameters)
        {
            throw new NotImplementedException();
        }
    }

}
