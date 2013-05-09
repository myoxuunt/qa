
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

}
