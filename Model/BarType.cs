using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BarType
    {
        public int barTypeID { get; set; }
        public string barTypeName { get; set; }

        public BarType() { }

        //更新
        //增加
        //删除
        public BarType(int barTypeID)
        {
            this.barTypeID = barTypeID;
        }

        //更新
        //增加
        //删除
        public BarType(string barTypeName)
        {
            this.barTypeID = barTypeID;
            this.barTypeName = barTypeName;
        }

        //查询
        public BarType(int barTypeID, string barTypeName)
        {
            this.barTypeID = barTypeID;
            this.barTypeName = barTypeName;
        }
    }
}
