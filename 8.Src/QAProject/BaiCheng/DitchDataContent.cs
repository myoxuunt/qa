
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QA.Interface;
using System.Windows.Forms;


namespace BaiCheng
{
    public class DitchDataContent : ContentBase 
    {
        public override string Name
        {
            get { return this.GetType ().Name ; }
        }

        public override string Description
        {
            get { return string.Empty ; }
        }

        public override void Load(
                System.Windows.Forms.ToolStripMenuItem parentMenuItem, 
                System.Windows.Forms.ToolStrip parentToolStrip)
        {
            ToolStripMenuItem m = new ToolStripMenuItem();
            m.Text = "历史数据(&H)";
            m.Click += new EventHandler(m_Click);
            parentMenuItem.DropDownItems.Add(m);


            ToolStripButton b = new ToolStripButton();
            b.Text = "历史数据";
            b.Image = Images.History.ToBitmap();
            b.TextImageRelation = TextImageRelation.ImageAboveText;
            b.Click += new EventHandler(m_Click);
            parentToolStrip.Items.Add(b);
        }

        void m_Click(object sender, EventArgs e)
        {
            Xdgk.UI.Forms.FormHelper.ShowAndActiveFluxQuery(
                    this.Container.MainForm,
                    typeof(frmMeasureDitchData));
        }

        public override void Execute(string name, ParameterCollection inParameters, ParameterCollection outParameters)
        {
        }
    }

}
