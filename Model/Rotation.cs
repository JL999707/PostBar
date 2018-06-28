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

        //贡献出自己的自增ID给其他引用自己主键的表使用
        public Rotation(int rotID)
        {
            this.rotID = rotID;
        }

        //删除//查询 
        public Rotation(string rotName)
        {
            this.rotID = rotID;
            this.rotName = rotName;
            this.rotImg = rotImg;
        }

        //增加//更新
        public Rotation(string rotName, string rotImg)
        {
            this.rotID = rotID;
            this.rotName = rotName;
            this.rotImg = rotImg;
        }

        //查询//删除
        public Rotation(int rotID, string rotName, string rotImg)
        {
            this.rotID = rotID;
            this.rotName = rotName;
            this.rotImg = rotImg;
        }

    }
}
