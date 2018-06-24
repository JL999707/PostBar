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

        public PostCollection Query(string collName)
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
    }
}
