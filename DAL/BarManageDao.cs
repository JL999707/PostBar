using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbHelper;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class BarManageDao
    {
        IDbHelper db = DBFactory.GetDbHelper();
        public int Add(BarManage barMana)
        {
            string cmdText = "insert into T_BarManage values(@barManaID,@postID, @userID,@manaType,@manaTime)";
            string[] paramList = { "@barManaID", "@postID", "@userID", "@manaType", "@manaTime" };
            object[] valueList = { barMana.barManaID, barMana.postID, barMana.userID, barMana.manaType, barMana.manaTime };
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        public int Delete(int barManaID)
        {
            string cmdText = "delete from T_BarManage where  barManaID=@barManaID";
            string[] paramList = { "@barManaID" };
            object[] valueList = { barManaID };
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        public int Update(BarManage barMana)
        {
            string cmdText = "update T_BarManage set barManaID=@barManaID, postID=@postID,userID=@userID,manaType=@manaType,manaTime=@manaTime";
            string[] paramList = { "@barManaID", "@postID", "@userID", "@manaType", "@manaTime" };
            object[] valuesList = { barMana.barManaID, barMana.postID, barMana.userID, barMana.manaType, barMana.manaTime};
            return db.ExecuteNoneQuery(cmdText, paramList, valuesList);
        }

        public BarManage QueryBarManaID(int barManaID)
        {
            string cmdText = "select * from T_BarManage where barManaID=@barManaID";
            string[] paramList = { "@barManaID" };
            object[] valueList = { barManaID };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            BarManage barMana = new BarManage();
            if (reader.Read())
            {
                barMana.barManaID = barManaID;
                barMana.postID = Convert.ToInt32(reader["postID"]);
                barMana.userID = Convert.ToInt32(reader["userID"]);
                barMana.manaType = reader["manaType"].ToString();
                barMana.manaTime = reader["manaTime"].ToString();
            }
            reader.Close();
            return barMana;
        }

        public List<BarManage> QueryBarManaID(int barManaID, bool isAccurate = false)
        {
            List<BarManage> barManatList = new List<BarManage>();
            DataSet ds = new DataSet();
            if (isAccurate)
            {
                string cmdText = "select * from T_BarManage where barManaID=@barManaID";
                string[] paramList = { "barManaID" };
                object[] valueList = { barManaID };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            else
            {
                string cmdText = "select * from T_BarManage where barManaID like @barManaID";
                string[] paramList = { "@barManaID" };
                object[] valueList = { "%" + barManaID + "%" };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                BarManage barManat = new BarManage(Convert.ToInt32(dr["barManaID"]), Convert.ToInt32(dr["postID"]), Convert.ToInt32(dr["userID"]),dr["manaType"].ToString(), dr["manaTime"].ToString());
                barManatList.Add(barManat);
            }
            return barManatList;
        }

        public BarManage QueryPost(int postID)//根据postID查询
        {
            BarManage barMana = new BarManage();
            string cmdText = "select * from T_BarManage where postID=@postID";
            string[] paramList = { "@postID" };
            object[] valueList = { postID };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            if (reader.Read())
            {
                barMana.postID = postID;
                barMana.userID = Convert.ToInt32(reader["userID"]);
                barMana.barManaID = Convert.ToInt32(reader["barManaID"]);
                barMana.manaType = reader["manaType"].ToString();
                barMana.manaTime = reader[".manaTime"].ToString();
            }
            reader.Close();
            return barMana;
        }
        public BarManage QueryUser(int userID)//根据userID查询
        {
            string cmdText = "select * from T_BarManage where userID=@userID";
            string[] paramList = { "@userID" };
            object[] valueList = { userID };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            BarManage barMana = new BarManage();
            if (reader.Read())
            {
                barMana.userID = userID;
                barMana.postID = Convert.ToInt32(reader["postID"]);
                barMana.barManaID = Convert.ToInt32(reader["barManaID"]);
                barMana.manaType = reader["manaType"].ToString();
                barMana.manaTime = reader[".manaTime"].ToString();
            }
            reader.Close();
            return barMana;
        }
        public BarManage QueryManaType(string manaType)//根据ruleID查询
        {
            BarManage barMana = new BarManage();
            string cmdText = "select * from T_BarManage where manaType=@manaType";
            string[] paramList = { "@manaType" };
            object[] valueList = { manaType };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            if (reader.Read())
            {
                barMana.manaType = manaType;
                barMana.postID = Convert.ToInt32(reader["postID"]);
                barMana.barManaID = Convert.ToInt32(reader["barManaID"]);
                barMana.userID = Convert.ToInt32(reader["userID"]);
                barMana.manaTime = reader[".manaTime"].ToString();
            }
            reader.Close();
            return barMana;
        }
        public BarManage QueryManaTime(string manaTime)//根据ruleID查询
        {
            BarManage barMana = new BarManage();
            string cmdText = "select * from T_BarManage where manaTime=@manaTime";
            string[] paramList = { "@manaTime" };
            object[] valueList = { manaTime };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            if (reader.Read())
            {
                barMana.manaTime = manaTime;
                barMana.postID = Convert.ToInt32(reader["postID"]);
                barMana.barManaID = Convert.ToInt32(reader["barManaID"]);
                barMana.userID = Convert.ToInt32(reader["userID"]);
                barMana.manaType = reader[".manaType"].ToString();
            }
            reader.Close();
            return barMana;
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
        //根据postID查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountPostID(int postID)
        {
            string cmdText = "select count(*) from  T_BarManage where postID=@postID";
            string[] paramList = { "@postID" };
            object[] valueList = { postID };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }
        //根据userID查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountUserID(int userID)
        {
            string cmdText = "select count(*) from  T_BarManage where userID=@userID";
            string[] paramList = { "@userID" };
            object[] valueList = { userID };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }
        //根据贴吧管理类型查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountManaType(string manaType)
        {
            string cmdText = "select count(*) from  T_BarManage where manaType=@manaType";
            string[] paramList = { "@manaType" };
            object[] valueList = { manaType };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }
        //根据贴吧管理时间某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountManaTime(string manaTime)
        {
            string cmdText = "select count(*) from  T_BarManage where manaTime=@manaTime";
            string[] paramList = { "@manaTime" };
            object[] valueList = { manaTime };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }
    }
}
