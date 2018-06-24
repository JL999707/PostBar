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
    }
}
