using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace QRes
{
    public class ImageManager
    {
        private ImageManager()
        {

        }

        static public Icon Graph { get { return Images.Graph; } }
        static public Icon History { get { return Images.History; } }
        static public Icon Info { get { return Images.info; } }
        static public Icon Last { get { return Images.Last; } }
        static public Icon Lightning { get { return Images.Lightning; } }
        static public Image ErrorGlint { get { return Images.error_glint; } }
        static public Icon None { get { return Images.None; } }
    }
}
