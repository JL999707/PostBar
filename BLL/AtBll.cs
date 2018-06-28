using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL
{
    public class AtBll
    {
        DAL.AtDao dao = new DAL.AtDao();//oooooooo

        //增加
        public OperationResult atAdd(At at)
        {
            At temp = dao.Query(at.beAtUserID);
            if (temp == null)
            {
                return OperationResult.exist;
            }
            else
            {
                int rowCount = dao.Add(at);
                if (rowCount == 1)
                {
                    return OperationResult.success;
                }
                return OperationResult.failure;
            }
        }

        //更新
        public bool Update(At at)
        {
            int rowCount = dao.Update(at);
            return rowCount == 1 ? true : false;
        }

        //删除
        public bool deletAt(int T_BeAtUserID)
        {
            At temp = dao.Query(T_BeAtUserID);
            if (temp == null)
            {
                return false;
            }
            else
            {
                int rowCount = dao.Delete(T_BeAtUserID);
                if (rowCount == 1)
                {
                    return true;
                }
                return false;
            }
        }

        //检索单个所有信息        //获取AT表的信息
        public Model.At checkAllAt(int T_BeAtUserID)
        {
            Model.At checkAllAt = dao.Query(T_BeAtUserID);

            //不需要访问数据源，直接执行业务逻辑
            if (checkAllAt != null)
            {
                return checkAllAt;
            }
            else
            {
                return checkAllAt;
            }
        }

        //模糊查询
        public List<At> likeCheckAt(int T_BeAtUserID, bool isAccurate)
        {
            return dao.Query(T_BeAtUserID, isAccurate);
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

        //根据回复名称ReplyName得到回复ID，replyID
        public Model.Reply getReplyID(string replyName)
        {
            Model.Reply getReplyID = dao.getReplyID(replyName);
            //int getUserID1 = Convert.ToInt32(getUserID);
            //不需要访问数据源，直接执行业务逻辑
            if (getReplyID != null)
            {
                return getReplyID;
            }
            else
            {
                return getReplyID;
            }
        }

        //根据被at者ID查询某项符合某记录的数量
        public int checkCountBeAtUserID(int beAtUserID)
        {
            int checkCountBeAtUserID = dao.checkCountBeAtUserID(beAtUserID);
            return checkCountBeAtUserID;
        }

    }
}
