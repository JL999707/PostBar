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
    public class UserAttentionDao
    {
        IDbHelper db = DBFactory.GetDbHelper();
        public int Add(Model.UserAttention userAtt)
        {
            string cmdText = "insert into T_UserAttention values(@userAttID, @userID, @beUserID,@userAttName, @userAttTime)";
            string[] paramList = { "userAttID", "@userID", "@beUserID", "@userAttName", "@userAttTime" };
            object[] valueList = { userAtt.userAttID, userAtt.userID, userAtt.beUserID, userAtt.userAttName, userAtt.userAttTime };
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        public int Delete(string userAttName)
        {
            string cmdText = "delete from T_UserAttention where userAttName=@userAttName";
            string[] paramList = { "@userAttName" };
            object[] valueList = { userAttName };
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        public int Update(Model.UserAttention userAtt)
        {
            string cmdText = "update T_UserAttention set userAttID=@userAttID, userID=@userID, beUserID=@beUserID,userAttName=@userAttName,userAttTime=@userAttTime where userAttName=@userAttName";
            string[] paramList = { "userAttID", "@userID", "@beUserID", "@userAttName", "@userAttTime" };
            object[] valuesList = { userAtt.userAttID, userAtt.userID, userAtt.beUserID, userAtt.userAttName, userAtt.userAttTime };
            return db.ExecuteNoneQuery(cmdText, paramList, valuesList);
        }

        public Model.UserAttention Query(string userAttName)
        {
            string cmdText = "select * from T_UserAttention where userAttName=@userAttName";
            string[] paramList = { "@userAttName" };
            object[] valueList = { userAttName };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            Model.UserAttention userAtt = new Model.UserAttention();
            if (reader.Read())
            {
                userAtt.userAttName = userAttName;
                userAtt.userAttID = Convert.ToInt32(reader["userAttID"]);
                userAtt.userID = Convert.ToInt32(reader["userID"]);
                userAtt.beUserID = Convert.ToInt32(reader["beUserID"]);
                userAtt.userAttTime = reader["userAttTime"].ToString();
            }
            reader.Close();
            return userAtt;
        }

        public List<Model.UserAttention> Query(string userAttName, bool isAccurate = false)
        {
            List<Model.UserAttention> userAttList = new List<Model.UserAttention>();
            DataSet ds = new DataSet();
            if (isAccurate)
            {
                string cmdText = "select * from T_UserAttention where userAttName=@userAttName";
                string[] paramList = { "@userAttName" };
                object[] valueList = { userAttName };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            else
            {
                string cmdText = "select * from T_UserAttention where userAttName like @userAttName";
                string[] paramList = { "@userAttName" };
                object[] valueList = { "%" + userAttName + "%" };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                Model.UserAttention userAtt = new Model.UserAttention(Convert.ToInt32(dr["userAttID"]), Convert.ToInt32(dr["userID"]), Convert.ToInt32(dr["beUserID"]), dr["userAttName"].ToString(), dr["userAttTime"].ToString());
                userAttList.Add(userAtt);
            }
            return userAttList;
        }
    }
}
