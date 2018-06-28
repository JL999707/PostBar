using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Picture
    {
        public int picID { get; set; }
        public int postID { get; set; }
        public string picName{ get; set; }
        public string picAddr { get; set; }
        public string picTime { get; set; }

        public Picture() { }
        public Picture(int picID)
        {
            this.picID = picID;
        }

        //增加
        public Picture(int postID, string picName, string picAddr, string picTime)
        {
            this.picID = picID;
            this.postID = postID;
            this.picName = picName;
            this.picAddr = picAddr;
            this.picTime = picTime;
        }

        //删除
        public Picture(string picName)
        {
            this.picID = picID;
            this.postID = postID;
            this.picName = picName;
            this.picAddr = picAddr;
            this.picTime = picTime;
        }

        //更新
        public Picture(string picName, string picAddr)
        {
            this.picName = picName;
            this.picAddr = picAddr;
        }

        //查询
        public Picture(int picID, int postID, string picName, string picAddr, string picTime)
        { 
            this.picID = picID;
            this.postID = postID;
            this.picName = picName;
            this.picAddr = picAddr;
            this.picTime = picTime;
        }
    }
}
