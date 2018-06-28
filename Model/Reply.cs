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

        //贡献出自己的自增ID给其他引用自己主键的表使用//查询
        public Reply(int replyID)
        {
            this.replyID = replyID;
        }

        //增加
        public Reply(int userID, int postID, string replyName, string replyContent, string replyTime)
        {
            this.replyID = replyID;
            this.userID = userID;
            this.postID = postID;
            this.replyName = replyName;
            this.replyContent = replyContent;
            this.replyTime = replyTime;
        }

        //删除,用户删除自己的消息
        public Reply(int userID, int postID)
        {
            this.userID = userID;
            this.postID = postID;
        }
        //查询
        public Reply(int replyID, int userID, int postID, string replyName, string replyContent, string replyTime)
        {
            this.replyID = replyID;
            this.userID = userID;
            this.postID = postID;
            this.replyName = replyName;
            this.replyContent = replyContent;
            this.replyTime = replyTime;
        }
        //更新,回复表更新不了的
    }
}
