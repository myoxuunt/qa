using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

namespace VPumpQuery
{
    class Helper
    {
        /// <summary>
        /// 
        /// </summary>
        static internal void SetDataGridViewColumns(Xdgk.UI.Forms.UCDataGridView ucDataGridView)
        {
            string path = System.IO.Path.Combine(
                System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Config\\PumpColumnConfig.xml");
            ucDataGridView.ColumnConfigFile = path;
        }
    }
}
