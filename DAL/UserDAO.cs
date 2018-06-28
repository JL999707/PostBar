using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DbHelper;

namespace DAL
{
    public class UserDAO
    {
        string connStr;
        SqlConnection conn;
        IDbHelper db = DBFactory.GetDbHelper();
        //增加用户、用户注册
        public int Add(UserInfo user)
        {
            string cmdText = "insert into T_User values(@userName,@pwd,@userSex,@userTime,@userContactInfo,@autoGraph,@userHeadImg,@userTopImg,@userBGImg)";
            string[] paramList = { "@userName", "@pwd", "@userSex", "@userTime", "@userContactInfo", "@autoGraph", "@userHeadImg", "@userTopImg", "@userBGImg" };
            object[] valueList = { user.userName, user.pwd, user.userSex, user.userTime, user.userContactInfo, user.autoGraph, user.userHeadImg, user.userTopImg, user.userBGImg };
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        //用户登录验证
        public UserInfo SelectUser(string userName, string pwd)
        {
            //建立数据库连接
            connStr = ConfigurationManager.ConnectionStrings["PostBar"].ConnectionString;
            conn = new SqlConnection(connStr);

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            //执行SQL语句进行查询
            string str = "select *  from T_User where userName=@userName and pwd =@pwd";
            SqlCommand cmd = new SqlCommand(str, conn);

            //添加查询的两个参数
            cmd.Parameters.Add(new SqlParameter("@userName", userName));
            cmd.Parameters.Add(new SqlParameter("@pwd", pwd));

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            Model.UserInfo user = null;
            //读取具体的数据
            while (reader.Read())
            {
                if (user == null)
                {
                    user = new Model.UserInfo();
                }
                //读取查询到的数据
                user.userName = reader.GetString(1);
                user.pwd = reader.GetString(2);
            }
            return user;
        }

        //删除用户
        public int Delete(string userName)
        {
            string cmdText = "delete from T_User where userName=@userName";
            string[] paramList = { "@userName" };
            object[] valueList = { userName };
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        //更新用户基本信息/图片
        public int Update(UserInfo user)
        {
            string cmdText = "update T_User set  pwd = @pwd, userContactInfo=@userContactInfo,autoGraph=@autoGraph,userHeadImg=@userHeadImg,userTopImg=@userTopImg,userBGImg=@userBGImg where userName=@userName";
            string[] paramList = { "@userName", "@pwd", "@userContactInfo", "@autoGraph", "@userHeadImg", "@userTopImg", "@userBGImg" };
            object[] valuesList = { user.userName, user.pwd, user.userContactInfo, user.autoGraph, user.userHeadImg, user.userTopImg, user.userBGImg };
            return db.ExecuteNoneQuery(cmdText, paramList, valuesList);
        }

        //精确检索T_User所有信息
        public UserInfo checkAllUser(string userName)
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
                user.pwd = reader["pwd"].ToString();
                user.userSex = reader["userSex"].ToString();
                user.userContactInfo = reader["userContactInfo"].ToString();
                user.userTime = reader["userTime"].ToString();

                if (!reader.IsDBNull(5))
                {
                    user.autoGraph = reader["autoGraph"].ToString();
                }
                if (!reader.IsDBNull(6))
                {
                    user.userHeadImg = reader["userHeadImg"].ToString();
                }
                if (!reader.IsDBNull(7))
                {
                    user.userTopImg = reader["userTopImg"].ToString();
                }
                if (!reader.IsDBNull(8))
                {
                    user.userBGImg = reader["userBGImg"].ToString();
                }
            }
            reader.Close();
            return user;
        }

        // 先精确后模糊搜索相关用户
        public List<UserInfo> likeQueryUserName(string userName, bool isAccurate = false)
        {
            List<UserInfo> userList = new List<UserInfo>();
            DataSet ds = new DataSet();
            if (isAccurate)
            {
                string cmdText = "select * from T_User where userName=@userName";
                string[] paramList = { "@userName" };
                object[] valueList = { userName };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            else
            {
                string cmdText = "select * from T_User where userName like @userName";
                string[] paramList = { "@userName" };
                object[] valueList = { "%" + userName + "%" };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                UserInfo user = new UserInfo(Convert.ToInt32(dr["userID"]), dr["userName"].ToString(), dr["pwd"].ToString(), dr["userSex"].ToString(), dr["userContactInfo"].ToString(), dr["userTime"].ToString(), dr["autoGraph"].ToString(), dr["userHeadImg"].ToString(), dr["userTopImg"].ToString(), dr["userBGImg"].ToString());
                userList.Add(user);
            }
            return userList;
        }

        //根据用户名称查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountUserName(string userName)
        {
            string cmdText = "select count(*) from  T_User where userName=@userName";
            string[] paramList = { "@userName" };
            object[] valueList = { userName };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }


        //public UserInfo checkAllUser(int T_UserID, string userName, string pwd, string userSex, string userContactInfo, string autoGraph, string userHeadPho, string userTopImg, string userBGImg)
        //{
        //    //建立数据库连接
        //    connStr = ConfigurationManager.ConnectionStrings["PostBar"].ConnectionString;
        //    conn = new SqlConnection(connStr);
        //    if (conn.State == ConnectionState.Closed)
        //    {
        //        conn.Open();
        //    }
        //    //执行SQL语句进行查询
        //    string str = "select *  from T_User";
        //    SqlCommand cmd = new SqlCommand(str, conn);

        //    //添加查询的两个参数
        //    cmd.Parameters.Add(new SqlParameter("@T_UserID", T_UserID));
        //    cmd.Parameters.Add(new SqlParameter("@userName", userName));
        //    cmd.Parameters.Add(new SqlParameter("@pwd", pwd));
        //    cmd.Parameters.Add(new SqlParameter("@userSex", userSex));
        //    cmd.Parameters.Add(new SqlParameter("@userContactInfo", userContactInfo));
        //    cmd.Parameters.Add(new SqlParameter("@autoGraph", autoGraph));
        //    cmd.Parameters.Add(new SqlParameter("@userHeadPho", userHeadPho));
        //    cmd.Parameters.Add(new SqlParameter("@userTopImg", userTopImg));
        //    cmd.Parameters.Add(new SqlParameter("@userBGImg", userBGImg));

        //    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

        //    Model.UserInfo user = null;
        //    //读取具体的数据
        //    while (reader.Read())
        //    {
        //        if (user == null)
        //        {
        //            user = new Model.UserInfo();
        //        }
        //        //读取查询到的数据
        //        user.T_UserID = reader.GetInt32(0);
        //        user.userName = reader.GetString(1);
        //        user.pwd = reader.GetString(2);
        //        user.userSex = reader.GetString(3);
        //        user.userContactInfo = reader.GetString(4);

        //        if (!reader.IsDBNull(5))
        //        {
        //            user.autoGraph = reader.GetString(5);
        //        }
        //        if (!reader.IsDBNull(6))
        //        {
        //            user.userHeadPho = reader.GetString(6);
        //        }
        //        if (!reader.IsDBNull(7))
        //        {
        //            user.userTopImg = reader.GetString(7);
        //        }
        //        if (!reader.IsDBNull(8))
        //        {
        //            user.userBGImg = reader.GetString(8);
        //        }
        //    }
        //    return user;
        //}
    }
}
