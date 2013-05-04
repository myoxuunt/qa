using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

namespace QA.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface IContainer 
    {
        /// <summary>
        /// 
        /// </summary>
        ContentManager ContentManager
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        Form MainForm
        {
            get;
            set;
        }
    }
}
