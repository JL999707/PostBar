using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PostCollectionBll
    {
        DAL.PostCollectionDao dao = new DAL.PostCollectionDao();

        //增加
        public OperationResult postCollAdd(Model.PostCollection postColl)
        {
            Model.PostCollection temp = dao.QueryCollName(postColl.collName);
            if (temp == null)
            {
                return OperationResult.exist;
            }
            else
            {
                int rowCount = dao.Add(postColl);
                if (rowCount == 1)
                {
                    return OperationResult.success;
                }
                return OperationResult.failure;
            }
        }

        //更新
        public bool Update(Model.PostCollection postColl)
        {
            int rowCount = dao.Update(postColl);
            return rowCount == 1 ? true : false;
        }

        //删除
        public bool deletPostColl(string postCollName)
        {
            Model.PostCollection temp = dao.QueryCollName(postCollName);
            if (temp == null)
            {
                return false;
            }
            else
            {
                int rowCount = dao.Delete(postCollName);
                if (rowCount == 1)
                {
                    return true;
                }
                return false;
            }
        }

        //检索单个所有信息
        public Model.PostCollection checkAllPostColl(string postCollName)
        {
            Model.PostCollection checkAllPostColl = dao.QueryCollName(postCollName);

            //不需要访问数据源，直接执行业务逻辑
            if (checkAllPostColl != null)
            {
                return checkAllPostColl;
            }
            else
            {
                return checkAllPostColl;
            }
        }

        //模糊查询
        public List<Model.PostCollection> likeCheckPostColl(string postCollName, bool isAccurate)
        {
            return dao.Query(postCollName, isAccurate);
        }
        //根据贴吧名称检索单个所有信息
        public Model.PostCollection checkAllPostColl1(string collName)
        {
            Model.PostCollection checkAllPostColl1 = dao.QueryCollName(collName);

            //不需要访问数据源，直接执行业务逻辑
            if (checkAllPostColl1 != null)
            {
                return checkAllPostColl1;
            }
            else
            {
                return checkAllPostColl1;
            }
        }
        //根据userID检索单个所有信息
        public Model.PostCollection checkAllPostColl2(int userID)
        {
            Model.PostCollection checkAllPostColl2 = dao.QueryUserID(userID);

            //不需要访问数据源，直接执行业务逻辑
            if (checkAllPostColl2 != null)
            {
                return checkAllPostColl2;
            }
            else
            {
                return checkAllPostColl2;
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
