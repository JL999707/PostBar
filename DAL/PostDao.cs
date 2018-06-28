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
    public class PostDao
    {
        IDbHelper db = DBFactory.GetDbHelper();
        public int Add(Post post)
        {
            string cmdText = "insert into T_Post values(@postID, @barID, @postName, @postContent, @postTime,@judge, @postAutoGraph, @postHeadImg, @postTopImg, @postBGImg)";
            string[] paramList = { "@postID", "@barID", "@postName", "@postContent", "@postTime", "@judge", "@postAutoGraph", "@postHeadImg", "@postTopImg", "@postBGImg" };
            object[] valueList = { post.postID, post.barID, post.postName, post.postContent, post.postTime, post.judge, post.postAutoGraph, post.postHeadImg, post.postTopImg, post.postBGImg };
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        public int Delete(string postName)
        {
            string cmdText = "delete from T_Post where postName=@postName";
            string[] paramList = { "@postName" };
            object[] valueList = { postName };
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        public int Update(Post post)
        {
            string cmdText = "update T_Post set postID=@postID, barID=@barID, postName=@postName, postContent=@postContent, postTime=@postTime,judge=@judge, postAutoGraph=@postAutoGraph, postHeadImg=@postHeadimg, postTopImg=@postTopImg, postBGImg=@postBGImg where postName=@postName";
            string[] paramList = { "@postID", "@barID", "@postName", "@postContent", "@postTime", "@judge", "@postAutoGraph", "@postHeadImg", "@postTopImg", "@postBGImg" };
            object[] valuesList = { post.postID, post.barID, post.postName, post.postContent, post.postTime, post.judge, post.postAutoGraph, post.postHeadImg, post.postTopImg, post.postBGImg };
            return db.ExecuteNoneQuery(cmdText, paramList, valuesList);
        }

        public Post Query(string postName)
        {
            string cmdText = "select * from T_Post where postName=@postName";
            string[] paramList = { "@postName" };
            object[] valueList = { postName };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            Post post = new Post();
            if (reader.Read())
            {
                post.postName = postName;
                post.postID = Convert.ToInt32(reader["postID"]);
                post.barID = Convert.ToInt32(reader["barID"]);
                post.postContent = reader["postContent"].ToString();
                post.postTime = reader["postTime"].ToString();
                post.judge = reader["judge"].ToString();
                post.postAutoGraph = reader["postAutoGraph"].ToString();
                post.postHeadImg = reader["postHeadImg"].ToString();
                post.postTopImg = reader["postTopImg"].ToString();
                post.postBGImg = reader["postBGImg"].ToString();
                //post.postName = reader["postName"].ToString();
            }
            reader.Close();
            return post;
        }

        public List<Post> Query(string postName, bool isAccurate = false)
        {
            List<Post> postList = new List<Post>();
            DataSet ds = new DataSet();
            if (isAccurate)
            {
                string cmdText = "select * from T_Post where postName=@postName";
                string[] paramList = { "@postName" };
                object[] valueList = { postName };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            else
            {
                string cmdText = "select * from T_Post where postName like @postName";
                string[] paramList = { "@postName" };
                object[] valueList = { "%" + postName + "%" };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                Post post = new Post(Convert.ToInt32(dr["postID"]), Convert.ToInt32(dr["barID"]), dr["postName"].ToString(), dr["postContent"].ToString(), dr["postTime"].ToString(), dr["judge"].ToString(), dr["postAutoName"].ToString(), dr["postHeadImg"].ToString(), dr["postTopImg"].ToString(), dr["postBGImg"].ToString());
                postList.Add(post);
            }
            return postList;
        }

        //根据postName查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountPostName(string postName)
        {
            string cmdText = "select count(*) from  T_Post where postName=@postName";
            string[] paramList = { "@postName" };
            object[] valueList = { postName };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }

        //根据贴吧名称barName得到贴吧ID，barID
        public Bar getBarID(string barName)
        {
            string cmdText = "select * from T_User where barName=@barName";
            string[] paramList = { "@barName" };
            object[] valueList = { barName };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            Bar bar = new Bar();
            if (reader.Read())
            {
                bar.barName = barName;
                bar.barID = Convert.ToInt32(reader["barID"]);
            }
            reader.Close();
            return bar;
        }

        //根据barID查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountBarID(int barID)
        {
            string cmdText = "select count(*) from  T_Post where barID=@barID";
            string[] paramList = { "@barID" };
            object[] valueList = { barID };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }
    }
}
