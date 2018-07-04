using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PostBll
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
        //检索单个所有信息
        public Model.Post userIDheckAllPost(string postName)
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
        public List<Model.Post> likeCheckPost(string postName, bool isAccurate)
        {
            return dao.Query(postName, isAccurate);
        }
        //模糊查询
        public List<Model.Post> userIDlikeCheckPost(int userID, bool isAccurate)
        {
            return dao.userIDQuery(userID, isAccurate);
        }
        //根据postName查询某项符合某记录的数量
        public int checkCountPostName(string postName)
        {
            int checkCountPostName = dao.checkCountPostName(postName);
            return checkCountPostName;
        }

        //根据postID得到postName
        public Model.Post getPostName(int postID)
        {
            Model.Post getPostName = dao.getPostName(postID);
            //int getUserID1 = Convert.ToInt32(getUserID);
            //不需要访问数据源，直接执行业务逻辑
            if (getPostName != null)
            {
                return getPostName;
            }
            else
            {
                return getPostName;
            }
        }
        //根据postName得到postID
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
        //根据postID得到userID
        public Model.Post getPostUserID(int postID)
        {
            Model.Post getUserID = dao.getPostUserID(postID);
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

        //根据贴吧IDbarID得到贴吧名字
        public Model.Bar getBarName(int barID)
        {
            Model.Bar getBarName = dao.getBarName(barID);
            //int getUserID1 = Convert.ToInt32(getUserID);
            //不需要访问数据源，直接执行业务逻辑
            if (getBarName != null)
            {
                return getBarName;
            }
            else
            {
                return getBarName;
            }
        }
        //根据用户名称userName得到用户ID，userID
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

        //根据用户ID得到用户Name
        public Model.UserInfo getUserName(int userID)
        {
            Model.UserInfo getUserName = dao.getUserName(userID);
            //int getUserID1 = Convert.ToInt32(getUserID);
            //不需要访问数据源，直接执行业务逻辑
            if (getUserName != null)
            {
                return getUserName;
            }
            else
            {
                return getUserName;
            }
        }
        //根据barID查询某项符合某记录的数量
        public int checkCountBarID(int barID)
        {
            int checkCountID = dao.checkCountBarID(barID);
            return checkCountID;
        }
        //根据userID查询某项符合某记录的数量
        public int checkCountUserID(int userID)
        {
            int checkCountUserID = dao.checkCountUserID(userID);
            return checkCountUserID;
        }

        //查询最近添加的记录
        public List<Model.Post> checkPostDesc(string postName, bool isAccurate)
        {
            return dao.getDesc(postName, isAccurate);
        }
        //根据barID查询最近添加的记录
        public List<Model.Post> checkBarIDDesc(int barID, bool isAccurate)
        {
            return dao.getBarIDesc(barID, isAccurate);
        }
    }
}
