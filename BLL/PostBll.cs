using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class PostBll
    {
        DAL.PostDao dao = new DAL.PostDao();
        //增加
        public OperationResult postAdd(Model.Post post)
        {
            Model.Post temp = dao.Query(post.postName);
            if (temp == null)
            {
                return OperationResult.exist;
            }
            else
            {
                int rowCount = dao.Add(post);
                if (rowCount == 1)
                {
                    return OperationResult.success;
                }
                return OperationResult.failure;
            }
        }
        //更新
        public bool Update(Model.Post post)
        {
            int rowCount = dao.Update(post);
            return rowCount == 1 ? true : false;
        }
        //删除
        public bool deletPost(string postName)
        {
            Model.Post temp = dao.Query(postName);
            if (temp == null)
            {
                return false;
            }
            else
            {
                int rowCount = dao.Delete(postName);
                if (rowCount == 1)
                {
                    return true;
                }
                return false;
            }
        }
        //检索单个所有信息
        public Model.Post checkAllPost(string postName)
        {
            Model.Post checkAllPic = dao.Query(postName);

            //不需要访问数据源，直接执行业务逻辑
            if (checkAllPic != null)
            {
                return checkAllPic;
            }
            else
            {
                return checkAllPic;
            }
        }
        //模糊查询
        public List<Model.Post> CheckPost(string postName, bool isAccurate)
        {
            return dao.Query(postName, isAccurate);
        }
        //根据贴吧名称barName得到贴吧ID，barID
        public Model.Bar getBarID(string barName)
        {
            Model.Bar getBarID = dao.getBarID(barName);
            //int getUserID1 = Convert.ToInt32(getUserID);
            //不需要访问数据源，直接执行业务逻辑
            if (getBarID != null)
            {
                return getBarID;
            }
            else
            {
                return getBarID;
            }
        }
        //根据barID查询某项符合某记录的数量
        public int checkCountID(int barID)
        {
            int checkCountID = dao.checkCountID(barID);
            return checkCountID;
        }
    }
}
