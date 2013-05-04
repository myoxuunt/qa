using System;
using System.Collections.Generic;
using System.Text;
using Xdgk.Common;

namespace QA
{
    /// <summary>
    /// 
    /// </summary>
    public class ContentInfo
    {
        #region Path
        /// <summary>
        /// 
        /// </summary>
        public string Path
        {
            get
            {
                if (_path == null)
                {
                    _path = string.Empty;
                }
                return _path;
            }
            set
            {
                _path = value;
            }
        } private string _path;
        #endregion //Path

        #region ParentMenuItemName
        /// <summary>
        /// 
        /// </summary>
        public string ParentMenuItemName
        {
            get
            {
                if (_parentMenuItemName == null)
                {
                    _parentMenuItemName = string.Empty;
                }
                return _parentMenuItemName;
            }
            set
            {
                _parentMenuItemName = value;
            }
        } private string _parentMenuItemName;
        #endregion //ParentMenuItemName

        #region ParentToolStripName
        /// <summary>
        /// 
        /// </summary>
        public string ParentToolStripName
        {
            get
            {
                if (_parentToolStripName == null)
                {
                    _parentToolStripName = string.Empty;
                }
                return _parentToolStripName;
            }
            set
            {
                _parentToolStripName = value;
            }
        } private string _parentToolStripName;
        #endregion //ParentToolStripName
    }



}
