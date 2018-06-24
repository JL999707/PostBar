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
        public bool deletReport(string reportTitle)
        {
            Report temp = dao.Query(reportTitle);
            if (temp == null)
            {
                return false;
            }
            else
            {
                int rowCount = dao.Delete(reportTitle);
                if (rowCount == 1)
                {
                    return true;
                }
                return false;
            }
        }

        //检索单个所有信息
        public Model.Report checkAllReport(string reportTitle)
        {
            Model.Report checkAllReport = dao.Query(reportTitle);

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
        public List<Report> CheckReport(string reportTitle, bool isAccurate)
        {
            return dao.Query(reportTitle, isAccurate);
        }
    }
}
