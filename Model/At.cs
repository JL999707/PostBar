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

        public At(int atUserID,  int beAtUserID, int replyID, string atContent, string atTime)
        {
            this.atUserID = atUserID;
            this.replyID = replyID;
            this.beAtUserID = beAtUserID;
            this.atContent = atContent;
            this.atTime = atTime;
        }

        public At(int atID, int atUserID,  int beAtUserID, int replyID, string atContent, string atTime)
        {
            this.atID = atID;
            this.atUserID = atUserID;
            this.replyID = replyID;
            this.beAtUserID = beAtUserID;
            this.atContent = atContent;
            this.atTime = atTime;
        }
    }
}
