using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL
{
    public class BarAttBll
    {
        DAL.BarAttentionDao dao = new DAL.BarAttentionDao();


        //增加
        public OperationResult barAttAdd(BarAttention barAtt)
        {
            BarAttention temp = dao.Query(barAtt.barAttName);
            if (temp == null)
            {
                return OperationResult.exist;
            }
            else
            {
                int rowCount = dao.Add(barAtt);
                if (rowCount == 1)
                {
                    return OperationResult.success;
                }
                return OperationResult.failure;
            }
        }

        //更新基本信息
        public bool Update(BarAttention barAtt)
        {
            int rowCount = dao.Update(barAtt);
            return rowCount == 1 ? true : false;
        }

        //删除
        public bool deletBarAtt(string barAttTitle)
        {
            BarAttention temp = dao.Query(barAttTitle);
            if (temp == null)
            {
                return false;
            }
            else
            {
                int rowCount = dao.Delete(barAttTitle);
                if (rowCount == 1)
                {
                    return true;
                }
                return false;
            }
        }

        //检索单个所有信息
        public Model.BarAttention checkAllBarAtt(string barAttTitle)
        {
            Model.BarAttention checkAllBarAtt = dao.Query(barAttTitle);

            //不需要访问数据源，直接执行业务逻辑
            if (checkAllBarAtt != null)
            {
                return checkAllBarAtt;
            }
            else
            {
                return checkAllBarAtt;
            }
        }

        //模糊查询
        public List<BarAttention> CheckBarAtt(string barAttTitle, bool isAccurate)
        {
            return dao.Query(barAttTitle, isAccurate);
        }
    }
}
