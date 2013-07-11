using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Xdgk.Common;

namespace QA.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface IContent : IOrderNumber 
    {
        /// <summary>
        /// 
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 
        /// </summary>
        string Description { get; }

        /// <summary>
        /// 
        /// </summary>
        IContainer Container
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentMenuItem"></param>
        /// <param name="parentToolStrip"></param>
        void Load(ToolStripMenuItem parentMenuItem, ToolStrip parentToolStrip);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentStrip"></param>
        void Load(StatusStrip parentStrip);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="inParameters"></param>
        /// <param name="outParameters"></param>
        void Execute(string name, ParameterCollection inParameters, ParameterCollection outParameters);
    }
}
