using System;
using System.Collections.Generic;
using System.Text;

namespace QA.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public class Parameter
    {
        #region Value
        /// <summary>
        /// 
        /// </summary>
        public object Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        } private object _value;
        #endregion //Value

        #region Name
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                if (_name == null)
                {
                    _name = string.Empty;
                }
                return _name;
            }
            set
            {
                _name = value;
            }
        } private string _name;
        #endregion //Name

    }
}
