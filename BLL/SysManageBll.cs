using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL
{
    class SysManageBll
    {
        DAL.SysManageDao dao = new DAL.SysManageDao();


        //增加
        public OperationResult barAttAdd(SysManage sysMana)
        {
            SysManage temp = dao.QuerySysManaID(sysMana.sysManaID);
            if (temp == null)
            {
                return OperationResult.exist;
            }
            else
            {
                int rowCount = dao.Add(sysMana);
                if (rowCount == 1)
                {
                    return OperationResult.success;
                }
                return OperationResult.failure;
            }
        }

        //更新基本信息
        public bool Update(SysManage sysMana)
        {
            int rowCount = dao.Update(sysMana);
            return rowCount == 1 ? true : false;
        }

        //删除
        public bool deletBarAtt(int sysManaID)
        {
            SysManage temp = dao.QuerySysManaID(sysManaID);
            if (temp == null)
            {
                return false;
            }
            else
            {
                int rowCount = dao.Delete(sysManaID);
                if (rowCount == 1)
                {
                    return true;
                }
                return false;
            }
        }
        //模糊查询
        public List<SysManage> likeCheckBarAtt(int sysManaID, bool isAccurate)
        {
            return dao.Query(sysManaID, isAccurate);
        }
        //根据系统管理ID检索单个所有信息
        public Model.SysManage checkAllManaID(int sysManaID)
        {
            Model.SysManage checkAllManaID = dao.QuerySysManaID(sysManaID);

            //不需要访问数据源，直接执行业务逻辑
            if (checkAllManaID != null)
            {
                return checkAllManaID;
            }
            else
            {
                return checkAllManaID;
            }
        }
        //根据rotID检索单个所有信息
        public Model.SysManage checkAllRotID(int rotID)
        {
            Model.SysManage checkAllRotID = dao.QueryRotID(rotID);

            //不需要访问数据源，直接执行业务逻辑
            if (checkAllRotID != null)
            {
                return checkAllRotID;
            }
            else
            {
                return checkAllRotID;
            }
        }
        //根据noticeID检索单个所有信息
        public Model.SysManage checkAllNoticeID(int noticeID)
        {
            Model.SysManage checkAllNoticeID = dao.QueryNoticeID(noticeID);

            //不需要访问数据源，直接执行业务逻辑
            if (checkAllNoticeID != null)
            {
                return checkAllNoticeID;
            }
            else
            {
                return checkAllNoticeID;
            }
        }
        //根据baTypeID检索单个所有信息
        public Model.SysManage checkAllBarTypeID(int baTypeID)
        {
            Model.SysManage checkAllBarTypeID = dao.QueryBarTypeID(baTypeID);

            //不需要访问数据源，直接执行业务逻辑
            if (checkAllBarTypeID != null)
            {
                return checkAllBarTypeID;
            }
            else
            {
                return checkAllBarTypeID;
            }
        }

        //根据用轮播名称得到轮播ID,rotID
        public Model.Rotation getRotID(string rotName)
        {
            Model.Rotation getRotID = dao.getRotID(rotName);
            //int getUserID1 = Convert.ToInt32(getUserID);
            //不需要访问数据源，直接执行业务逻辑
            if (getRotID != null)
            {
                return getRotID;
            }
            else
            {
                return getRotID;
            }
        }
        //根据公告名称得到公告ID,noticeID
        public Model.Notice getNoticeID(string noticeName)
        {
            Model.Notice getNoticeID = dao.getNoticeID(noticeName);
            //int getUserID1 = Convert.ToInt32(getUserID);
            //不需要访问数据源，直接执行业务逻辑
            if (getNoticeID != null)
            {
                return getNoticeID;
            }
            else
            {
                return getNoticeID;
            }
        }
        //根据贴吧类型名称得到贴吧类型ID,barTypeID
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


        //根据rotID查询某项符合某记录的数量
        public int checkCountRotID(int rotID)
        {
            int checkCountRotID = dao.checkCountRotID(rotID);
            return checkCountRotID;
        }
        //根据noticeID查询某项符合某记录的数量
        public int checkCountNoticeID(int noticeID)
        {
            int checkCountNoticeID = dao.checkCountNoticeID(noticeID);
            return checkCountNoticeID;
        }
        //根据barTypeID查询某项符合某记录的数量
        public int checkCountBarTypeID(int barTypeID)
        {
            int checkCountBarTypeID = dao.checkCountBarTypeID(barTypeID);
            return checkCountBarTypeID;
        }
    }
}
