using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL
{
    public class ReplyBll
    {
        DAL.ReplyDao dao = new DAL.ReplyDao();

        //增加
        public OperationResult replyAdd(Reply reply)
        {
            Reply temp = dao.Query(reply.replyName);
            if (temp == null)
            {
                return OperationResult.exist;
            }
            else
            {
                int rowCount = dao.Add(reply);
                if (rowCount == 1)
                {
                    return OperationResult.success;
                }
                return OperationResult.failure;
            }
        }

        //更新
        public bool Update(Reply reply)
        {
            int rowCount = dao.Update(reply);
            return rowCount == 1 ? true : false;
        }

        //删除
        public bool deletReply(string replyName)
        {
            Reply temp = dao.Query(replyName);
            if (temp == null)
            {
                return false;
            }
            else
            {
                int rowCount = dao.Delete(replyName);
                if (rowCount == 1)
                {
                    return true;
                }
                return false;
            }
        }

        //检索单个所有信息
        public Model.Reply checkAllReply(string replyName)
        {
            Model.Reply checkAllReply = dao.Query(replyName);

            //不需要访问数据源，直接执行业务逻辑
            if (checkAllReply != null)
            {
                return checkAllReply;
            }
            else
            {
                return checkAllReply;
            }
        }

        //模糊查询
        public List<Reply> CheckReply(string replyName, bool isAccurate)
        {
            return dao.Query(replyName, isAccurate);
        }
        //根据userID检索单个所有信息
        public Model.Reply checkAllReply1(int userID)
        {
            Model.Reply checkAllReply1= dao.Query(userID);

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
        public Model.Reply checkAllReply2(int postID)
        {
            Model.Reply checkAllReply2 = dao.Query(postID);

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
    }
}
