
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QA.Interface;
using System.Windows.Forms;


namespace BaiCheng
{
    public class LastDataContent : ContentBase
    {
        public LastDataContent()
        {
            this.OrderNumber = -1;
        }
        public override string Name
        {
            get { return this.GetType ().Name ; }
        }

        public override string Description
        {
            get { return string.Empty; }
        }

        public override void Load(ToolStripMenuItem parentMenuItem, ToolStrip parentToolStrip)
        {
            ToolStripMenuItem m = new ToolStripMenuItem();
            m.Text = "最新数据(&L)";
            m.Click += new EventHandler(m_Click);
            parentMenuItem.DropDownItems.Add(m);


            ToolStripButton b = new ToolStripButton();
            b.Text = "最新数据";
            b.Image = Images.Last.ToBitmap();
            b.TextImageRelation = TextImageRelation.ImageAboveText;
            b.Click += new EventHandler(m_Click);
            parentToolStrip.Items.Add(b);
        }

        void m_Click(object sender, EventArgs e)
        {
            Xdgk.UI.Forms.FormHelper.ShowAndActiveFluxQuery(
                    this.Container.MainForm,
                    typeof(frmLast));
        }

        public override void Execute(string name, ParameterCollection inParameters, ParameterCollection outParameters)
        {
        }
    }

}
