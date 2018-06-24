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
    public class BarDao
    {
        IDbHelper db = DBFactory.GetDbHelper();
        public int Add(Bar bar)
        {
            string cmdText = "insert into T_Bar values(@barTypeID,@userID,@barName,@barTime,@barAutoGraph,@barHeadImg,@barTopImg,@barBGImg)";
            string[] paramList = { "@barTypeID", "@userID", "@barName", "@barTime",  "@barAutoGraph", "@barHeadImg", "@barTopImg", "@barBGImg" };
            object[] valueList = { bar.barTypeID, bar.userID, bar.barTime, bar.barName,  bar.barAutoGraph, bar.barHeadImg, bar.barTopImg, bar.barBGImg };
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
            string[] paramList = { "@barTypeID", "@userID", "@barName", "@barTime","@barAutoGraph", "@barHeadImg", "@barTopImg", "@barBGImg" };
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
                Bar bar = new Bar(Convert.ToInt32(dr["barID"]), Convert.ToInt32(dr["barTypeID"]), Convert.ToInt32(dr["userID"]), dr["barName"].ToString(), dr["barTime"].ToString(),  dr["barAutoGraph"].ToString(), dr["barHeadImg"].ToString(), dr["barTopImg"].ToString(), dr["barBGImg"].ToString());
                barList.Add(bar);
            }
            return barList;
        }
    }
}
