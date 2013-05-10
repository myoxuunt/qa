using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiCheng
{
    public class DBFactory
    {
        private DBFactory()
        {
        }

        static public BcdbDataContext Create()
        {
            return new BcdbDataContext ();
        }
    }
}
