using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DbHelper
{
    class OracleHelper : IDbHelper
    {
        public int ExecuteNoneQuery(string cmdText, string[] param, object[] values)
        {
            throw new NotImplementedException();
        }

        public int ExecuteNoneQueryBySP(string cmdText, SqlParameter[] parms)
        {
            throw new NotImplementedException();
        }

        public SqlDataReader ExecuteReader(string cmdText, string[] param, object[] values)
        {
            throw new NotImplementedException();
        }

        public SqlDataReader ExecuteReaderBySP(string cmdText, SqlParameter[] parms)
        {
            throw new NotImplementedException();
        }

        public object ExecuteScalar(string cmdText, string[] param, object[] values)
        {
            throw new NotImplementedException();
        }

        public ArrayList ExecuteSp(string cmdText, SqlParameter[] parms)
        {
            throw new NotImplementedException();
        }

        public DataSet FillDataSet(string cmdText, string[] param, object[] values)
        {
            throw new NotImplementedException();
        }

        public DataSet FillDataSetBySP(string cmdText, SqlParameter[] parms)
        {
            throw new NotImplementedException();
        }
    }
}
