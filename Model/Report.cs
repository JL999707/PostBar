using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Report
    {
        public int reportID { get; set; }
        public int userID { get; set; }
        public int postID { get; set; }
        public int ruleID { get; set; }
        public string reportName { get; set; }
        public string reportReason { get; set; }
        public string reportResult { get; set; }
        public string reportTime { get; set; }


        public Report() { }

        //贡献出自己的自增ID给其他引用自己主键的表使用
        public Report(int reportID)
        {
            this.reportID = reportID;
        }

        //删除//查询
        public Report(string reportName)
        {
            this.reportID = reportID;
            this.userID = userID;
            this.postID = postID;
            this.ruleID = ruleID;
            this.reportName = reportName;
            this.reportReason = reportReason;
            this.reportResult = reportResult;
            this.reportTime = reportTime;
        }

        //增加//更新
        public Report(int userID, int postID, int ruleID, string reportName, string reportReason, string reportResult, string reportTime)
        {
            this.reportID = reportID;
            this.userID = userID;
            this.postID = postID;
            this.ruleID = ruleID;
            this.reportName = reportName;
            this.reportReason = reportReason;
            this.reportResult = reportResult;
            this.reportTime = reportTime;
        }
        //查询//删除
        public Report(int reportID, int userID, int postID, int ruleID, string reportName, string reportReason, string reportResult, string reportTime)
        {
            this.reportID = reportID;
            this.userID = userID;
            this.postID = postID;
            this.ruleID = ruleID;
            this.reportName = reportName;
            this.reportReason = reportReason;
            this.reportResult = reportResult;
            this.reportTime = reportTime;
        }
    }
}
