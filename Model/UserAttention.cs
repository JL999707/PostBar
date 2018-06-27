using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserAttention
    {
        public int userAttID { get; set; }
        public int userID { get; set; }
        public int beUserID { get; set; }
        public string userAttName { get; set; }
        public string userAttTime { get; set; }

        public UserAttention() { }


        public UserAttention(int userAttID, int userID, int beUserID, string userAttName, string userAttTime)
        {
            this.userAttID = userAttID;
            this.userID = userID;
            this.beUserID = beUserID;
            this.userAttName = userAttName;
            this.userAttTime = userAttTime;
        }
    }
}
