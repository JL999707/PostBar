using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class At
    {
        public int atID { get; set; }
        public int atUserID { get; set; }
        public int beAtUserID { get; set; }
        public int replyID { get; set; }
        public string atContent { get; set; }
        public string atTime { get; set; }
        public At() { }
        public At(int beAtUserID)
        {
            this.beAtUserID = beAtUserID;
        }

        //增加
        public At(int atUserID, int beAtUserID, int replyID, string atContent, string atTime)
        {
            this.atUserID = atUserID;
            this.replyID = replyID;
            this.beAtUserID = beAtUserID;
            this.atContent = atContent;
            this.atTime = atTime;
        }

        //删除
        public At(string atContent)
        {
            this.atUserID = atUserID;
            this.replyID = replyID;
            this.beAtUserID = beAtUserID;
            this.atContent = atContent;
        }
        //删除

        public At(int replyID, string atContent, string atTime)
        {
            this.atUserID = atUserID;
            this.replyID = replyID;
            this.beAtUserID = beAtUserID;
            this.atContent = atContent;
            this.atTime = atTime;
        }

        //查询
        public At(int atID, int atUserID,  int beAtUserID, int replyID, string atContent, string atTime)
        {
            this.atID = atID;
            this.atUserID = atUserID;
            this.replyID = replyID;
            this.beAtUserID = beAtUserID;
            this.atContent = atContent;
            this.atTime = atTime;
        }
        //更新



    }
}
