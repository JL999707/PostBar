using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BarAttention
    {
        public int barAttID { get; set; }
        public int userID { get; set; }
        public int barID { get; set; }
        public string barAttName { get; set; }
        public string barAttTime { get; set; }
        public BarAttention() { }

        //删除,关注的用户进行删除
        public BarAttention(string barAttName)
        {
            this.barAttName = barAttName;
        }
        //删除,被关注的贴吧进行删除
        public BarAttention(int userID)
        {
            this.userID = userID;
        }

        //增加
        public BarAttention(int userID, int barID, string barAttName, string barAttTime)
        {
            this.barAttID = barAttID;
            this.userID = userID;
            this.barID = barID;
            this.barAttName = barAttName;
            this.barAttTime = barAttTime;
        }

        //更新
        public BarAttention(int userID, int barID, string barAttName)
        {
            this.barAttID = barAttID;
            this.userID = userID;
            this.barID = barID;
            this.barAttName = barAttName;
            this.barAttTime = barAttTime;
        }


        //查询
        public BarAttention(int barAttID, int userID, int barID, string barAttName, string barAttTime)
        {
            this.barAttID = barAttID;
            this.userID = userID;
            this.barID = barID;
            this.barAttName = barAttName;
            this.barAttTime = barAttTime;
        }
    }
}
