using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;

namespace QA
{
    public class ContentInfoFactory
    {
        /// <summary>
        /// 
        /// </summary>
        private const string ContentInfoFilePath = "Config\\ContentInfo.xml";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public ContentInfoCollection Create()
        {
            return Create(ContentInfoFilePath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static public ContentInfoCollection Create(string path)
        {
            // parse xml file
            //
            path = System.Windows.Forms.Application.StartupPath +"\\" + path;
            ContentInfoCollection r = new ContentInfoCollection();
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode cis = doc.SelectSingleNode(ContentInfoNodeName.ContentInfoCollection );
            if (cis != null)
            {
                XmlNodeList ciList = cis.SelectNodes(ContentInfoNodeName.ContentInfo);
                foreach (XmlNode ciNode in ciList)
                {
                    string cipath = XmlHelper.GetAttribute(ciNode, ContentInfoNodeName.Path);
                    string parentMenuItemName = XmlHelper.GetAttribute(ciNode, ContentInfoNodeName.ParentMenu);
                    string parentToolbar = XmlHelper.GetAttribute(ciNode, ContentInfoNodeName.ParentToolbar);

                    ContentInfo item = new ContentInfo();
                    item.Path = cipath;
                    item.ParentMenuItemName = parentMenuItemName;
                    item.ParentToolStripName = parentToolbar;
                    r.Add(item);

                }
            }
            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        private class ContentInfoNodeName
        {
            /// <summary>
            /// 
            /// </summary>
            private ContentInfoNodeName()
            {
            }

            /// <summary>
            /// 
            /// </summary>
            public const string 
                Path = "path",
                ContentInfoCollection = "contentInfoCollection",
                ContentInfo = "contentInfo",
                ParentMenu = "parentMenu",
                ParentToolbar = "parentToolbar";
        }
    }
}
