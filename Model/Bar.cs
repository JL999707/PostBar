using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Bar
    {
        public int barID { get; set; }
        public int barTypeID { get; set; }
        public int userID { get; set; }
        public string barName { get; set; }
        public string barTime { get; set; }
        public string barAutoGraph { get; set; }
        public string barHeadImg { get; set; }
        public string barTopImg { get; set; }
        public string barBGImg { get; set; }

        public Bar() { }

        public Bar(int barID)
        {
            this.barID = barID;
        }

        //增加
        public Bar(int barTypeID, int userID, string barName, string barTime, string barAutoGraph, string barHeadImg, string barTopImg, string barBGImg)
        {
            this.barID = barID;
            this.barTypeID = barTypeID;
            this.userID = userID;
            this.barTime = barTime;
            this.barName = barName;
            this.barAutoGraph = barAutoGraph;
            this.barHeadImg = barHeadImg;
            this.barTopImg = barTopImg;
            this.barBGImg = barBGImg;
        }

        //删除
        public Bar(string barName)
        {
            this.barName = barName;
        }

        //更新
        public Bar(int barTypeID, int userID, string barName, string barAutoGraph, string barHeadImg, string barTopImg, string barBGImg)
        {
            this.barTypeID = barTypeID;
            this.userID = userID;
            this.barName = barName;
            this.barAutoGraph = barAutoGraph;
            this.barHeadImg = barHeadImg;
            this.barTopImg = barTopImg;
            this.barBGImg = barBGImg;
        }

        //查询
        public Bar(int barID, int barTypeID, int userID, string barName, string barTime, string barAutoGraph, string barHeadImg, string barTopImg, string barBGImg)
        {
            this.barID = barID;
            this.barTypeID = barTypeID;
            this.userID = userID;
            this.barTime = barTime;
            this.barName = barName;
            this.barAutoGraph = barAutoGraph;
            this.barHeadImg = barHeadImg;
            this.barTopImg = barTopImg;
            this.barBGImg = barBGImg;
        }
    }
}
