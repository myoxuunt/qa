using System;
using System.Windows.Forms;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using QA.Interface;

namespace QA
{
    public class ContainerFactory
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cim"></param>
        /// <returns></returns>
        static public Container Create(ContentInfoManager cim, frmMain mainForm)
        {
            if( cim == null )
            {
                throw new ArgumentNullException("cim");
            }
            if (mainForm == null)
            {
                throw new ArgumentNullException("mainForm");
            }

            Container container = new Container();
            foreach (ContentInfo ci in cim.ContentInfoCollection)
            {
                IContent[] contents = ContentFactory.Create(ci.Path);
                //if (content != null)
                foreach (IContent content in contents)
                {
                    // check content
                    // 
                    ToolStripMenuItem parentMenuItem = mainForm.FindMenuItem(ci.ParentMenuItemName);
                    ToolStrip parentToolStrip = mainForm.FindToolStrip(ci.ParentToolStripName);
                    container.ContentManager.Add(content);
                    content.Load(parentMenuItem, parentToolStrip);
                }
                
            }
            return container;
        }
    }
}
