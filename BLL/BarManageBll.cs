using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL
{
    class BarManageBll
    {
        DAL.BarManageDao dao = new DAL.BarManageDao();


        //增加
        public OperationResult barManaAdd(BarManage barMana)
        {
            BarManage temp = dao.QueryBarManaID(barMana.barManaID);
            if (temp == null)
            {
                return OperationResult.exist;
            }
            else
            {
                int rowCount = dao.Add(barMana);
                if (rowCount == 1)
                {
                    return OperationResult.success;
                }
                return OperationResult.failure;
            }
        }

        //更新基本信息
        public bool Update(BarManage barMana)
        {
            int rowCount = dao.Update(barMana);
            return rowCount == 1 ? true : false;
        }

        //删除
        public bool deletBarMana(int barManaID)
        {
            BarManage temp = dao.QueryBarManaID(barManaID);
            if (temp == null)
            {
                return false;
            }
            else
            {
                int rowCount = dao.Delete(barManaID);
                if (rowCount == 1)
                {
                    return true;
                }
                return false;
            }
        }
        //模糊查询
        public List<BarManage> likeCheckBarMana(int barManaID, bool isAccurate)
        {
            return dao.QueryBarManaID(barManaID, isAccurate);
        }

        //根据贴吧管理ID检索单个所有信息
        public Model.BarManage checkAllBarManaID(int barManaID)
        {
            Model.BarManage checkAllBarManaID = dao.QueryBarManaID(barManaID);

            //不需要访问数据源，直接执行业务逻辑
            if (checkAllBarManaID != null)
            {
                return checkAllBarManaID;
            }
            else
            {
                return checkAllBarManaID;
            }
        }
        //根据postID检索单个所有信息
        public Model.BarManage checkAllBarManapostID(int postID)
        {
            Model.BarManage checkAllBarManapostID = dao.QueryUser(postID);

            //不需要访问数据源，直接执行业务逻辑
            if (checkAllBarManapostID != null)
            {
                return checkAllBarManapostID;
            }
            else
            {
                return checkAllBarManapostID;
            }
        }
        //根据userID检索单个所有信息
        public Model.BarManage checkAllBarManauserID(int userID)
        {
            Model.BarManage checkAllBarManauserID = dao.QueryUser(userID);

            //不需要访问数据源，直接执行业务逻辑
            if (checkAllBarManauserID != null)
            {
                return checkAllBarManauserID;
            }
            else
            {
                return checkAllBarManauserID;
            }
        }
        //根据贴吧管理类型检索单个所有信息
        public Model.BarManage checkAllBarManaType(string manaType)
        {
            Model.BarManage checkAllBarManaType = dao.QueryManaType(manaType);

            //不需要访问数据源，直接执行业务逻辑
            if (checkAllBarManaType != null)
            {
                return checkAllBarManaType;
            }
            else
            {
                return checkAllBarManaType;
            }
        }
        //根据贴吧管理时间检索单个所有信息
        public Model.BarManage checkAllBarManaTime(string manaTime)
        {
            Model.BarManage checkAllBarManaTime = dao.QueryManaTime(manaTime);

            //不需要访问数据源，直接执行业务逻辑
            if (checkAllBarManaTime != null)
            {
                return checkAllBarManaTime;
            }
            else
            {
                return checkAllBarManaTime;
            }
        }

        //根据贴子名称得到贴子ID,postID
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

        //根据postID查询某项符合某记录的数量
        public int checkCountPostID(int postID)
        {
            int checkCountPostID = dao.checkCountPostID(postID);
            return checkCountPostID;
        }
        //根据userID查询某项符合某记录的数量
        public int checkCountUsreID(int userID)
        {
            int checkCountUsreID = dao.checkCountUserID(userID);
            return checkCountUsreID;
        }
        //根据贴吧管理类型查询某项符合某记录的数量
        public int checkCountManaType(string manaType)
        {
            int checkCountManaType = dao.checkCountManaType(manaType);
            return checkCountManaType;
        }
        //根据贴吧管理时间查询某项符合某记录的数量
        public int checkCountManaTime(string manaTime)
        {
            int checkCountManaTime = dao.checkCountManaTime(manaTime);
            return checkCountManaTime;
        }
    }
}
