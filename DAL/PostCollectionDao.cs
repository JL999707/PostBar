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
    public class PostCollectionDao
    {
        IDbHelper db = DBFactory.GetDbHelper();
        public int Add(PostCollection postColl)
        {
            string cmdText = "insert into T_PostCollection values(@collID, @userID, @postID,@collName, @collTime)";
            string[] paramList = { "@collID", "@userID", "@postID", "@collName", "@collTime" };
            object[] valueList = { postColl.collID, postColl.userID, postColl.postID, postColl.collName, postColl.collTime };
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        public int Delete(string collName)
        {
            string cmdText = "delete from T_PostCollection where collName=@collName";
            string[] paramList = { "@collName" };
            object[] valueList = { collName };
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        public int Update(PostCollection postColl)
        {
            string cmdText = "update T_PostCollection set collID=@collID, userID=@userID, postID=@postID,collName=@collName, collTime=@collTime where collName=@collName";
            string[] paramList = { "@collID", "@userID", "@postID", "@collName", "@collTime" };
            object[] valuesList = { postColl.collID, postColl.userID, postColl.postID, postColl.collName, postColl.collTime };
            return db.ExecuteNoneQuery(cmdText, paramList, valuesList);
        }
        public List<PostCollection> Query(string collName, bool isAccurate = false)
        {
            List<PostCollection> postCollList = new List<PostCollection>();
            DataSet ds = new DataSet();
            if (isAccurate)
            {
                string cmdText = "select * from T_PostCollection where collName=@collName";
                string[] paramList = { "@collName" };
                object[] valueList = { collName };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            else
            {
                string cmdText = "select * from T_PostCollection where collName like @collName";
                string[] paramList = { "@collName" };
                object[] valueList = { "%" + collName + "%" };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                PostCollection postColl = new PostCollection(Convert.ToInt32(dr["collID"]), Convert.ToInt32(dr["userID"]), Convert.ToInt32(dr["uostID"]), dr["collName"].ToString(), dr["collTime"].ToString());
                postCollList.Add(postColl);
            }
            return postCollList;
        }
        public PostCollection QueryCollName(string collName)//根据贴子名字查询
        {
            string cmdText = "select * from T_PostCollection where collName=@collName";
            string[] paramList = { "@collName" };
            object[] valueList = { collName };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            PostCollection postColl = new PostCollection();
            if (reader.Read())
            {
                postColl.collName = collName;
                postColl.collID = Convert.ToInt32(reader["collID"]);
                postColl.postID = Convert.ToInt32(reader["postID"]);
                postColl.collTime = reader["collTime"].ToString();
                postColl.userID = Convert.ToInt32(reader["userID"]);
            }
            reader.Close();
            return postColl;
        }
        public PostCollection QueryUserID(int userID)//根据userID查询
        {
            string cmdText = "select * from T_PostCollection where userID=@userID";
            string[] paramList = { "@userID" };
            object[] valueList = { userID };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            PostCollection postColl = new PostCollection();
            if (reader.Read())
            {
                postColl.userID = userID;
                postColl.collName = reader["collName"].ToString();
                postColl.collID = Convert.ToInt32(reader["collID"]);
                postColl.postID = Convert.ToInt32(reader["postID"]);
                postColl.collTime = reader["collTime"].ToString();
            }
            reader.Close();
            return postColl;
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

        //根据贴子名称查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountCollName(string collName)
        {
            string cmdText = "select count(*) from  T_PostCollection where collName=@collName";
            string[] paramList = { "@collName" };
            object[] valueList = { collName };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }

        //根据userID查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountUserID(int userID)
        {
            string cmdText = "select count(*) from  T_PostCollection where userID=@userID";
            string[] paramList = { "@userID" };
            object[] valueList = { userID };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }
        //根据postCollID查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountPostCollID(int postCollID)
        {
            string cmdText = "select count(*) from  T_PostCollection where postCollID=@postCollID";
            string[] paramList = { "@postCollID" };
            object[] valueList = { postCollID };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }
    }
}
