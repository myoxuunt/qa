
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QA.Interface;
using System.Windows.Forms;


namespace BaiCheng
{
    public class CurveContent : ContentBase
    {

        public CurveContent()
        {
            this.OrderNumber = 3;
        }

        public override void Load(ToolStripMenuItem parentMenuItem, ToolStrip parentToolStrip)
        {
            ToolStripMenuItem m = new ToolStripMenuItem();
            m.Text = "历史曲线(&L)";
            m.Click += new EventHandler(m_Click);
            parentMenuItem.DropDownItems.Add(m);


            ToolStripButton b = new ToolStripButton();
            b.Text = "历史曲线";
            b.Image = Images.Graph.ToBitmap();
            b.TextImageRelation = TextImageRelation.ImageAboveText;
            b.Click += new EventHandler(m_Click);
            parentToolStrip.Items.Add(b);
        }

        void m_Click(object sender, EventArgs e)
        {
            Xdgk.UI.Forms.FormHelper.ShowAndActiveFluxQuery(this.Container.MainForm,
                    typeof(frmCurve));
        }

        public override void Execute(string name, ParameterCollection inParameters, ParameterCollection outParameters)
        {
        }
    }

}
