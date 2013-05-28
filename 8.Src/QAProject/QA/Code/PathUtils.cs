
using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;


namespace QA
{
    public class PathUtils
    {
        private PathUtils()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        static public string ProducePath
        {
            get
            {
                return System.Windows.Forms.Application.StartupPath + "\\" + "Config\\Produce.xml";
            }
        }
    }

}
