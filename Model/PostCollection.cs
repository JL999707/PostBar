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
