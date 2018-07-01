using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbHelper;
using Model;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class BarDao
    {
        IDbHelper db = DBFactory.GetDbHelper();
        public int Add(Bar bar)
        {
            string cmdText = "insert into T_Bar values(@barTypeID,@userID,@barName,@barTime,@barAutoGraph,@barHeadImg,@barTopImg,@barBGImg)";
            string[] paramList = { "@barTypeID", "@userID", "@barName", "@barTime", "@barAutoGraph", "@barHeadImg", "@barTopImg", "@barBGImg" };
            object[] valueList = { bar.barTypeID, bar.userID, bar.barTime, bar.barName, bar.barAutoGraph, bar.barHeadImg, bar.barTopImg, bar.barBGImg };
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        public int Delete(string barName)
        {
            string cmdText = "delete from T_Bar where barName=@barName";
            string[] paramList = { "@barName" };
            object[] valueList = { barName };
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        public int Update(Bar bar)
        {
            string cmdText = "update T_Bar set barTypeID=@barTypeIDuserID=@userID,barTime=@barTime,barAutoGraph=@barAutoGraph,barHeadImg=@barHeadImg,barTopImg=@barTopImg,barBGImg=@barBGImg wher barName=@barName";
            string[] paramList = { "@barTypeID", "@userID", "@barName", "@barTime", "@barAutoGraph", "@barHeadImg", "@barTopImg", "@barBGImg" };
            object[] valuesList = { bar.barTypeID, bar.userID, bar.barTime, bar.barName, bar.barAutoGraph, bar.barHeadImg, bar.barTopImg, bar.barBGImg };
            return db.ExecuteNoneQuery(cmdText, paramList, valuesList);
        }

        public Bar Query(string barName)
        {
            string cmdText = "select * from T_Bar where barName=@barName";
            string[] paramList = { "@barName" };
            object[] valueList = { barName };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            Bar bar = new Bar();
            if (reader.Read())
            {
                bar.barName = barName;
                bar.userID = Convert.ToInt32(reader["userID"]);
                bar.barTime = reader["barTime"].ToString();
                //bar.barName = reader["barName"].ToString();
                bar.barAutoGraph = reader["barAutoGraph"].ToString();
                bar.barHeadImg = reader["barHeadImg"].ToString();
                bar.barTopImg = reader["barTopImg"].ToString();
                bar.barBGImg = reader["barBGImg"].ToString();
            }
            reader.Close();
            return bar;
        }

        public List<Bar> Query(string barName, bool isAccurate = false)
        {
            List<Bar> barList = new List<Bar>();
            DataSet ds = new DataSet();
            if (isAccurate)
            {
                string cmdText = "select * from T_Bar where barName=@barName";
                string[] paramList = { "@barName" };
                object[] valueList = { barName };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            else
            {
                string cmdText = "select * from T_Bar where barName like @barName";
                string[] paramList = { "@barName" };
                object[] valueList = { "%" + barName + "%" };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                Bar bar = new Bar(Convert.ToInt32(dr["barID"]), Convert.ToInt32(dr["barTypeID"]), Convert.ToInt32(dr["userID"]), dr["barName"].ToString(), dr["barTime"].ToString(), dr["barAutoGraph"].ToString(), dr["barHeadImg"].ToString(), dr["barTopImg"].ToString(), dr["barBGImg"].ToString());
                barList.Add(bar);
            }
            return barList;
        }

        public Bar QueryUserID(int userID)//根据userID查询
        {
            string cmdText = "select * from T_Bar where userID=@userID";
            string[] paramList = { "@userID" };
            object[] valueList = { userID };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            Bar bar = new Bar();
            if (reader.Read())
            {
                bar.userID = userID;
                bar.barName = reader["barName"].ToString();
                bar.barTime = reader["barTime"].ToString();
                //bar.barName = reader["barName"].ToString();
                bar.barAutoGraph = reader["barAutoGraph"].ToString();
                bar.barHeadImg = reader["barHeadImg"].ToString();
                bar.barTopImg = reader["barTopImg"].ToString();
                bar.barBGImg = reader["barBGImg"].ToString();
            }
            reader.Close();
            return bar;
        }
        public Bar QueryBarTypeID(int barTypeID)//根据barTypeID查询
        {
            Bar bar = new Bar();
            string cmdText = "select * from T_Bar where postID=@barTypeID";
            string[] paramList = { "@barTypeID" };
            object[] valueList = { barTypeID };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            if (reader.Read())
            {
                bar.barTypeID = barTypeID;
                bar.userID = Convert.ToInt32(reader["user"]);
                bar.barName = reader["barName"].ToString();
                bar.barTime = reader["barTime"].ToString();
                //bar.barName = reader["barName"].ToString();
                bar.barAutoGraph = reader["barAutoGraph"].ToString();
                bar.barHeadImg = reader["barHeadImg"].ToString();
                bar.barTopImg = reader["barTopImg"].ToString();
                bar.barBGImg = reader["barBGImg"].ToString();


            }
            reader.Close();
            return bar;
        }
        //根据用户姓名得到用户ID
        public UserInfo getUserID(string userName)
        {
            string cmdText = "select * from T_User where userName=@userName";
            string[] paramList = { "@userName" };
            object[] valueList = { userName };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            UserInfo user = new UserInfo();
            if (reader.Read())
            {
                user.userName = userName;
                user.userID = Convert.ToInt32(reader["userID"]);
            }
            reader.Close();
            return user;
        }
        //根据贴吧类型名称得到贴吧类型ID
        public BarType getBarTypeID(string barTypeName)
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
            }
            reader.Close();
            return barType;
        }
        //根据贴吧名称查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountBarName(string barName)
        {
            string cmdText = "select count(*) from  T_Bar where barName=@barName";
            string[] paramList = { "@barName" };
            object[] valueList = { barName };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }

        //根据userID查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountUserID(int userID)
        {
            string cmdText = "select count(*) from  T_Bar where userID=@userID";
            string[] paramList = { "@userID" };
            object[] valueList = { userID };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }
        //根据barTypeID查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountBarTypeID(int barTypeID)
        {
            string cmdText = "select count(*) from T_Bar where barTypeID=@barTypeID";
            string[] paramList = { "@barTypeID" };
            object[] valueList = { barTypeID };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }

        //根据barID查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountBarID(int barID)
        {
            string cmdText = "select count(*) from  T_Bar where barID=@barID";
            string[] paramList = { "@barID" };
            object[] valueList = { barID };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }

        //查询最近添加的10个记录
        public List<Bar> getDesc(string barName, bool isAccurate = false)
        {
            List<Bar> barList = new List<Bar>();
            DataSet ds = new DataSet();
            if (isAccurate)
            {
                string cmdText = "select top 10 * from T_Bar where barName like @barName order by barID desc";
                string[] paramList = { "@barName" };
                object[] valueList = { barName };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            else
            {
                string cmdText = "select  top 10 * from T_Bar where barName like @barName order by barID desc";
                string[] paramList = { "@barName" };
                object[] valueList = { "%" + barName + "%" };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                Bar bar = new Bar(Convert.ToInt32(dr["barID"]), Convert.ToInt32(dr["barTypeID"]), Convert.ToInt32(dr["userID"]), dr["barName"].ToString(), dr["barTime"].ToString(), dr["barAutoGraph"].ToString(), dr["barHeadImg"].ToString(), dr["barTopImg"].ToString(), dr["barBGImg"].ToString());
                barList.Add(bar);
            }
            return barList;
        }
    }
}
