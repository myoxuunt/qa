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

        #region frmMain
        public frmMain()
        {
            InitializeComponent();
        }
        #endregion //frmMain

        #region FindMenuItem
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
        #endregion //FindMenuItem

        #region FindToolStrip
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
        #endregion //FindToolStrip

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public StatusStrip FindStatusStrip()
        {
            return this.statusStripMain;
        }

        #region IsDebugMode
        /// <summary>
        /// 
        /// </summary>
        private bool IsDebugMode
        {
            get
            {
                return QAApp.App.Config.CommandLineOptions.IsDebugMode;
            }
        }
        #endregion //IsDebugMode

        #region frmMain_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.mnuDebug.Visible = IsDebugMode;

            this.Text = QAApp.App.Config.AppName;

            //
            //
            this.mnuShowToolbar.Checked = this.toolStripMain.Visible;
            this.mnuShowStatusbar.Checked = this.statusStripMain.Visible;
        }
        #endregion //frmMain_Load

        #region mnuContentManager_Click
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
        #endregion //mnuContentManager_Click

        #region mnuLoadContent_Click
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
                IContent[] contents = ContentFactory.Create(path);

                foreach (IContent content in contents)
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
        #endregion //mnuLoadContent_Click

        #region mnuExit_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion //mnuExit_Click

        #region mnuAbout_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuAbout_Click(object sender, EventArgs e)
        {
            About();
        }
        #endregion //mnuAbout_Click

        #region About
        /// <summary>
        /// 
        /// </summary>
        private void About()
        {
            Config cfg = QAApp.App.Config;
            string s = string.Format(
                "{0}\r\n\r\n版本: {1}",
                cfg.AppName,
                cfg.Version);
            NUnit.UiKit.UserMessage.DisplayInfo(s);
        }
        #endregion //About

        #region mnuShowToolbar_Click
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
        #endregion //mnuShowToolbar_Click

        #region mnuShowStatusbar_Click
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
        #endregion //mnuShowStatusbar_Click

        #region notifyIcon1_BalloonTipClicked
        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {

        }
        #endregion //notifyIcon1_BalloonTipClicked
    }
}
