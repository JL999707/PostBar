using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL
{
    public class PictureBll
    {
        DAL.PictureDao dao = new DAL.PictureDao();

        //增加
        public OperationResult picLinkAdd(Picture pic)
        {
            Picture temp = dao.Query(pic.picName);
            if (temp == null)
            {
                return OperationResult.exist;
            }
            else
            {
                int rowCount = dao.Add(pic);
                if (rowCount == 1)
                {
                    return OperationResult.success;
                }
                return OperationResult.failure;
            }
        }

        //更新
        public bool Update(Picture picLink)
        {
            int rowCount = dao.Update(picLink);
            return rowCount == 1 ? true : false;
        }

        //删除
        public bool deletPic(string picName)
        {
            Picture temp = dao.Query(picName);
            if (temp == null)
            {
                return false;
            }
            else
            {
                int rowCount = dao.Delete(picName);
                if (rowCount == 1)
                {
                    return true;
                }
                return false;
            }
        }

        //检索单个所有信息
        public Model.Picture checkAllPic(string picName)
        {
            Model.Picture checkAllPic = dao.Query(picName);

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
        public List<Picture> likeCheckPic(string picName, bool isAccurate)
        {
            return dao.Query(picName, isAccurate);
        }
    }
}
