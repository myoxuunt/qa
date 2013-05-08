using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using QA.Interface;

namespace QA
{
    public class Container : IContainer 
    {
        #region IContainer 成员

        /// <summary>
        /// 
        /// </summary>
        public ContentManager ContentManager
        {
            get 
            { 
                if (_contentManager == null)
                {
                    _contentManager = new ContentManager();
                    _contentManager.Container = this;
                }
                return _contentManager;
            }
        }
        private ContentManager _contentManager;
        #endregion


        #region App
        /// <summary>
        /// 
        /// </summary>
        public QAApp App
        {
            get
            {
                return _app;
            }
            set
            {
                _app = value;
            }
        } private QAApp _app;
        #endregion //App


        #region IContainer 成员
        /// <summary>
        /// 
        /// </summary>
        public System.Windows.Forms.Form MainForm
        {
            get
            {
                return _mainForm;
            }
            set
            {
                _mainForm = value;
            }
        } private Form _mainForm;

        #endregion
    }
}
