using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL
{
    public class BarBll
    {
        DAL.BarDao dao = new DAL.BarDao();

        //增加
        public OperationResult barAdd(Bar bar)
        {
            Bar temp = dao.Query(bar.barName);
            if (temp == null)
            {
                return OperationResult.exist;
            }
            else
            {
                int rowCount = dao.Add(bar);
                if (rowCount == 1)
                {
                    return OperationResult.success;
                }
                return OperationResult.failure;
            }
        }

        //更新
        public bool Update(Bar bar)
        {
            int rowCount = dao.Update(bar);
            return rowCount == 1 ? true : false;
        }

        //删除
        public bool deletBar(string barName)
        {
            Bar temp = dao.Query(barName);
            if (temp == null)
            {
                return false;
            }
            else
            {
                int rowCount = dao.Delete(barName);
                if (rowCount == 1)
                {
                    return true;
                }
                return false;
            }
        }

        //检索单个所有信息
        public Model.Bar checkAllBar(string barName)
        {
            Model.Bar checkAllBar = dao.Query(barName);

            //不需要访问数据源，直接执行业务逻辑
            if (checkAllBar != null)
            {
                return checkAllBar;
            }
            else
            {
                return checkAllBar;
            }
        }

        //模糊查询
        public List<Bar> CheckBar(string userName, bool isAccurate)
        {
            return dao.Query(userName, isAccurate);
        }

        //根据userID检索单个所有信息
        public Model.Bar checkAllReply1(int userID)
        {
            Model.Bar checkAllReply1 = dao.Query(userID);

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
        //根据barTypeID检索单个所有信息
        public Model.Bar checkAllReply2(int barTypeID, bool isAccurate = true)
        {
            Model.Bar checkAllReply2 = dao.Query(barTypeID, isAccurate);

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
        //根据贴吧类型名称得到贴吧类型ID
        public Model.BarType getBarTypeID(string barTypeName)
        {
            Model.BarType getBarTypeID = dao.getBarTypeID(barTypeName);
            //int getUserID1 = Convert.ToInt32(getUserID);
            //不需要访问数据源，直接执行业务逻辑
            if (getBarTypeID != null)
            {
                return getBarTypeID;
            }
            else
            {
                return getBarTypeID;
            }
        }
        //根据userID查询某项符合某记录的数量
        public int checkCountUserID(int userID)
        {
            int checkCountUserID = dao.checkCountUserID(userID);
            return checkCountUserID;
        }
        //根据barTypeID查询某项符合某记录的数量
        public int checkCountPostID(int barTypeID)
        {
            int checkCountBarTypeID = dao.checkCountBarTypeID(barTypeID);
            return checkCountBarTypeID;
        }



    }
}
