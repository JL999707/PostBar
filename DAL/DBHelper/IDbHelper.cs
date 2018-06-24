using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace DbHelper
{
    interface IDbHelper
    {
        int ExecuteNoneQuery(string cmdText, string[] param, object[] values);
        SqlDataReader ExecuteReader(string cmdText, string[] param, object[] values);
        SqlDataReader ExecuteReaderBySP(string cmdText, SqlParameter[] parms);
        object ExecuteScalar(string cmdText, string[] param, object[] values);
        int ExecuteNoneQueryBySP(string cmdText, SqlParameter[] parms);
        DataSet FillDataSet(string cmdText, string[] param, object[] values);
        DataSet FillDataSetBySP(string cmdText, SqlParameter[] parms);
        ArrayList ExecuteSp(string cmdText, SqlParameter[] parms);
    }
}
