using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbHelper;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class BarTypeDao
    {
        IDbHelper db = DBFactory.GetDbHelper();
        public int Add(BarType barType)
        {
            string cmdText = "insert into T_BarType values(@barTypeID,@barTypeName)";
            string[] paramList = { "@barTypeID", "@barTypeName" };
            object[] valueList = { barType.barTypeID, barType.barTypeName };
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        public int Delete(string barTypeName)
        {
            string cmdText = "delete from T_BarType where barTypeName=@barTypeName";
            string[] paramList = { "@barTypeName" };
            object[] valueList = { barTypeName };
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        public int Update(BarType barType)
        {
            string cmdText = "update T_BarType set barTypeID=@barTypeID,barTypeName=@barTypeName where barTypeName=@barTypeName";
            string[] paramList = { "@barTypeID", "@barTypeName" };
            object[] valuesList = { barType.barTypeID, barType.barTypeName };
            return db.ExecuteNoneQuery(cmdText, paramList, valuesList);
        }

        public BarType Query(string barTypeName)
        {
            string cmdText = "select * from T_BarType where barTypeName=@barTypeName";
            string[] paramList = { "@barTypeName" };
            object[] valueList = { barTypeName };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            BarType barType = new BarType();
            if (reader.Read())
            {
                barType.barTypeName = barTypeName;
                barType.barTypeID = Convert.ToInt32(reader["barTypeID"]);
                //barType.BarTypeName = reader["barTypeName"].ToString();
            }
            reader.Close();
            return barType;
        }

        public List<BarType> Query(string barTypeName, bool isAccurate = false)
        {
            List<BarType> barTypeList = new List<BarType>();
            DataSet ds = new DataSet();
            if (isAccurate)
            {
                string cmdText = "select * from T_BarType where barTypeName=@barTypeName";
                string[] paramList = { "@barTypeName" };
                object[] valueList = { barTypeName };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            else
            {
                string cmdText = "select * from T_BarType where barTypeName like @barTypeName";
                string[] paramList = { "@barTypeName" };
                object[] valueList = { "%" + barTypeName + "%" };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                BarType barType = new BarType(Convert.ToInt32(dr["barTypeID"]), dr["barTypeName"].ToString());
                barTypeList.Add(barType);
            }
            return barTypeList;
        }

        //根据贴吧类型名称查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountBarTypeName(string barTypeName)
        {
            string cmdText = "select count(*) from  T_BarType where barTypeName=@barTypeName";
            string[] paramList = { "@barTypeName" };
            object[] valueList = { barTypeName };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }
        //根据barTypeID查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountBarTypeID(int barTypeID)
        {
            string cmdText = "select count(*) from  T_BarType where barTypeID=@barTypeID";
            string[] paramList = { "@barTypeID" };
            object[] valueList = { barTypeID };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }
    }
}
