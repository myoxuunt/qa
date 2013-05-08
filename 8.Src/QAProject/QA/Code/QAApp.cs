using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using Xdgk.Common;

namespace QA
{
    /// <summary>
    /// 
    /// </summary>
    public class QAApp : AppBase 
    {

        #region QAApp
        /// <summary>
        /// 
        /// </summary>
        private QAApp()
        {
            // init container
            //
            object obj = this.Container;
        }
        #endregion //QAApp

        #region App
        /// <summary>
        /// 
        /// </summary>
        static public QAApp App
        {
            get 
            {
                if (_app == null)
                {
                    _app = new QAApp();
                }
                return _app;
            }
        } static private QAApp _app;
        #endregion //App

        #region Container
        /// <summary>
        /// 
        /// </summary>
        public Container Container
        {
            get
            {
                if (_container == null)
                {
                    //_container = new Container();
                    _container = ContainerFactory.Create(this.ContentInfoManager, (frmMain)this.MainForm);
                    _container.App = this;
                    _container.MainForm = this.MainForm;
                }
                return _container;
            }
        } private Container _container;
        #endregion //Container

        #region MainForm
        /// <summary>
        /// 
        /// </summary>
        public override Form MainForm
        {
            get
            {
                if (_mainForm == null)
                {
                    _mainForm = new frmMain();
                }
                return _mainForm;
            }
        } private frmMain _mainForm;
       
        #endregion //MainForm

        #region ContentInfoManager
        /// <summary>
        /// 
        /// </summary>
        private ContentInfoManager ContentInfoManager
        {
            get 
            {
                if (_contentInfoManager == null)
                {
                    _contentInfoManager = new ContentInfoManager();
                }
                return _contentInfoManager;
            }
        } private ContentInfoManager _contentInfoManager;
        #endregion //ContentInfoManager

        #region ErrorManager
        /// <summary>
        /// 
        /// </summary>
        public ErrorManager ErrorManager
        {
            get
            {
                if (_errorManager == null)
                {
                    _errorManager = new ErrorManager();
                }
                return _errorManager;
            }
            set
            {
                _errorManager = value;
            }
        } private ErrorManager _errorManager;
        #endregion //ErrorManager

        #region Config
        /// <summary>
        /// 
        /// </summary>
        public Config Config
        {
            get
            {
                if (_config == null)
                {
                    _config = new Config();
                }
                return _config;
            }
            set
            {
                _config = value;
            }
        } private Config _config;
        #endregion //Config
    }
}
