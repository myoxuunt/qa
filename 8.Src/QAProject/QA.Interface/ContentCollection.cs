﻿using System;
using System.Collections.Generic;
using System.Text;

namespace QA.Interface
{
/// <summary>
    /// 
    /// </summary>
    public class ContentCollection : 
        Xdgk.Common.Collection<IContent>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Content GetContentByName(string name, bool ignoreCase)
        {
            name = name.Trim ();
            foreach (Content content in this)
            {
                if (string.Compare(name, content.Name, ignoreCase) == 0)
                {
                    return content;
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Contains(string name)
        {
            Content content = GetContentByName(name, true);
            return content != null;
        }
    }
}
