using System;
using System.Collections.Generic;
using System.Text;

namespace QA
{

    /// <summary>
    /// 
    /// </summary>
    public class ContentInfoManager
    {
        #region ContentInfoCollection
        /// <summary>
        /// 
        /// </summary>
        public ContentInfoCollection ContentInfoCollection
        {
            get
            {
                if (_contentInfoCollection == null)
                {
                    //_contentInfoCollection = //new ContentInfoCollection();
                    _contentInfoCollection = ContentInfoFactory.Create();
                }
                return _contentInfoCollection;
            }
            set
            {
                _contentInfoCollection = value;
            }
        } private ContentInfoCollection _contentInfoCollection;
        #endregion //ContentInfoCollection

    }
}
