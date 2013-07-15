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

        }
        #endregion //Load





        #region CreateFluxQueryUI
        private void CreateFluxQueryUI(System.Windows.Forms.ToolStripMenuItem parentMenuItem, System.Windows.Forms.ToolStrip parentToolStrip)
        {
            ToolStripItem item = parentMenuItem.DropDownItems.Add(Strings.mnu_flux_query);
            item.Click += new EventHandler(item_Click);


            ToolStripButton fluxQueryButton = new ToolStripButton();
            fluxQueryButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            fluxQueryButton.TextImageRelation = TextImageRelation.ImageAboveText;
            fluxQueryButton.Text = Strings.title_flux_form;
            fluxQueryButton.Image = QRes.ImageManager.History.ToBitmap();
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
            Xdgk.UI.Forms.FormHelper.ShowAndActiveFluxQuery(this.Container.MainForm, typeof(frmDataQuery));
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
            Xdgk.UI.Forms.FormHelper.ShowAndActiveFluxQuery(this.Container.MainForm, typeof(frmDataQuery));
        }
        #endregion //item_Click



        #region Execute
        public override void Execute(string name, QA.Interface.ParameterCollection inParameters,
            QA.Interface.ParameterCollection outParameters)
        {
        }
        #endregion //Execute
    }

}
