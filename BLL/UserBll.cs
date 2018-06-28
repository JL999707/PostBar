using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL
{
    public class UserBll
    {
        DAL.UserDAO dao = new DAL.UserDAO();

        //用户登录判断
        public UserInfo userLogin(UserInfo user)
        {
            UserInfo temp = dao.checkAllUser(user.userName);
            if (temp != null && temp.pwd == user.pwd)
            {
                return temp;
            }
            return null;
        }

        //增加用户、用户注册
        public OperationResult userRegist(UserInfo user)
        {
            UserInfo temp = dao.checkAllUser(user.userName);
            if (temp == null)
            {
                return OperationResult.exist;
            }
            else
            {
                int rowCount = dao.Add(user);
                if (rowCount == 1)
                {
                    return OperationResult.success;
                }
                return OperationResult.failure;
            }
        }

        //更新用户基本信息
        public bool Update(UserInfo user)
        {
            int rowCount = dao.Update(user);
            return rowCount == 1 ? true : false;
        }

        //删除用户
        public bool deletUser(string userName)
        {
            UserInfo temp = dao.checkAllUser(userName);
            if (temp == null)
            {
                return false;
            }
            else
            {
                int rowCount = dao.Delete(userName);
                if (rowCount == 1)
                {
                    return true;
                }
                return false;
            }
        }

        //检索单个用户所有信息
        public Model.UserInfo checkAllUser(string userName)
        {
            DAL.UserDAO uDao = new DAL.UserDAO();   //实例化DAL层
            Model.UserInfo checkAllUser = uDao.checkAllUser(userName);

            //不需要访问数据源，直接执行业务逻辑
            if (checkAllUser != null)
            {
                return checkAllUser;
            }
            else
            {
                return checkAllUser;
            }
        }

        //用户模糊查询
        public List<UserInfo> likeCheckUsers(string userName, bool isAccurate)
        {
            return dao.Query(userName, isAccurate);
        }

        //重置用户密码
        public bool ResetPwd(UserInfo user)
        {
            //user.pwd = "123456";
            //return dao.Update(user) == 1 ? true : false;
            UserInfo temp = dao.checkAllUser(user.userName);
            if (temp == null)
            {
                return false;
            }
            else
            {
                user.pwd = "123456";
                if (dao.Update(user) == 1)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
