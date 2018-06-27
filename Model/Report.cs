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
        public Report(int reportID)
        {
            this.reportID = reportID;
        }
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
