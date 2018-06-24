using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Reply
    {
        public int replyID { get; set; }
        public int userID { get; set; }
        public int postID { get; set; }
        public string replyName { get; set; }
        public string replyContent { get; set; }
        public string replyTime { get; set; }

        public Reply() { }

        public Reply(int replyID, int userID, int postID, string replyName, string replyContent, string replyTime)
        {
            this.replyID = replyID;
            this.userID = userID;
            this.postID = postID;
            this.replyName = replyName;
            this.replyContent = replyContent;
            this.replyTime = replyTime;
        }
    }
}
