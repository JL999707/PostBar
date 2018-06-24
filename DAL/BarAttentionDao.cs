﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbHelper;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class BarAttentionDao
    {
        IDbHelper db = DBFactory.GetDbHelper();
        public int Add(BarAttention barAtt)
        {
            string cmdText = "insert into T_BarAttention values(@barAttID, @userID, @barID,@barAttName, @BarAttTime)";
            string[] paramList = { "@T_BarAttID", "@T_UserID", "@T_BarID", "@barAttTitle", "@attTime" };
            object[] valueList = { barAtt.barAttID, barAtt.userID, barAtt.barID, barAtt.barAttName, barAtt.barAttTime };
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        public int Delete(string barAttName)
        {
            string cmdText = "delete from T_BarAttention where barAttName=@barAttName";
            string[] paramList = { "@barAttName" };
            object[] valueList = { barAttName };
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        public int Update(BarAttention barAtt)
        {
            string cmdText = "update T_BarAttention set barAttID=@barAttID,userID=@userID,barID=@barID,barAttTime=@barAttTime where barAttName=@barAttName,";
            string[] paramList = { "@TbarAttID", "@userID", "@barID", "@barAttName", "@barAttTime" };
            object[] valuesList = { barAtt.barAttID, barAtt.userID, barAtt.barID, barAtt.barAttName, barAtt.barAttTime };
            return db.ExecuteNoneQuery(cmdText, paramList, valuesList);
        }

        public BarAttention Query(string barAttName)
        {
            string cmdText = "select * from T_BarAttention where barAttName=@barAttName";
            string[] paramList = { "@barAttName" };
            object[] valueList = { barAttName };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            BarAttention barAtt = new BarAttention();
            if (reader.Read())
            {
                barAtt.barAttName = barAttName;
                barAtt.barAttID = Convert.ToInt32(reader["barAttID"]);
                barAtt.userID = Convert.ToInt32(reader["userID"]);
                barAtt.barID = Convert.ToInt32(reader["barID"]);
                barAtt.barAttTime = reader["barAttTime"].ToString();
            }
            reader.Close();
            return barAtt;
        }

        public List<BarAttention> Query(string barAttName, bool isAccurate = false)
        {
            List<BarAttention> barAttList = new List<BarAttention>();
            DataSet ds = new DataSet();
            if (isAccurate)
            {
                string cmdText = "select * from T_BarAttention where barAttName=@barAttName";
                string[] paramList = { "@barAttName" };
                object[] valueList = { barAttName };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            else
            {
                string cmdText = "select * from T_BarAttention where barAttName like @barAttName";
                string[] paramList = { "@barAttName" };
                object[] valueList = { "%" + barAttName + "%" };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                BarAttention barAtt = new BarAttention(Convert.ToInt32(dr["barAttID"]), Convert.ToInt32(dr["userID"]), Convert.ToInt32(dr["barID"]), dr["barAttName"].ToString(), dr["barAttTime"].ToString());
                barAttList.Add(barAtt);
            }
            return barAttList;
        }
    }
}
