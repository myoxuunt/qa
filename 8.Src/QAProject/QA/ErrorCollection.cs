using System;
using System.Collections.Generic;
using System.Text;
using Xdgk.Common;

namespace QA
{
    /// <summary>
    /// 
    /// </summary>
    public class ErrorCollection : Collection<Error>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class ErrorManager
    {
        #region ErrorCollection
        /// <summary>
        /// 
        /// </summary>
        public ErrorCollection ErrorCollection
        {
            get
            {
                if (_errorCollection == null)
                {
                    _errorCollection = new ErrorCollection();
                }
                return _errorCollection;
            }
            set
            {
                _errorCollection = value;
            }
        } private ErrorCollection _errorCollection;
        #endregion //ErrorCollection


    }
}
