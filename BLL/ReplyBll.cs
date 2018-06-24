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
        public bool deletReply(string replyTitle)
        {
            Reply temp = dao.Query(replyTitle);
            if (temp == null)
            {
                return false;
            }
            else
            {
                int rowCount = dao.Delete(replyTitle);
                if (rowCount == 1)
                {
                    return true;
                }
                return false;
            }
        }

        //检索单个所有信息
        public Model.Reply checkAllReply(string replyTitle)
        {
            Model.Reply checkAllReply = dao.Query(replyTitle);

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
        public List<Reply> CheckReply(string replyTitle, bool isAccurate)
        {
            return dao.Query(replyTitle, isAccurate);
        }
    }
}
