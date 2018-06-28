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
    public class PictureDao
    {
        IDbHelper db = DBFactory.GetDbHelper();
        public int Add(Picture picLink)
        {
            string cmdText = "insert into T_Picture values(@picID, @postID,@picName, @picAddr, @picTime)";
            string[] paramList = { "@picID", "@T_PostID", "@picName", "@picAddr", "@picTime" };
            object[] valueList = { picLink.picID, picLink.postID, picLink.picName, picLink.picAddr, picLink.picTime };
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        public int Delete(string picName)
        {
            string cmdText = "delete from T_Picture where picName=@picName";
            string[] paramList = { "@picName" };
            object[] valueList = { picName };
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        public int Update(Picture picLink)
        {
            string cmdText = "update T_PictureLink set picID=@picID,postID= @postID,picName=@picName, picAddr=@picAddr, picTime=@picTime where picName=@picName";
            string[] paramList = { "@picID", "@postID", "@picLinkTitle", "@picLAddr", "@picTime" };
            object[] valuesList = { picLink.picID, picLink.postID, picLink.picName, picLink.picAddr, picLink.picTime };
            return db.ExecuteNoneQuery(cmdText, paramList, valuesList);
        }

        public Picture Query(string picName)
        {
            string cmdText = "select * from T_Picture where picName=@picName";
            string[] paramList = { "@picName" };
            object[] valueList = { picName };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            Picture picLink = new Picture();
            if (reader.Read())
            {
                picLink.picName = picName;
                picLink.picID = Convert.ToInt32(reader["picID"]);
                picLink.postID = Convert.ToInt32(reader["postID"]);
                picLink.picAddr = reader["picAddr"].ToString();
                picLink.picTime = reader["picTime"].ToString();
            }
            reader.Close();
            return picLink;
        }

        public List<Picture> Query(string picName, bool isAccurate = false)
        {
            List<Picture> picLinkList = new List<Picture>();
            DataSet ds = new DataSet();
            if (isAccurate)
            {
                string cmdText = "select * from T_Picture where picName=@picName";
                string[] paramList = { "@picName" };
                object[] valueList = { picName };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            else
            {
                string cmdText = "select * from T_Picture where picName like @picName";
                string[] paramList = { "@picName" };
                object[] valueList = { "%" + picName + "%" };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                Picture picLink = new Picture(Convert.ToInt32(dr["picID"]), Convert.ToInt32(dr["postID"]), dr["picName"].ToString(), dr["picAddr"].ToString(), dr["picTime"].ToString());
                picLinkList.Add(picLink);
            }
            return picLinkList;
        }

        //根据图片名称查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountPicName(string picName)
        {
            string cmdText = "select count(*) from  T_Picture where picName=@picName";
            string[] paramList = { "@picName" };
            object[] valueList = { picName };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }
    }
}
