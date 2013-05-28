using System;
using System.Xml;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using Xdgk.Common;

namespace QA
{
    /// <summary>
    /// 
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 
        /// </summary>
        public Config()
        {
            LoadProduceInfo();
        }

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
                    //_appName = System.Configuration.ConfigurationSettings.AppSettings["AppName"];
                    _appName = "AppName";
                }
                return _appName;
            }
            set
            {
                _appName = value;
            }
        } private string _appName;
        #endregion //AppName

        /// <summary>
        /// 
        /// </summary>
        private void LoadProduceInfo()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(PathUtils.ProducePath);
            XmlNode rootNode = xmlDoc.SelectSingleNode("produce");
            _version = XmlHelper.GetAttribute(rootNode, "version");
            _appName = XmlHelper.GetAttribute(rootNode, "name");
        }

        public string Version
        {
            get
            {
                if (_version == null)
                {
                    _version = "version";
                }
                return _version;
            }
            set
            {
                _version = value;
            }
        } private string _version;
    }
}
