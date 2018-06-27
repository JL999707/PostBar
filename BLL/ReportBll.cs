using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL
{
    public class ReportBll
    {
        DAL.ReportDao dao = new DAL.ReportDao();

        //增加
        public OperationResult reportAdd(Report report)
        {
            Report temp = dao.Query(report.reportName);
            if (temp == null)
            {
                return OperationResult.exist;
            }
            else
            {
                int rowCount = dao.Add(report);
                if (rowCount == 1)
                {
                    return OperationResult.success;
                }
                return OperationResult.failure;
            }
        }

        //更新
        public bool Update(Report report)
        {
            int rowCount = dao.Update(report);
            return rowCount == 1 ? true : false;
        }

        //删除
        public bool deletReport(string reportName)
        {
            Report temp = dao.Query(reportName);
            if (temp == null)
            {
                return false;
            }
            else
            {
                int rowCount = dao.Delete(reportName);
                if (rowCount == 1)
                {
                    return true;
                }
                return false;
            }
        }

        //检索单个所有信息
        public Model.Report checkAllReport(string reportName)
        {
            Model.Report checkAllReport = dao.Query(reportName);

            //不需要访问数据源，直接执行业务逻辑
            if (checkAllReport != null)
            {
                return checkAllReport;
            }
            else
            {
                return checkAllReport;
            }
        }

        //模糊查询
        public List<Report> CheckReport(string reportName, bool isAccurate)
        {
            return dao.Query(reportName, isAccurate);
        }


        //根据userID检索单个所有信息
        public Model.Report checkAllReply1(int userID)
        {
            Model.Report checkAllReply1 = dao.QueryUser(userID);

            //不需要访问数据源，直接执行业务逻辑
            if (checkAllReply1 != null)
            {
                return checkAllReply1;
            }
            else
            {
                return checkAllReply1;
            }
        }
        //根据postID检索单个所有信息
        public Model.Report checkAllReply2(int postID)
        {
            Model.Report checkAllReply2 = dao.QueryPost(postID);

            //不需要访问数据源，直接执行业务逻辑
            if (checkAllReply2 != null)
            {
                return checkAllReply2;
            }
            else
            {
                return checkAllReply2;
            }
        }
        //根据ruleID检索单个所有信息
        public Model.Report checkAllReply3(int ruleID)
        {
            Model.Report checkAllReply3 = dao.QueryRule(ruleID);

            //不需要访问数据源，直接执行业务逻辑
            if (checkAllReply3 != null)
            {
                return checkAllReply3;
            }
            else
            {
                return checkAllReply3;
            }
        }
        //根据用户姓名得到用户ID,userID
        public Model.UserInfo getUserID(string userName)
        {
            Model.UserInfo getUserID = dao.getUserID(userName);
            //int getUserID1 = Convert.ToInt32(getUserID);
            //不需要访问数据源，直接执行业务逻辑
            if (getUserID != null)
            {
                return getUserID;
            }
            else
            {
                return getUserID;
            }
        }
        //根据帖子名称得到贴子ID,postID
        public Model.Post getPostID(string postName)
        {
            Model.Post getPostID = dao.getPostID(postName);
            //int getUserID1 = Convert.ToInt32(getUserID);
            //不需要访问数据源，直接执行业务逻辑
            if (getPostID != null)
            {
                return getPostID;
            }
            else
            {
                return getPostID;
            }
        }
        //根据帖子名称得到贴子ID,postID
        public Model.Rule getRuleID(string ruleItem)
        {
            Model.Rule getRuleID = dao.getRuleID(ruleItem);
            //int getUserID1 = Convert.ToInt32(getUserID);
            //不需要访问数据源，直接执行业务逻辑
            if (getRuleID != null)
            {
                return getRuleID;
            }
            else
            {
                return getRuleID;
            }
        }
        //根据userID查询某项符合某记录的数量
        public int checkCountUserID(int userID)
        {
            int checkCountUserID = dao.checkCountUserID(userID);
            return checkCountUserID;
        }
        //根据postID查询某项符合某记录的数量
        public int checkCountPostID(int postID)
        {
            int checkCountPostID = dao.checkCountPostID(postID);
            return checkCountPostID;
        }
        //根据ruleID查询某项符合某记录的数量
        public int checkCountRuleID(int ruleID)
        {
            int checkCountRuleID = dao.checkCountRuleID(ruleID);
            return checkCountRuleID;
        }
    }
}
