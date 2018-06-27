﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PrivateLetterBll
    {
        DAL.PrivateLetterDao dao = new DAL.PrivateLetterDao();

        //增加
        public OperationResult privLetAdd(Model.PrivateLetter privLet)
        {
            Model.PrivateLetter temp = dao.Query(privLet.privName);
            if (temp == null)
            {
                return OperationResult.exist;
            }
            else
            {
                int rowCount = dao.Add(privLet);
                if (rowCount == 1)
                {
                    return OperationResult.success;
                }
                return OperationResult.failure;
            }
        }

        //更新
        public bool Update(Model.PrivateLetter privLet)
        {
            int rowCount = dao.Update(privLet);
            return rowCount == 1 ? true : false;
        }

        //删除
        public bool deletPrivLet(string privLetName)
        {
            Model.PrivateLetter temp = dao.Query(privLetName);
            if (temp == null)
            {
                return false;
            }
            else
            {
                int rowCount = dao.Delete(privLetName);
                if (rowCount == 1)
                {
                    return true;
                }
                return false;
            }
        }

        //检索单个所有信息
        public Model.PrivateLetter checkAllPrivLet(string privLetName)
        {
            Model.PrivateLetter checkAllPrivLet = dao.Query(privLetName);

            //不需要访问数据源，直接执行业务逻辑
            if (checkAllPrivLet != null)
            {
                return checkAllPrivLet;
            }
            else
            {
                return checkAllPrivLet;
            }
        }

        //模糊查询
        public List<Model.PrivateLetter> CheckLikePrivLet(string privLetName, bool isAccurate)
        {
            return dao.Query(privLetName, isAccurate);
        }
    }
}
