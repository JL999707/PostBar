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
        public bool deletBarAtt(string barAttName)
        {
            BarAttention temp = dao.Query(barAttName);
            if (temp == null)
            {
                return false;
            }
            else
            {
                int rowCount = dao.Delete(barAttName);
                if (rowCount == 1)
                {
                    return true;
                }
                return false;
            }
        }
        //模糊查询
        public List<BarAttention> CheckBarAtt(string barAttTitle, bool isAccurate)
        {
            return dao.Query(barAttTitle, isAccurate);
        }
        //根据贴吧名称检索单个所有信息
        public Model.BarAttention checkAllBarAtt1(string barAttName)
        {
            Model.BarAttention checkAllBarAtt1 = dao.QueryBarAttName(barAttName);

            //不需要访问数据源，直接执行业务逻辑
            if (checkAllBarAtt1 != null)
            {
                return checkAllBarAtt1;
            }
            else
            {
                return checkAllBarAtt1;
            }
        }
        //根据userID检索单个所有信息
        public Model.BarAttention checkAllBarAtt2(int userID)
        {
            Model.BarAttention checkAllBarAtt2 = dao.QueryUserID(userID);

            //不需要访问数据源，直接执行业务逻辑
            if (checkAllBarAtt2 != null)
            {
                return checkAllBarAtt2;
            }
            else
            {
                return checkAllBarAtt2;
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
        //根据贴吧名称查询某项符合某记录的数量
        public int checkCountName(string barAttName)
        {
            int checkCountName = dao.checkCountName(barAttName);
            return checkCountName;
        }
        //根据userID查询某项符合某记录的数量
        public int checkCountID(int userID)
        {
            int checkCountID = dao.checkCountID(userID);
            return checkCountID;
        }
    }
}
