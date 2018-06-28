using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BarManage
    {
        public int barManaID { get; set; }
        public int postID { get; set; }
        public int userID { get; set; }
        public string manaType { get; set; }
        public string manaTime{get;set;}

        public BarManage(int barManaID)
        {
            this.barManaID = barManaID;
        }

        public BarManage(){}

        //public BarManage(int userID)
        //{
        //    this.userID = userID;
        //}
        public BarManage(string manaType)
        {
            this.manaType = manaType;//类型有
        }
        public BarManage(int postID, int userID, string manaType,string manaTime)
        {
            this.postID = postID;
            this.userID = userID;
            this.manaType = manaType;
            this.manaTime = manaTime;
        }
        public BarManage(int barManaID,int postID, int userID, string manaType, string manaTime)
        {
            this.barManaID = barManaID;
            this.postID = postID;
            this.userID = userID;
            this.manaType = manaType;
            this.manaTime = manaTime;
        }
    }
}
