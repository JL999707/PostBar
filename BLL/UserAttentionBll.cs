using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL
{
    public class UserAttentionBll
    {
        DAL.UserAttentionDao dao = new DAL.UserAttentionDao();

        //增加
        public OperationResult userAttAdd(UserAttention userAtt)
        {
            UserAttention temp = dao.Query(userAtt.userAttName);
            if (temp == null)
            {
                return OperationResult.exist;
            }
            else
            {
                int rowCount = dao.Add(userAtt);
                if (rowCount == 1)
                {
                    return OperationResult.success;
                }
                return OperationResult.failure;
            }
        }

        //更新
        public bool Update(UserAttention userAtt)
        {
            int rowCount = dao.Update(userAtt);
            return rowCount == 1 ? true : false;
        }

        //删除
        public bool deletUserAtt(string userAttTitle)
        {
            UserAttention temp = dao.Query(userAttTitle);
            if (temp == null)
            {
                return false;
            }
            else
            {
                int rowCount = dao.Delete(userAttTitle);
                if (rowCount == 1)
                {
                    return true;
                }
                return false;
            }
        }

        //模糊查询
        public List<UserAttention> CheckUserAtt(string userAttTitle, bool isAccurate)
        {
            return dao.Query(userAttTitle, isAccurate);
        }
        //检索单个所有信息
        public Model.UserAttention checkAllUserAtt(string userAttTitle)
        {
            Model.UserAttention checkAllUserAtt = dao.Query(userAttTitle);

            //不需要访问数据源，直接执行业务逻辑
            if (checkAllUserAtt != null)
            {
                return checkAllUserAtt;
            }
            else
            {
                return checkAllUserAtt;
            }
        }

        //根据被关注者名称检索单个所有信息
        public Model.UserAttention checkAllUserAtt1(string userAttName)
        {
            Model.UserAttention checkAllUserAtt1 = dao.Query(userAttName);

            //不需要访问数据源，直接执行业务逻辑
            if (checkAllUserAtt1 != null)
            {
                return checkAllUserAtt1;
            }
            else
            {
                return checkAllUserAtt1;
            }
        }
        //根据关注者ID，userID检索单个所有信息
        public Model.UserAttention checkAllUserAtt2(int userID)
        {
            Model.UserAttention checkAllUserAtt2 = dao.Query(userID);

            //不需要访问数据源，直接执行业务逻辑
            if (checkAllUserAtt2 != null)
            {
                return checkAllUserAtt2;
            }
            else
            {
                return checkAllUserAtt2;
            }
        }
        //根据用户姓名得到用户ID
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
        public int checkCountName(string collName)
        {
            int checkCountName = dao.checkCountName(collName);
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
