using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace BaiCheng
{
    public class DBFactory
    {
        private DBFactory()
        {
        }

        static public BcdbDataContext Create()
        {
            string con = ConfigurationManager.ConnectionStrings[1].ConnectionString;
            return new BcdbDataContext (con);
        }
    }
}
