using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL
{
    public class RotationBll
    {
        DAL.RotationDao dao = new DAL.RotationDao();

        //增加
        public OperationResult rotateAdd(Rotation rotate)
        {
            Rotation temp = dao.Query(rotate.rotName);
            if (temp == null)
            {
                return OperationResult.exist;
            }
            else
            {
                int rowCount = dao.Add(rotate);
                if (rowCount == 1)
                {
                    return OperationResult.success;
                }
                return OperationResult.failure;
            }
        }

        //更新
        public bool Update(Rotation rotate)
        {
            int rowCount = dao.Update(rotate);
            return rowCount == 1 ? true : false;
        }

        //删除
        public bool deletRotate(string rotTitle)
        {
            Rotation temp = dao.Query(rotTitle);
            if (temp == null)
            {
                return false;
            }
            else
            {
                int rowCount = dao.Delete(rotTitle);
                if (rowCount == 1)
                {
                    return true;
                }
                return false;
            }
        }

        //检索单个所有信息
        public Model.Rotation checkAllRotate(string rotTitle)
        {
            Model.Rotation checkAllRotate = dao.Query(rotTitle);

            //不需要访问数据源，直接执行业务逻辑
            if (checkAllRotate != null)
            {
                return checkAllRotate;
            }
            else
            {
                return checkAllRotate;
            }
        }

        //模糊查询
        public List<Rotation> CheckRotate(string rotTitle, bool isAccurate)
        {
            return dao.Query(rotTitle, isAccurate);
        }
    }
}
