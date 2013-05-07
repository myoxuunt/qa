using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace QA.Interface
{

    /// <summary>
    /// 
    /// </summary>
    public abstract class ContentBase : IContent
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract string Name
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        public abstract string Description
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        public IContainer Container
        {
            get
            {
                return _container;
            }
            set
            {
                _container = value;
            }
        } private IContainer _container;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentMenuItem"></param>
        /// <param name="parentToolStrip"></param>
        public abstract void Load(ToolStripMenuItem parentMenuItem, ToolStrip parentToolStrip);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="inParameters"></param>
        /// <param name="outParameters"></param>
        public abstract void Execute(string name, 
            ParameterCollection inParameters, ParameterCollection outParameters);
    }
    


}
