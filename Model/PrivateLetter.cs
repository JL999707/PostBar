using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PrivateLetter
    {
        public int privLetID { get; set; }
        public int privUserID { get; set; }
        public int bePrivUserID { get; set; }
        public string privName { get; set; }
        public string privTime { get; set; }

        public PrivateLetter() { }

        public PrivateLetter(int privLetID, int privUserID, int bePrivUserID, string privName, string privTime)
        {
            this.privLetID = privLetID;
            this.privUserID = privUserID;
            this.bePrivUserID = bePrivUserID;
            this.privName = privName;
            this.privTime = privTime;
        }
    }
}
