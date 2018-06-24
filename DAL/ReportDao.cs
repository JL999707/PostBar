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
                Report report = new Report(Convert.ToInt32(dr["reportID"]), Convert.ToInt32(dr["userID"]), Convert.ToInt32(dr["postID"]), Convert.ToInt32(dr["ruleID"]), dr["reportName"].ToString(), dr["reportReason"].ToString(), dr["reportResult"].ToString(), dr["reportTime"].ToString());
                reportList.Add(report);
            }
            return reportList;
        }
    }
}
