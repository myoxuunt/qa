using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;

namespace QA
{
    /// <summary>
    /// 
    /// </summary>
    public class Config
    {
        #region CommandLineOptions
        /// <summary>
        /// 
        /// </summary>
        public CommandLineOptions CommandLineOptions
        {
            get
            {
                return _commandLineOptions;
            }
            set
            {
                _commandLineOptions = value;
            }
        } private CommandLineOptions _commandLineOptions;
        #endregion //CommandLineOptions

        #region AppName
        /// <summary>
        /// 
        /// </summary>
        public string AppName
        {
            get
            {
                if (_appName == null)
                {
                    _appName = System.Configuration.ConfigurationSettings.AppSettings["AppName"];
                }
                return _appName;
            }
            set
            {
                _appName = value;
            }
        } private string _appName;
        #endregion //AppName
    }
}
