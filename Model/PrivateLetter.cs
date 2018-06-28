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

        //增加
        public PrivateLetter(int privUserID, int bePrivUserID, string privName, string privTime)
        {
            this.privLetID = privLetID;
            this.privUserID = privUserID;
            this.bePrivUserID = bePrivUserID;
            this.privName = privName;
            this.privTime = privTime;
        }

        //删除,主动私信用户进行删除
        public PrivateLetter(int privUserID)
        {
            this.privUserID = privUserID;
        }

        //删除,被冻死新用户进行删除
        public PrivateLetter( string privName)
        {
            this.privName = privName;
        }
        //更新
        public PrivateLetter(int privUserID,string privName, string privTime)
        {
            this.privLetID = privLetID;
            this.privUserID = privUserID;
            this.bePrivUserID = bePrivUserID;
            this.privName = privName;
            this.privTime = privTime;
        }

        //查询
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
