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
    public class PrivateLetterDao
    {
        IDbHelper db = DBFactory.GetDbHelper();
        public int Add(PrivateLetter privLetUser)
        {
            string cmdText = "insert into T_PrivateLetter values(@privLetUserID, @privUserID, @bePrivUserID,@privName, @privTime)";
            string[] paramList = { "@privLetID", "@privUserID", "@bePrivUserID", "@privName", "@privTime" };
            object[] valueList = { privLetUser.privLetID, privLetUser.privUserID, privLetUser.bePrivUserID, privLetUser.privName, privLetUser.privTime };
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        public int Delete(string privName)
        {
            string cmdText = "delete from T_PrivateLetter where privName=@privName";
            string[] paramList = { "@privName" };
            object[] valueList = { privName };
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        public int Update(PrivateLetter privLetUser)
        {
            string cmdText = "update T_PrivateLetter set privLetID=@privLetID, privUserID=@privUserID, bePrivUserID=@bePrivUserID,privName=@privName, privTime=@privTime where privName=@privName";
            string[] paramList = { "@T_PrivLetUserID", "@privUserID", "@bePrivUserID", "@privTitle", "@privTime" };
            object[] valuesList = { privLetUser.privLetID, privLetUser.privUserID, privLetUser.bePrivUserID, privLetUser.privName, privLetUser.privTime };
            return db.ExecuteNoneQuery(cmdText, paramList, valuesList);
        }

        public List<PrivateLetter> Query(string privName, bool isAccurate = false)
        {
            List<PrivateLetter> privLetUserList = new List<PrivateLetter>();
            DataSet ds = new DataSet();
            if (isAccurate)
            {
                string cmdText = "select * from T_PrivateLetter where privName=@privName";
                string[] paramList = { "@privName" };
                object[] valueList = { privName };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            else
            {
                string cmdText = "select * from T_PrivateLetter where privName like @privName";
                string[] paramList = { "@privName" };
                object[] valueList = { "%" + privName + "%" };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                PrivateLetter privLetUser = new PrivateLetter(Convert.ToInt32(dr["privLetID"]), Convert.ToInt32(dr["privUserID"]), Convert.ToInt32(dr["bePrivUserID"]), dr["privName"].ToString(), dr["privTime"].ToString());
                privLetUserList.Add(privLetUser);
            }
            return privLetUserList;
        }

        public PrivateLetter QueryPrivName(string privName)//根据被私信者名字查询
        {
            string cmdText = "select * from T_PrivateLetter where privName=@privName";
            string[] paramList = { "@privName" };
            object[] valueList = { privName };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            PrivateLetter privLetUser = new PrivateLetter();
            if (reader.Read())
            {
                privLetUser.privName = privName;
                privLetUser.privLetID = Convert.ToInt32(reader["privLetID"]);
                privLetUser.privUserID = Convert.ToInt32(reader["privUserID"]);
                privLetUser.bePrivUserID = Convert.ToInt32(reader["bePrivUserID"]);
                privLetUser.privTime = reader["privTime"].ToString();
            }
            reader.Close();
            return privLetUser;
        }
        public PrivateLetter QueryPrivUserID(int privUserID)//根据主动私信者IDprivUserID查询
        {
            string cmdText = "select * from T_PrivateLetter where privUserID=@privUserID";
            string[] paramList = { "@privUserID" };
            object[] valueList = { privUserID };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            PrivateLetter privLetUser = new PrivateLetter();
            if (reader.Read())
            {
                privLetUser.privUserID = privUserID;
                privLetUser.privLetID = Convert.ToInt32(reader["privLetID"]);
                privLetUser.privName = reader["privName"].ToString();
                privLetUser.bePrivUserID = Convert.ToInt32(reader["bePrivUserID"]);
                privLetUser.privTime = reader["privTime"].ToString();
            }
            reader.Close();
            return privLetUser;
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

        //根据被私信者名称查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountUserName(string privName)
        {
            string cmdText = "select count(*) from  T_PrivateLetter  where privName=@privName";
            string[] paramList = { "@privName" };
            object[] valueList = { privName };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }

        //根据主动私信者IDprivUserID查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountUserID(int privUserID)
        {
            string cmdText = "select count(*) from  T_PrivateLetter  where privUserID=@privUserID";
            string[] paramList = { "@privUserID" };
            object[] valueList = { privUserID };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }
        //根据privLetID查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountPrivLetID(int privLetID)
        {
            string cmdText = "select count(*) from  T_PrivateLetter where privLetID=@privLetID";
            string[] paramList = { "@privLetID" };
            object[] valueList = { privLetID };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }
    }
}
