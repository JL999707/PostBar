using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PostCollection
    {
        public int collID { get; set; }
        public int userID { get; set; }
        public int postID { get; set; }
        public string collName { get; set; }
        public string collTime { get; set; }

        public PostCollection() { }

        //增加
        public PostCollection(int userID, int postID, string collName, string collTime)
        {
            this.userID = userID;
            this.postID = postID;
            this.collName = collName;
            this.collTime = collTime;
        }

        //删除,收藏的用户进行删除
        public PostCollection(int userID)
        {
            this.userID = userID;
        }

        //删除,被收藏的帖子进行删除
        public PostCollection(string collName)
        {
            this.collName = collName;
        }

        //更新
        public PostCollection(int userID, int postID, string collTime)
        {
            this.userID = userID;
            this.collName = collName;
            this.collTime = collTime;
        }

        //查询
        public PostCollection(int collID, int userID, int postID, string collName, string collTime)
        {
            this.collID = collID;
            this.userID = userID;
            this.postID = postID;
            this.collName = collName;
            this.collTime = collTime;
        }
    }
}
