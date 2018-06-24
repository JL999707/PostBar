using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Rotation
    {
        public int rotID { get; set; }
        public string rotName { get; set; }
        public string rotImg { get; set; }

        public Rotation() { }

        public Rotation(int rotID, string rotName, string rotImg)
        {
            this.rotID = rotID;
            this.rotName = rotName;
            this.rotImg = rotImg;
        }
    }
}
