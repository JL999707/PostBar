using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL
{
    public class NoticeBll
    {
        DAL.NoticeDao dao = new DAL.NoticeDao();


        //增加
        public OperationResult noticeAdd(Notice notice)
        {
            Notice temp = dao.Query(notice.noticeName);
            if (temp == null)
            {
                return OperationResult.exist;
            }
            else
            {
                int rowCount = dao.Add(notice);
                if (rowCount == 1)
                {
                    return OperationResult.success;
                }
                return OperationResult.failure;
            }
        }

        //更新
        public bool Update(Notice notice)
        {
            int rowCount = dao.Update(notice);
            return rowCount == 1 ? true : false;
        }

        //删除
        public bool deletNotice(string notiTitle)
        {
            Notice temp = dao.Query(notiTitle);
            if (temp == null)
            {
                return false;
            }
            else
            {
                int rowCount = dao.Delete(notiTitle);
                if (rowCount == 1)
                {
                    return true;
                }
                return false;
            }
        }

        //检索单个所有信息
        public Model.Notice checkAllNotice(string notiTitle)
        {
            Model.Notice checkAllNotice = dao.Query(notiTitle);

            //不需要访问数据源，直接执行业务逻辑
            if (checkAllNotice != null)
            {
                return checkAllNotice;
            }
            else
            {
                return checkAllNotice;
            }
        }

        //模糊查询
        public List<Notice> CheckLikeNotice(string notiTitle, bool isAccurate)
        {
            return dao.Query(notiTitle, isAccurate);
        }
    }
}
