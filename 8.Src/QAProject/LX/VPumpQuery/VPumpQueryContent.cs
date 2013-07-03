using System;
using System.Collections.Generic;
using System.Text;
using QA.Interface;
using System.Windows.Forms;
using Xdgk.UI.Forms;

namespace VPumpQuery
{
    public class VPumpQueryContent : ContentBase 
    {
        public override void Load(System.Windows.Forms.ToolStripMenuItem parentMenuItem, 
            System.Windows.Forms.ToolStrip parentToolStrip)
        {
            AddPumpDataLastUI(parentMenuItem, parentToolStrip);
            AddPumpDataUI(parentMenuItem, parentToolStrip);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentMenuItem"></param>
        /// <param name="parentToolStrip"></param>
        private void AddPumpDataUI(System.Windows.Forms.ToolStripMenuItem parentMenuItem, System.Windows.Forms.ToolStrip parentToolStrip)
        {

            ToolStripItem item = parentMenuItem.DropDownItems.Add(Strings.mnu_pump_query);
            item.Click += new EventHandler(item_Click);


            ToolStripButton pumpQueryButton = new ToolStripButton();
            pumpQueryButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            pumpQueryButton.TextImageRelation = TextImageRelation.ImageAboveText;
            pumpQueryButton.Text = Strings.title_pump_query;
            pumpQueryButton.Image = QRes.ImageManager.History.ToBitmap();
            pumpQueryButton.Click += new EventHandler(pumpQueryButton_Click);

            parentToolStrip.Items.Add(pumpQueryButton);
        }

        private void AddPumpDataLastUI(System.Windows.Forms.ToolStripMenuItem parentMenuItem, System.Windows.Forms.ToolStrip parentToolStrip)
        {
            ToolStripItem pumpLastItem = parentMenuItem.DropDownItems.Add(Strings.mnu_pump_last);
            pumpLastItem .Click += new EventHandler(pumpLastItem_Click);

            ToolStripButton pumpLastButton = new ToolStripButton();
            pumpLastButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            pumpLastButton.TextImageRelation = TextImageRelation.ImageAboveText;
            pumpLastButton.Text = Strings.title_pump_last;
            pumpLastButton.Image = QRes.ImageManager.Last.ToBitmap();
            pumpLastButton.Click  += new EventHandler(pumpLastButton_Click);

            parentToolStrip.Items.Add(pumpLastButton);
        }

        void pumpLastButton_Click(object sender, EventArgs e)
        {
            FormHelper.ShowAndActiveFluxQuery(this.Container.MainForm, typeof(frmPumpDataLast ));
        }

        void pumpLastItem_Click(object sender, EventArgs e)
        {
            FormHelper.ShowAndActiveFluxQuery(this.Container.MainForm, typeof(frmPumpDataLast ));
        }

        void pumpQueryButton_Click(object sender, EventArgs e)
        {
            FormHelper.ShowAndActiveFluxQuery(this.Container.MainForm, typeof(frmPumpData));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void item_Click(object sender, EventArgs e)
        {
            FormHelper.ShowAndActiveFluxQuery(this.Container.MainForm, typeof(frmPumpData));
        }

        public override void Execute(string name, ParameterCollection inParameters, ParameterCollection outParameters)
        {
            throw new NotImplementedException();
        }
    }
}
