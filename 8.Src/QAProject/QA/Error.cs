using System;
using System.Collections.Generic;
using System.Text;

namespace QA
{
    /// <summary>
    /// 
    /// </summary>
    public class Error
    {
        #region Dt
        /// <summary>
        /// 
        /// </summary>
        public DateTime Dt
        {
            get
            {
                return _dt;
            }
            set
            {
                _dt = value;
            }
        } private DateTime _dt;
        #endregion //Dt

        #region Tag
        /// <summary>
        /// 
        /// </summary>
        public object Tag
        {
            get
            {
                return _tag;
            }
            set
            {
                _tag = value;
            }
        } private object _tag;
        #endregion //Tag

        #region Description
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            get
            {
                if (_description == null)
                {
                    _description = string.Empty;
                }
                return _description;
            }
            set
            {
                _description = value;
            }
        } private string _description;
        #endregion //Description

        #region Exception
        /// <summary>
        /// 
        /// </summary>
        public Exception Exception
        {
            get
            {
                return _exception;
            }
            set
            {
                _exception = value;
            }
        } private Exception _exception;
        #endregion //Exception

    }
}
