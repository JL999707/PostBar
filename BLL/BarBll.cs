using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL
{
    public class BarBll
    {
        DAL.BarDao dao = new DAL.BarDao();

        //增加
        public OperationResult barAdd(Bar bar)
        {
            Bar temp = dao.Query(bar.barName);
            if (temp == null)
            {
                return OperationResult.exist;
            }
            else
            {
                int rowCount = dao.Add(bar);
                if (rowCount == 1)
                {
                    return OperationResult.success;
                }
                return OperationResult.failure;
            }
        }

        //更新
        public bool Update(Bar bar)
        {
            int rowCount = dao.Update(bar);
            return rowCount == 1 ? true : false;
        }

        //删除
        public bool deletBar(string barName)
        {
            Bar temp = dao.Query(barName);
            if (temp == null)
            {
                return false;
            }
            else
            {
                int rowCount = dao.Delete(barName);
                if (rowCount == 1)
                {
                    return true;
                }
                return false;
            }
        }

        //检索单个所有信息
        public Model.Bar checkAllBar(string barName)
        {
            Model.Bar checkAllBar = dao.Query(barName);

            //不需要访问数据源，直接执行业务逻辑
            if (checkAllBar != null)
            {
                return checkAllBar;
            }
            else
            {
                return checkAllBar;
            }
        }

        //模糊查询
        public List<Bar> CheckBar(string userName, bool isAccurate)
        {
            return dao.Query(userName, isAccurate);
        }
    }
}
