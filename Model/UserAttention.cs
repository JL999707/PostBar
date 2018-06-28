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


        //删除根据主动关注的用户ID//查询
        public UserAttention(int userID)
        {
            this.userID = userID;
        }

        //删除根据被关注的用户的名字//查询
        public UserAttention(string userAttName)
        {
            this.userAttName = userAttName;
        }

        //更新
        public UserAttention(int userID, int beUserID, string userAttName)
        {
            this.userID = userID;
            this.beUserID = beUserID;
            this.userAttName = userAttName;
        }

        //增加
        public UserAttention(int userID, int beUserID, string userAttName, string userAttTime)
        {
            this.userID = userID;
            this.beUserID = beUserID;
            this.userAttName = userAttName;
            this.userAttTime = userAttTime;
        }
        // 查询全部//删除
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
