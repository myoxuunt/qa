using System;
using System.Drawing;
using Xdgk.Common;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

namespace QA.Content.Test
{
    public class Class1 : QA.Interface.ContentBase
    {
        Timer _t = new Timer();
        public Class1()
        {
            _t.Interval = 10*1000;
            _t.Tick += new EventHandler(_t_Tick);
            _t.Start();
        }

        void _t_Tick(object sender, EventArgs e)
        {
            this.Container.ContentManager.Execute("Name", DateTime.Now.ToString () , null, null);
        }

        #region IContent 成员

        override public string Description
        {
            get { return "<Description>"; }
        }

        override public void Load(System.Windows.Forms.ToolStripMenuItem parentMenuItem, 
            System.Windows.Forms.ToolStrip parentToolStrip)
        {
            ToolStripMenuItem value = new ToolStripMenuItem("test");
            value.Click += new EventHandler(value_Click);
            parentMenuItem.DropDownItems.Add(value);
            //parentMenuItem.Owner.Items.Add(value);


            ToolStripButton btn = new ToolStripButton("test btn");
            btn.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            //btn.Size = new System.Drawing.Size(23, 22);
            //btn.Image = new QA.Content.Test.Resource1 ()
            Image img =  Image.FromFile("c:\\add.bmp");
            btn.Image = img;
            btn.Click += new EventHandler(btn_Click);
            parentToolStrip.Items.Add(btn);
            //MessageBox.Show(parentToolStrip.Items.Count.ToString ());
        }


        void btn_Click(object sender, EventArgs e)
        {
            ////MessageBox.Show("test ttttt");
            
            //Form1 f = new Form1();
            ////MessageBox.Show("sm");
            //f.MdiParent = this.Container.MainForm;
            ////this.Container.MainForm.MdiChildren.
            //f.Show();
            GetForm();
        }

        void value_Click(object sender, EventArgs e)
        {
            GetForm().Activate ();
            
            this.Container.ContentManager.Execute("Name", "ttttext", null, null);
        }

        private Form _f = null;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Form GetForm()
        {
            if (_f == null || _f.IsDisposed)
            {
                Form f = new Form1();
                f.MdiParent = this.Container.MainForm;
                //MessageBox.Show(this.Container.MainForm.MdiChildren.Length.ToString());
                f.Show();
                _f = f;
            }
            return _f;
            //MessageBox.Show("test ttttt");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="inParameters"></param>
        /// <param name="outParameters"></param>
        public override void Execute(string name, QA.Interface.ParameterCollection inParameters, QA.Interface.ParameterCollection outParameters)
        {
            //MessageBox.Show(name);
            Form f = GetForm();
            f.Activate();
            f.Text = DateTime.Now.ToString() + name;
        }

        public override string Name
        {
            get { return "Name"; }
        }
        //override public void Active(activeparam param)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion
    }
}
