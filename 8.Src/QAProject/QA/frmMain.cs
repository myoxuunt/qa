using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Xdgk.Common;
using QA.Interface;

namespace QA
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ToolStripMenuItem FindMenuItem ( string name )
        {
            foreach (ToolStripItem item in this.MainMenuStrip.Items)
            {
                if (StringHelper.Equal(item.Name, name))
                {
                    return (ToolStripMenuItem)item;
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ToolStrip FindToolStrip(string name )
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is ToolStrip)
                {
                    ToolStrip toolStrip = ctrl as ToolStrip;
                    if (Xdgk.Common.StringHelper.Equal(ctrl.Name, name))
                    {
                        return toolStrip;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = QAApp.App.Config.AppName;

            //
            //
            this.mnuShowToolbar.Checked = this.toolStripMain.Visible;
            this.mnuShowStatusbar.Checked = this.statusStripMain.Visible;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuContentManager_Click(object sender, EventArgs e)
        {
            frmContentManager f = new frmContentManager();
            f.ShowDialog(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuLoadContent_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.dll|*.dll";
            DialogResult dr = ofd.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                string path = ofd.FileName;
                IContent content = ContentFactory.Create(path);

                if (content != null)
                {
                    if (QAApp.App.Container.ContentManager.ContentCollection.Contains(content.Name))
                    {
                        NUnit.UiKit.UserMessage.DisplayFailure("exist " + content.Name);
                    }
                    else
                    {
                        QAApp.App.Container.ContentManager.Add(content);
                        content.Load(this.mnuDebug, this.toolStripMain);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuAbout_Click(object sender, EventArgs e)
        {
            About();
        }

        /// <summary>
        /// 
        /// </summary>
        private void About()
        {
            string s = string.Format(
                "{0}\r\n\r\n版本: {1}",
                QAApp.App.Config.AppName,
                Application.ProductVersion);
            NUnit.UiKit.UserMessage.DisplayInfo(s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuShowToolbar_Click(object sender, EventArgs e)
        {
            this.toolStripMain.Visible = !this.mnuShowToolbar.Checked;
            this.mnuShowToolbar.Checked = !this.mnuShowToolbar.Checked;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuShowStatusbar_Click(object sender, EventArgs e)
        {
            this.statusStripMain.Visible = !this.mnuShowStatusbar.Checked;
            this.mnuShowStatusbar.Checked = !this.mnuShowStatusbar.Checked;
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {

        }
    }
}
