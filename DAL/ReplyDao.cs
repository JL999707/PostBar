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
    public class ReplyDao
    {
        IDbHelper db = DBFactory.GetDbHelper();
        public int Add(Reply reply)
        {
            string cmdText = "insert into T_Reply values(@replyID, @userID, @postID,@replyName, @replyContent, @replyTime)";
            string[] paramList = { "@replyID", "@userID", "@postID", "@replyName", "@replyContent", "@replyTime" };
            object[] valueList = { reply.replyID, reply.userID, reply.postID, reply.replyName, reply.replyContent, reply.replyTime };
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        public int Delete(string replyName)
        {
            string cmdText = "delete from T_Reply where replyName=@replyName";
            string[] paramList = { "@replyName" };
            object[] valueList = { replyName };
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        public int Update(Reply reply)
        {
            string cmdText = "update T_Reply set replyID=@replyID, userID=@userID, postID=@postID,replyName=@replyName, replyContent=@replyContent, replyTime=@replyTime where replyName=@replyName";
            string[] paramList = { "@replyID", "@userID", "@postID", "@replyContent", "@replyName", "@replyTime" };
            object[] valuesList = { reply.replyID, reply.userID, reply.postID, reply.replyName, reply.replyContent, reply.replyTime };
            return db.ExecuteNoneQuery(cmdText, paramList, valuesList);
        }

        public Reply Query(string replyName)
        {
            string cmdText = "select * from T_Reply where replyName=@replyName";
            string[] paramList = { "@replyName" };
            object[] valueList = { replyName };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            Reply reply = new Reply();
            if (reader.Read())
            {
                reply.replyName = replyName;
                reply.replyID = Convert.ToInt32(reader["replyID"]);
                reply.userID = Convert.ToInt32(reader["userID"]);
                reply.postID = Convert.ToInt32(reader["postID"]);
                reply.replyContent = reader["replyContent"].ToString();
                reply.replyTime = reader["replyTime"].ToString();
            }
            reader.Close();
            return reply;
        }

        public List<Reply> Query(string replyName, bool isAccurate = false)
        {
            List<Reply> replyList = new List<Reply>();
            DataSet ds = new DataSet();
            if (isAccurate)
            {
                string cmdText = "select * from T_Reply where  replyName=@replyName";
                string[] paramList = { "@replyName" };
                object[] valueList = { replyName };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            else
            {
                string cmdText = "select * from T_Reply where  replyName like @replyName";
                string[] paramList = { "@replyName" };
                object[] valueList = { "%" + replyName + "%" };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                Reply reply = new Reply(Convert.ToInt32(dr["replyID"]), Convert.ToInt32(dr["userID"]), Convert.ToInt32(dr["postID"]), dr["replyName"].ToString(), dr["replyContent"].ToString(), dr["replyTime"].ToString());
                replyList.Add(reply);
            }
            return replyList;
        }

        public Reply QueryUserID(int userID)//根据userID查询
        {
            string cmdText = "select * from T_Reply where userID=@userID";
            string[] paramList = { "@userID" };
            object[] valueList = { userID };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            Reply reply = new Reply();
            if (reader.Read())
            {
                reply.userID = userID;
                reply.replyID = Convert.ToInt32(reader["replyID"]);
                reply.replyName = reader["replyName"].ToString();
                reply.postID = Convert.ToInt32(reader["postID"]);
                reply.replyContent = reader["replyContent"].ToString();
                reply.replyTime = reader["replyTime"].ToString();
            }
            reader.Close();
            return reply;
        }
        public Reply QueryPost(int postID)//根据postID查询
        {
            Reply reply = new Reply();
            string cmdText = "select * from T_Reply where postID=@postID";
            string[] paramList = { "@postID" };
            object[] valueList = { postID };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            if (reader.Read())
            {
                reply.postID = postID;
                reply.replyID = Convert.ToInt32(reader["replyID"]);
                reply.replyName = reader["replyName"].ToString();
                reply.userID = Convert.ToInt32(reader["userID"]);
                reply.replyContent = reader["replyContent"].ToString();
                reply.replyTime = reader["replyTime"].ToString();
            }
            reader.Close();
            return reply;
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
        //根据贴子名称得到贴子ID
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
        //根据userID查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountUserID(int userID)
        {
            string cmdText = "select count(*) from  T_Reply where userID=@userID";
            string[] paramList = { "@userID" };
            object[] valueList = { userID };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }
        //根据postID查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountPostID(int postID)
        {
            string cmdText = "select count(*) from  T_Reply where postID=@postID";
            string[] paramList = { "@postID" };
            object[] valueList = { postID };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }
    }
}
