using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using Xdgk.Common;

namespace HDC.FluxQuery
{

    /// <summary>
    /// 
    /// </summary>
    public class DataQueryContent : QA.Interface.ContentBase 
    {

        #region Name
        public override string Name
        {
            get { return this.GetType().Name; }
        }
        #endregion //Name

        #region Description
        public override string Description
        {
            get { return string.Empty; }
        }
        #endregion //Description

        #region Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentMenuItem"></param>
        /// <param name="parentToolStrip"></param>
        public override void Load(System.Windows.Forms.ToolStripMenuItem parentMenuItem, 
            System.Windows.Forms.ToolStrip parentToolStrip)
        {
            //Console.WriteLine(parentMenuItem.Name);

            CreateFluxQueryUI(parentMenuItem, parentToolStrip);
            CreateHDQueryUI(parentMenuItem, parentToolStrip);

        }
        #endregion //Load

        #region CreateHDQueryUI
        private void CreateHDQueryUI(System.Windows.Forms.ToolStripMenuItem parentMenuItem, System.Windows.Forms.ToolStrip parentToolStrip)
        {
            ToolStripItem hdMenuItem = parentMenuItem.DropDownItems.Add(Strings.mnu_hd_query);
            hdMenuItem.Click += new EventHandler(hdMenuItem_Click);


            ToolStripButton hdQueryButton = new ToolStripButton();
            hdQueryButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            hdQueryButton.TextImageRelation = TextImageRelation.ImageAboveText;
            hdQueryButton.Text = Strings.title_hd_query;
            hdQueryButton.Image = Images.Lightning.ToBitmap();
            hdQueryButton.Click += new EventHandler(hdQueryButton_Click);

            parentToolStrip.Items.Add(hdQueryButton);
        }
        #endregion //CreateHDQueryUI

        #region hdQueryButton_Click
        void hdQueryButton_Click(object sender, EventArgs e)
        {
            ShowAndActiveFluxQuery(typeof(frmHDQuery));
        }
        #endregion //hdQueryButton_Click

        #region hdMenuItem_Click
        void hdMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndActiveFluxQuery(typeof(frmHDQuery));
        }
        #endregion //hdMenuItem_Click


        #region CreateFluxQueryUI
        private void CreateFluxQueryUI(System.Windows.Forms.ToolStripMenuItem parentMenuItem, System.Windows.Forms.ToolStrip parentToolStrip)
        {
            ToolStripItem item = parentMenuItem.DropDownItems.Add(Strings.mnu_flux_query);
            item.Click += new EventHandler(item_Click);


            ToolStripButton fluxQueryButton = new ToolStripButton();
            fluxQueryButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            fluxQueryButton.TextImageRelation = TextImageRelation.ImageAboveText;
            fluxQueryButton.Text = Strings.title_flux_form;
            fluxQueryButton.Image = Images.History.ToBitmap();
            fluxQueryButton.Click += new EventHandler(fluxQueryButton_Click);

            parentToolStrip.Items.Add(fluxQueryButton);
        }
        #endregion //CreateFluxQueryUI

        #region fluxQueryButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void fluxQueryButton_Click(object sender, EventArgs e)
        {
            ShowAndActiveFluxQuery(typeof(frmDataQuery));
        }
        #endregion //fluxQueryButton_Click

        #region item_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void item_Click(object sender, EventArgs e)
        {
            ShowAndActiveFluxQuery(typeof(frmDataQuery));
        }
        #endregion //item_Click

        #region ShowAndActiveFluxQuery
        private void ShowAndActiveFluxQuery(Type typeOfForm)
        {
            Form f = GetOrCreateForm(typeOfForm);
            f.WindowState = FormWindowState.Maximized;
            f.Show();
            f.Activate();
        }
        #endregion //ShowAndActiveFluxQuery

        #region GetOrCreateForm
        /// <summary>
        /// 
        /// </summary>
        /// <param name="formType"></param>
        /// <returns></returns>
        private Form GetOrCreateForm(Type formType)
        {
            Form r = null;
            foreach (Form f in this.Container.MainForm.MdiChildren)
            {
                if (f.GetType() == formType)
                {
                    r = f;
                    break;
                }
            }

            if (r == null)
            {
                r = (Form)Activator.CreateInstance(formType);
                r.MdiParent = this.Container.MainForm;
            }
            return r;
        }
        #endregion //GetOrCreateForm

        #region Execute
        public override void Execute(string name, QA.Interface.ParameterCollection inParameters, 
            QA.Interface.ParameterCollection outParameters)
        {
        }
        #endregion //Execute
    }
}
