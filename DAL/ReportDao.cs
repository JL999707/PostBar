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
    public class ReportDao
    {
        IDbHelper db = DBFactory.GetDbHelper();
        public int Add(Report report)
        {
            string cmdText = "insert into T_Report values(@reportID, @userID,@postID,@ruleID,@reportName, @reportReason, @repotResult, @reportTime)";
            string[] paramList = { "@rportID", "@userID", "@postID", "@ruleID", "@reportName", "@reportReason", "@repotResult", "@reportTime" };
            object[] valueList = { report.reportID, report.userID, report.postID, report.ruleID, report.reportName, report.reportReason, report.reportResult, report.reportTime };
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        public int Delete(string reportName)
        {
            string cmdText = "delete from T_Report where reportName=@reportName";
            string[] paramList = { "@reportName" };
            object[] valueList = { reportName };
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        public int Update(Report report)
        {
            string cmdText = "update T_Report set reportID=@reportID, userID=@userID,postID=@postID,ruleID=@ruleID,reportName=@reportName, reportReason=@reportReason, repotResult=@repotResult,reportTime=@reportTime where reportName=@reportName";
            string[] paramList = { "@reportID", "@userID", "@postID", "@ruleID", "@reportName", "@reportReason", "@repotResult", "@reportTime" };
            object[] valuesList = { report.reportID, report.userID, report.postID, report.ruleID, report.reportName, report.reportReason, report.reportResult, report.reportTime };
            return db.ExecuteNoneQuery(cmdText, paramList, valuesList);
        }

        public Report Query(string reportName)
        {
            string cmdText = "select * from T_Report where reportName=@reportName";
            string[] paramList = { "@reportName" };
            object[] valueList = { reportName };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            Report report = new Report();
            if (reader.Read())
            {
                report.reportName = reportName;
                report.reportID = Convert.ToInt32(reader["reportID"]);
                report.userID = Convert.ToInt32(reader["userID"]);
                report.postID = Convert.ToInt32(reader["postID"]);
                report.ruleID = Convert.ToInt32(reader["ruleID"]);
                report.reportReason = reader["reportReason"].ToString();
                report.reportTime = reader["reportTime"].ToString();
                report.reportResult = reader["reportResult"].ToString();
            }
            reader.Close();
            return report;
        }

        public List<Report> Query(string reportName, bool isAccurate = false)
        {
            List<Report> reportList = new List<Report>();
            DataSet ds = new DataSet();
            if (isAccurate)
            {
                string cmdText = "select * from T_Report where reportName=@reportName";
                string[] paramList = { "@reportName" };
                object[] valueList = { reportName };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            else
            {
                string cmdText = "select * from T_Report where reportName like @reportName";
                string[] paramList = { "@reportName" };
                object[] valueList = { "%" + reportName + "%" };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                Report report = new Report(Convert.ToInt32(dr["reportID"]), Convert.ToInt32(dr["userID"]), Convert.ToInt32(dr["postID"]),Convert.ToInt32(dr["ruleID"]), dr["reportName"].ToString(), dr["reportReason"].ToString(), dr["reportResult"].ToString(), dr["reportTime"].ToString());
                reportList.Add(report);
            }
            return reportList;
        }

        public Report QueryUser(int userID)//根据userID查询
        {
            string cmdText = "select * from T_Report where userID=@userID";
            string[] paramList = { "@userID" };
            object[] valueList = { userID };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            Report report = new Report();
            if (reader.Read())
            {
                report.userID = userID;
                report.reportID = Convert.ToInt32(reader["reportID"]);
                report.reportName = reader["reportName"].ToString();
                report.postID = Convert.ToInt32(reader["postID"]);
                report.ruleID = Convert.ToInt32(reader["ruleID"]);
                report.reportReason = reader["reportReason"].ToString();
                report.reportTime = reader["reportTime"].ToString();
                report.reportResult = reader["reportResult"].ToString();
            }
            reader.Close();
            return report;
        }
        public Report QueryPost(int postID)//根据postID查询
        {
            Report report = new Report();
            string cmdText = "select * from T_Report where postID=@postID";
            string[] paramList = { "@postID" };
            object[] valueList = { postID };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            if (reader.Read())
            {
                report.postID = postID;
                report.reportID = Convert.ToInt32(reader["reportID"]);
                report.reportName = reader["reportName"].ToString();
                report.userID = Convert.ToInt32(reader["userID"]);
                report.ruleID = Convert.ToInt32(reader["ruleID"]);
                report.reportReason = reader["reportReason"].ToString();
                report.reportTime = reader["reportTime"].ToString();
                report.reportResult = reader["reportResult"].ToString();
            }
            reader.Close();
            return report;
        }
        public Report QueryRule(int ruleID)//根据ruleID查询
        {
            Report report = new Report();
            string cmdText = "select * from T_Report where ruleID=@ruleID";
            string[] paramList = { "@ruleID" };
            object[] valueList = { ruleID };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            if (reader.Read())
            {
                report.ruleID = ruleID;
                report.reportID = Convert.ToInt32(reader["reportID"]);
                report.reportName = reader["reportName"].ToString();
                report.userID = Convert.ToInt32(reader["userID"]);
                report.postID = Convert.ToInt32(reader["postID"]);
                report.reportReason = reader["reportReason"].ToString();
                report.reportTime = reader["reportTime"].ToString();
                report.reportResult = reader["reportResult"].ToString();
            }
            reader.Close();
            return report;
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
        //根据规则名称得到规则ID
        public Model.Rule getRuleID(string ruleItem)
        {
            string cmdText = "select * from T_Rule where ruleItem=@ruleItem";
            string[] paramList = { "@ruleItem" };
            object[] valueList = { ruleItem };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            Model.Rule rule = new Model.Rule();
            if (reader.Read())
            {
                rule.ruleItem = ruleItem;
                rule.ruleID = Convert.ToInt32(reader["ruleID"]);
            }
            reader.Close();
            return rule;
        }
        //根据userID查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountUserID(int userID)
        {
            string cmdText = "select count(*) from  T_Report where userID=@userID";
            string[] paramList = { "@userID" };
            object[] valueList = { userID };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }
        //根据postID查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountPostID(int postID)
        {
            string cmdText = "select count(*) from  T_Report where postID=@postID";
            string[] paramList = { "@postID" };
            object[] valueList = { postID };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }
        //根据ruleID查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountRuleID(int ruleID)
        {
            string cmdText = "select count(*) from  T_Report where ruleID=@ruleID";
            string[] paramList = { "@ruleID" };
            object[] valueList = { ruleID };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }
        //根据reportID查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountReportID(int reportID)
        {
            string cmdText = "select count(*) from  T_Roprt where reportID=@reportID";
            string[] paramList = { "@reportID" };
            object[] valueList = { reportID };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }
    }
}
