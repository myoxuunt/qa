using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using QA.Interface;
namespace SimpleContent
{
    public class Class1 : Content 
    {
        public override string Description
        {
            get { return "a simple content description"; }
        }

        public override void Execute(string name, ParameterCollection inParameters, ParameterCollection outParameters)
        {
            switch (name)
            {
                case "run":
                    Form1 f = new Form1();
                    f.MdiParent = this.Container.MainForm;
                    f.Show();
                    break;
            }
        }

        public override void Load(System.Windows.Forms.ToolStripMenuItem parentMenuItem, System.Windows.Forms.ToolStrip parentToolStrip)
        {
            ToolStripMenuItem menu = new ToolStripMenuItem("SimpleMenu");
            menu.Click += new EventHandler(menu_Click);
            parentMenuItem.DropDownItems.Add(menu);

            ToolStripButton b = new ToolStripButton();
            b.Size = new Size(32, 32);
            b.Text = "btn";
            b.Image = Resource1.Icon1.ToBitmap ();
            b.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            b.TextImageRelation = TextImageRelation.ImageAboveText;
            b.Click += new EventHandler(b_Click);
            parentToolStrip.Items.Add(b);
        }

        void b_Click(object sender, EventArgs e)
        {
            Execute("run", null, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void menu_Click(object sender, EventArgs e)
        {
            Execute("run", null, null);
        }

        public override string Name
        {
            get { return "simple content ."; }
        }
    }
}
