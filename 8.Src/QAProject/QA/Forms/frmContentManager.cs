using System;
using System.Reflection;
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
    public partial class frmContentManager : NUnit.UiKit.SettingsDialogBase 
    {
        public frmContentManager()
        {
            InitializeComponent();
        }

        private void frmContentManager_Load(object sender, EventArgs e)
        {
            LoadC();

        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadC()
        {
            ContentManager cm = QAApp.App.Container.ContentManager;
            foreach (IContent c in cm.ContentCollection)
            {
                //this.lstContent.Items.Add(c.GetType() + " : " + c.Name + " : " + c.Description);

                //Assembly assembly = c.GetType().Assembly;
                //String s = "";
                //PropertyInfo[] pis = assembly.GetType().GetProperties();
                //foreach (PropertyInfo pi in pis)
                //{
                //    object value = pi.GetValue(assembly, null);
                //    string name = pi.Name;

                //    s += string.Format("{0} : {1}\r\n", name, value);
                //}
                ////txtContent.Text = assembly.ToString();
                //txtContent.Text = s;
                Add(c);
            }

            if (this.lstContent.Items.Count > 0)
            {
                this.lstContent.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        List<IContent> _contentList = new List<IContent>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        private void Add(IContent content)
        {
            this.lstContent.Items.Add(content.GetType().FullName);
            this._contentList.Add(content);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = this.lstContent.SelectedIndex;
            if (idx >= 0)
            {
                IContent content = this._contentList[idx];
                ShowContentInfo(content);
            }
        }

        private void ShowContentInfo(IContent content)
        {
            Assembly assembly = content.GetType().Assembly;
            string s = string.Empty;
            s += string.Format("位置: {0}\r\n", assembly.Location);
            s += string.Format("名称: {0}\r\n", content.Name);
            s += string.Format("描述: {0}\r\n", content.Description);
            s += string.Format("序号: {0}\r\n", content.OrderNumber);
            s += string.Format("版本: {0}\r\n", assembly.GetName ().Version);

            this.txtContent.Text = s;
        }
    }
}
