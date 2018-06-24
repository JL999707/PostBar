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
    public class AtDao
    {
        IDbHelper db = DBFactory.GetDbHelper();
        public int Add(At at)
        {
            string cmdText = "insert into T_At values(@atUserID,@beAtUserID,@replyID,@atContent,@atTime)";
            string[] paramList = { "@atUserID", "@beAtUserID", "@replyID", "@atContent", "@atTime" };
            object[] valueList = { at.atUserID, at.atContent, at.replyID, at.atTime };
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        public int Delete(int beAtUserID)
        {
            string cmdText = "delete from T_At where beAtUserID=@beAtUserID";
            string[] paramList = { "@beAtUserID" };
            object[] valueList = { beAtUserID };
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        public int Update(At at)
        {
            string cmdText = "update T_At set atUserID=@atUserID,rT_ReplyID=@replyID,atContent=@atContent,atTime=@atTime where beAtUserID=@beAtUserID";
            string[] paramList = { "@atUserID", "@beAtUserID", "@replyID", "@atContent", "@atTime" };
            object[] valuesList = { at.atUserID, at.beAtUserID, at.replyID, at.atContent, at.atTime };
            return db.ExecuteNoneQuery(cmdText, paramList, valuesList);
        }

        public At Query(int beAtUserID)
        {
            string cmdText = "select * from T_At where beAtUserID=@beAtUserID";
            string[] paramList = { "@beAtUserID" };
            object[] valueList = { beAtUserID };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            At at = new At();
            if (reader.Read())
            {
                at.beAtUserID = beAtUserID;
                at.atUserID = Convert.ToInt32(reader["atUserID"]);
                at.replyID = Convert.ToInt32(reader["replyID"]);
                //at.beAtUserID = Convert.ToInt32(reader["beReplyID"]);
                at.atContent = reader["atContent"].ToString();
                at.atTime = reader["atTime"].ToString();
            }
            reader.Close();
            return at;
        }

        public List<At> Query(int beAtUserID, bool isAccurate = false)
        {
            List<At> atList = new List<At>();
            DataSet ds = new DataSet();
            if (isAccurate)
            {
                string cmdText = "select * from T_At where beAtUserID=@beAtUserID";
                string[] paramList = { "@beAtUserID" };
                object[] valueList = { beAtUserID };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            else
            {
                string cmdText = "select * from T_At where beAtUserID like @beAtUserID";
                string[] paramList = { "@beAtUserID" };
                object[] valueList = { "%" + beAtUserID + "%" };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                At at = new At(Convert.ToInt32(dr["atID"]), Convert.ToInt32(dr["atUserID"]), Convert.ToInt32(dr["beAtUserID"]), Convert.ToInt32(dr["replyID"]), dr["atContent"].ToString(), dr["atTime"].ToString());
                atList.Add(at);
            }
            return atList;
        }
    }
}
