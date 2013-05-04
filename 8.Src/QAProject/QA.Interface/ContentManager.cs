using System;
using System.Collections.Generic;
using System.Text;
using Xdgk.Common;

namespace QA.Interface
{
       /// <summary>
    /// 
    /// </summary>
    public class ContentManager
    {

        #region Container
        /// <summary>
        /// 
        /// </summary>
        public IContainer Container
        {
            get { return _container; }
            set { _container = value; }
        } private IContainer _container;
        #endregion //Container

        #region ContentCollection
        /// <summary>
        /// 
        /// </summary>
        public ContentCollection ContentCollection
        {
            get
            {
                if (_contentCollection == null)
                {
                    _contentCollection = new ContentCollection();
                }
                return _contentCollection;
            }
            set
            {
                _contentCollection = value;
            }
        } private ContentCollection _contentCollection;
        #endregion //ContentCollection

        #region Execute
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contentName"></param>
        /// <param name="executeName"></param>
        /// <param name="inParameters"></param>
        /// <param name="outParameters"></param>
        public void Execute(string contentName, string executeName, ParameterCollection inParameters, ParameterCollection outParameters)
        {
            foreach (IContent content in this.ContentCollection)
            {
                if (StringHelper.Equal(contentName, content.Name))
                {
                    content.Execute(executeName, inParameters, outParameters);
                    return;
                }
            }
            ThrowNotFindContentException(contentName);
        }
        #endregion //Execute

        #region ThrowNotFindContentException
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contentName"></param>
        private static void ThrowNotFindContentException(string contentName)
        {
            string msg = string.Format("not find Content with name '{0}'", contentName);
            throw new InvalidOperationException(msg);
        }
        #endregion //ThrowNotFindContentException

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        public void Add(IContent content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            if (this.ContentCollection.Contains(content))
            {
                string msg = string.Format("ContentManager contains content '{0}'", content.Name);
                throw new InvalidOperationException(msg);
            }

            if (this.ContentCollection.Contains(content.Name))
            {
                string msg = string.Format("ContentManager contains content name '{0}'", content.Name);
                throw new InvalidOperationException(msg);
            }

            this.ContentCollection.Add(content);
            content.Container = this.Container;
        }
    }
}
