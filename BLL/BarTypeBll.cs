using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL
{
    public class BarTypeBll
    {
        DAL.BarTypeDao dao = new DAL.BarTypeDao();

        //增加
        public OperationResult barTypeAdd(BarType barType)
        {
            BarType temp = dao.Query(barType.barTypeName);
            if (temp == null)
            {
                return OperationResult.exist;
            }
            else
            {
                int rowCount = dao.Add(barType);
                if (rowCount == 1)
                {
                    return OperationResult.success;
                }
                return OperationResult.failure;
            }
        }

        //更新
        public bool Update(BarType barType)
        {
            int rowCount = dao.Update(barType);
            return rowCount == 1 ? true : false;
        }

        //删除
        public bool deletBarType(string barTypeName)
        {
            BarType temp = dao.Query(barTypeName);
            if (temp == null)
            {
                return false;
            }
            else
            {
                int rowCount = dao.Delete(barTypeName);
                if (rowCount == 1)
                {
                    return true;
                }
                return false;
            }
        }

        //检索单个所有信息
        public Model.BarType checkAllBarType(string barTypeName)
        {
            Model.BarType checkAllBarType = dao.Query(barTypeName);

            //不需要访问数据源，直接执行业务逻辑
            if (checkAllBarType != null)
            {
                return checkAllBarType;
            }
            else
            {
                return checkAllBarType;
            }
        }

        //模糊查询
        public List<BarType> likeCheckBarType(string barTypeName, bool isAccurate)
        {
            return dao.Query(barTypeName, isAccurate);
        }
    }
}
