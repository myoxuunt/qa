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
    public class QAApp
    {
        /// <summary>
        /// 
        /// </summary>
        private QAApp()
        {
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            System.AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ProcessException(e.ExceptionObject as Exception );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        private void ProcessException(Exception exception)
        {
            NUnit.UiKit.UserMessage.DisplayFailure(exception.Message);
            Environment.Exit(0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            ProcessException(e.Exception);
        }

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
                    _container = ContainerFactory.Create(this.ContentInfoManager, this.MainForm);
                    _container.App = this;
                    _container.MainForm = this.MainForm;
                }
                return _container;
            }
        } private Container _container;


        #region MainForm
        /// <summary>
        /// 
        /// </summary>
        public frmMain MainForm
        {
            get
            {
                if (_mainForm == null)
                {
                    _mainForm = new frmMain();
                }
                return _mainForm;
            }
            set
            {
                _mainForm = value;
            }
        } private frmMain _mainForm;
        #endregion //MainForm

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


        /// <summary>
        /// 
        /// </summary>
        public void Run()
        {
            if (Diagnostics.HasPreInstance())
            {
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);



            object obj = this.Container;
            Application.Run(this.MainForm);
        }

        void notifyIcon_Click(object sender, EventArgs e)
        {
            MessageBox.Show("a");
        }
    }
}
