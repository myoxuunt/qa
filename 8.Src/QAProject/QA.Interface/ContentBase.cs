﻿using System;
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
        public virtual string Name
        {
            get
            {
                return this.GetType().Name;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Description
        {
            get
            {
                return string.Empty;
            }
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
        virtual public int OrderNumber
        {
            get { return _orderNumber; }
            set { _orderNumber = value; }
        } private int _orderNumber;

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

        #region IContent 成员


        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentStrip"></param>
        virtual public void Load(StatusStrip parentStrip)
        {
            // do nothing
            //
        }

        #endregion
    }
    


}
