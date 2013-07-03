using System;
using System.Collections.Generic;
using System.Text;
using QA.Interface;
using System.Windows.Forms;
using Xdgk.UI.Forms;

namespace VGateQuery
{
    public class VGateQueryContent : ContentBase 
    {
        public override void Load(System.Windows.Forms.ToolStripMenuItem parentMenuItem, 
            System.Windows.Forms.ToolStrip parentToolStrip)
        {
            AddGateDataLastUI(parentMenuItem, parentToolStrip);
            AddGateDataUI(parentMenuItem, parentToolStrip);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentMenuItem"></param>
        /// <param name="parentToolStrip"></param>
        private void AddGateDataUI(System.Windows.Forms.ToolStripMenuItem parentMenuItem, System.Windows.Forms.ToolStrip parentToolStrip)
        {

            ToolStripItem item = parentMenuItem.DropDownItems.Add(Strings.mnu_gate_query);
            item.Click += new EventHandler(item_Click);


            ToolStripButton gateQueryButton = new ToolStripButton();
            gateQueryButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            gateQueryButton.TextImageRelation = TextImageRelation.ImageAboveText;
            gateQueryButton.Text = Strings.title_gate_query;
            gateQueryButton.Image = QRes.ImageManager.History.ToBitmap();
            gateQueryButton.Click += new EventHandler(gateQueryButton_Click);

            parentToolStrip.Items.Add(gateQueryButton);
        }

        private void AddGateDataLastUI(System.Windows.Forms.ToolStripMenuItem parentMenuItem, System.Windows.Forms.ToolStrip parentToolStrip)
        {
            ToolStripItem gateLastItem = parentMenuItem.DropDownItems.Add(Strings.mnu_gate_last);
            gateLastItem .Click += new EventHandler(gateLastItem_Click);

            ToolStripButton gateLastButton = new ToolStripButton();
            gateLastButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            gateLastButton.TextImageRelation = TextImageRelation.ImageAboveText;
            gateLastButton.Text = Strings.title_gate_last;
            gateLastButton.Image = QRes.ImageManager.Last.ToBitmap();
            gateLastButton.Click  += new EventHandler(gateLastButton_Click);

            parentToolStrip.Items.Add(gateLastButton);
        }

        void gateLastButton_Click(object sender, EventArgs e)
        {
            FormHelper.ShowAndActiveFluxQuery(this.Container.MainForm, typeof(frmGateDataLast ));
        }

        void gateLastItem_Click(object sender, EventArgs e)
        {
            FormHelper.ShowAndActiveFluxQuery(this.Container.MainForm, typeof(frmGateDataLast ));
        }

        void gateQueryButton_Click(object sender, EventArgs e)
        {
            FormHelper.ShowAndActiveFluxQuery(this.Container.MainForm, typeof(frmGateData));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void item_Click(object sender, EventArgs e)
        {
            FormHelper.ShowAndActiveFluxQuery(this.Container.MainForm, typeof(frmGateData));
        }

        public override void Execute(string name, ParameterCollection inParameters, ParameterCollection outParameters)
        {
            throw new NotImplementedException();
        }
    }
}
