using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Notice
    {
        public int noticeID { get; set; }
        public string noticeName { get; set; }
        public string noticeContent { get; set; }
        public string noticeTime { get; set; }

        public Notice() { }

        public Notice(int noticeID, string noticeName, string noticeContent, string noticeTime)
        {
            this.noticeID = noticeID;
            this.noticeName = noticeName;
            this.noticeContent = noticeContent;
            this.noticeTime = noticeTime;
        }
    }
}
