using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SysManage
    {
        public int sysManaID{get;set;}
        public int rotID { get; set; }
        public int noticeID { get; set; }
        public int barTypeID{ get; set; }

        public SysManage(){ }
        public SysManage(int sysManaID)
        {
            this.sysManaID = sysManaID;
        }

        public SysManage(int rotID,int noticeID,int barTypeID)
        {
            this.rotID = rotID;
            this.noticeID = noticeID;
            this.barTypeID = barTypeID;
        }

        public SysManage(int sysManaID,int rotID, int noticeID, int barTypeID)
        {
            this.sysManaID = sysManaID;
            this.rotID = rotID;
            this.noticeID = noticeID;
            this.barTypeID = barTypeID;
        }
    }
}
