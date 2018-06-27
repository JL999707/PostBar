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

        public BarAttention(string barAttName)
        {
            this.barAttName = barAttName;
        }
        public BarAttention(int userID)
        {
            this.userID = userID;
        }

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
