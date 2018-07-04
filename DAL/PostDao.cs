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
        //public int Add(Post post)
        //{
        //    string cmdText = "insert into T_Post values( @barID,@userID, @postName, @postContent, @postTime,@postPic)";
        //    string[] paramList = { "@barID", "@userID", "@postName", "@postContent", "@postTime", "@postPic" };
        //    object[] valueList = { post.barID, post.userID, post.postName, post.postContent, post.postTime, post.postPic };
        //    return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        //}
        public int Add(Post post)
        {
            string cmdText = "insert into T_Post values (@barID,@userID, @postName, @postContent, @postTime,@postPic,@judge, @postAutoGraph, @postHeadImg, @postTopImg, @postBGImg)";
            string[] paramList = { "@barID", "@userID", "@postName", "@postContent", "@postTime", "@postPic", "@judge", "@postAutoGraph", "@postHeadImg", "@postTopImg", "@postBGImg" };
            object[] valueList = { post.barID, post.userID, post.postName, post.postContent, post.postTime, post.postPic, post.judge,  post.postAutoGraph, post.postHeadImg, post.postTopImg, post.postBGImg };
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
            string cmdText = "update T_Post set postID=@postID, barID=@barID, postName=@postName, postContent=@postContent, postTime=@postTime,judge=@judge,postPic=@postPic, postAutoGraph=@postAutoGraph, postHeadImg=@postHeadimg, postTopImg=@postTopImg, postBGImg=@postBGImg where postName=@postName";
            string[] paramList = { "@postID", "@barID", "@postName", "@postContent", "@postTime", "@judge", "@postAutoGraph", "@postHeadImg", "@postTopImg", "@postBGImg" };
            object[] valuesList = { post.postID, post.barID, post.postName, post.postContent, post.postTime, post.judge,post.postPic, post.postAutoGraph, post.postHeadImg, post.postTopImg, post.postBGImg };
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
                post.userID = Convert.ToInt32(reader["userID"]);
                post.postContent = reader["postContent"].ToString();
                post.postTime = reader["postTime"].ToString();
                post.judge = reader["judge"].ToString();
                post.postPic = reader["postPic"].ToString();
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
                Post post = new Post(Convert.ToInt32(dr["postID"]), Convert.ToInt32(dr["barID"]), Convert.ToInt32(dr["userID"]), dr["postName"].ToString(), dr["postContent"].ToString(), dr["postTime"].ToString(), dr["judge"].ToString(),dr["postPic"].ToString(), dr["postAutoGraph"].ToString(), dr["postHeadImg"].ToString(), dr["postTopImg"].ToString(), dr["postBGImg"].ToString());
                postList.Add(post);
            }
            return postList;
        }

        public List<Post> userIDQuery(int userID, bool isAccurate = false)
        {
            List<Post> postList = new List<Post>();
            DataSet ds = new DataSet();
            if (isAccurate)
            {
                string cmdText = "select * from T_Post where userID=@userID";
                string[] paramList = { "@userID" };
                object[] valueList = { userID };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            else
            {
                string cmdText = "select * from T_Post where userID like @userID";
                string[] paramList = { "@userID" };
                object[] valueList = { "%" + userID + "%" };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                Post post = new Post(Convert.ToInt32(dr["postID"]), Convert.ToInt32(dr["barID"]), Convert.ToInt32(dr["userID"]), dr["postName"].ToString(), dr["postContent"].ToString(), dr["postTime"].ToString(), dr["judge"].ToString(), dr["postPic"].ToString(), dr["postAutoGraph"].ToString(), dr["postHeadImg"].ToString(), dr["postTopImg"].ToString(), dr["postBGImg"].ToString());
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
            string cmdText = "select * from T_Bar where barName=@barName";
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
        //根据barID得到barName
        public Bar getBarName(int barID)
        {
            string cmdText = "select * from T_Bar where barID=@barID";
            string[] paramList = { "@barID" };
            object[] valueList = { barID };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            Bar bar = new Bar();
            if (reader.Read())
            {
                bar.barID = barID;
                bar.barName = reader["barName"].ToString();
            }
            reader.Close();
            return bar;
        }
        //根据postID得到postName
        public Post getPostName(int postID)
        {
            string cmdText = "select * from T_Post where postID=@postID";
            string[] paramList = { "@postID" };
            object[] valueList = { postID };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            Post post = new Post();
            if (reader.Read())
            {
                post.postID = postID;
                post.postName = reader["postName"].ToString();
            }
            reader.Close();
            return post;
        }
        //根据postName得到postID
        public Post getPostID(string postName)
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
            }
            reader.Close();
            return post;
        }
        //根据postID得到userID
        public Post getPostUserID(int postID)
        {
            string cmdText = "select * from T_Post where postID=@postID";
            string[] paramList = { "@postID" };
            object[] valueList = { postID };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            Post post = new Post();
            if (reader.Read())
            {
                post.postID = postID;
                post.userID = Convert.ToInt32(reader["userID"]);
            }
            reader.Close();
            return post;
        }
        //根据贴吧名称userName得到用户ID，userID
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
        //根据userID得到userName
        public UserInfo getUserName(int userID)
        {
            string cmdText = "select * from T_User where userID=@userID";
            string[] paramList = { "@userID" };
            object[] valueList = { userID };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            UserInfo user = new UserInfo();
            if (reader.Read())
            {
                user.userID = userID;
                user.userName =reader["userName"].ToString();
            }
            reader.Close();
            return user;
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
        //根据postID查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountPostID(int postID)
        {
            string cmdText = "select count(*) from  T_Post where postID=@postID";
            string[] paramList = { "@postID" };
            object[] valueList = { postID };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }

        //根据userID查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountUserID(int userID)
        {
            string cmdText = "select count(*) from  T_Post where userID=@userID";
            string[] paramList = { "@userID" };
            object[] valueList = { userID };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }

        //查询最近添加的记录
        public List<Post> getDesc(string postName, bool isAccurate = false)
        {
            List<Post> postList = new List<Post>();
            DataSet ds = new DataSet();
            if (isAccurate)
            {
                string cmdText = "select * from T_Post where postName like @postName order by postID desc";
                string[] paramList = { "@postName" };
                object[] valueList = { postName };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            else
            {
                string cmdText = "select * from T_Post where postName like @postName order by postID desc";
                string[] paramList = { "@postName" };
                object[] valueList = { "%" + postName + "%" };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                Post post = new Post(Convert.ToInt32(dr["postID"]), Convert.ToInt32(dr["barID"]), Convert.ToInt32(dr["userID"]), dr["postName"].ToString(), dr["postContent"].ToString(), dr["postTime"].ToString(), dr["judge"].ToString(),dr["postPic"].ToString(), dr["postAutoGraph"].ToString(), dr["postHeadImg"].ToString(), dr["postTopImg"].ToString(), dr["postBGImg"].ToString());
                postList.Add(post);
            }
            return postList;
        }
        //根据barID查询最近添加的记录
        public List<Post> getBarIDesc(int barID, bool isAccurate = false)
        {
            List<Post> postList = new List<Post>();
            DataSet ds = new DataSet();
            if (isAccurate)
            {
                string cmdText = "select * from T_Post where barID like @barID order by postID desc";
                string[] paramList = { "@barID" };
                object[] valueList = { barID };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            else
            {
                string cmdText = "select * from T_Post where barID like @barID order by postID desc";
                string[] paramList = { "@barID" };
                object[] valueList = { "%" + barID + "%" };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                Post post = new Post(Convert.ToInt32(dr["postID"]), Convert.ToInt32(dr["barID"]), Convert.ToInt32(dr["userID"]), dr["postName"].ToString(), dr["postContent"].ToString(), dr["postTime"].ToString(), dr["judge"].ToString(), dr["postPic"].ToString(), dr["postAutoGraph"].ToString(), dr["postHeadImg"].ToString(), dr["postTopImg"].ToString(), dr["postBGImg"].ToString());
                postList.Add(post);
            }
            return postList;
        }
    }
}
