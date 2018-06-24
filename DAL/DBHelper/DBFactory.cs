using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DbHelper
{
    class DBFactory
    {
        public static IDbHelper GetDbHelper()
        {
            string dbType = ConfigurationManager.AppSettings["dbType"];
            if (dbType == "sql")
            {
                return new SQLHelper();
            }
            else if (dbType == "oracle")
            {
                return new OracleHelper();
            }
            return new SQLHelper();
        }
    }
}
