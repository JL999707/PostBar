using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Picture
    {
        public int picID { get; set; }
        public int postID { get; set; }
        public string picName{ get; set; }
        public string picAddr { get; set; }
        public string picTime { get; set; }

        public Picture() { }

        public Picture(int picID, int postID, string picName, string picAddr, string picTime)
        { 
            this.picID = picID;
            this.postID = postID;
            this.picName = picName;
            this.picAddr = picAddr;
            this.picTime = picTime;
        }
    }
}
