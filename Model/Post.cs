using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Post
    {
        public int postID { get; set; }
        public int barID { get; set; }
        public string postName { get; set; }
        public string postContent { get; set; }
        public string postTime { get; set; }
        public string judge { get; set; }
        public string postAutoGraph { get; set; }
        public string postHeadImg { get; set; }
        public string postTopImg { get; set; }
        public string postBGImg { get; set; }

        public Post() { }
        public Post(int postID)
        {
            this.postID = postID;
        }

        //增加
        public Post(int barID, string postName, string postContent, string postTime, string judge, string postAutoGraph, string postHeadImg, string postTopImg, string postBGImg)
        {
            this.postID = postID;
            this.barID = barID;
            this.postName = postName;
            this.postContent = postContent;
            this.postTime = postTime;
            this.judge = judge;
            this.postAutoGraph = postAutoGraph;
            this.postHeadImg = postHeadImg;
            this.postTopImg = postTopImg;
            this.postBGImg = postBGImg;
        }

        //删除
        public Post(string postName)
        {
            this.postName = postName;
        }

        //更新
        public Post(int barID, string postName, string postContent, string judge, string postAutoGraph, string postHeadImg, string postTopImg, string postBGImg)
        {
            this.barID = barID;
            this.postName = postName;
            this.postContent = postContent;
            this.judge = judge;
            this.postAutoGraph = postAutoGraph;
            this.postHeadImg = postHeadImg;
            this.postTopImg = postTopImg;
            this.postBGImg = postBGImg;
        }

        //查询
        public Post(int postID, int barID, string postName, string postContent, string postTime, string judge, string postAutoGraph, string postHeadImg, string postTopImg, string postBGImg)
        {
            this.postID = postID;
            this.barID = barID;
            this.postName = postName;
            this.postContent = postContent;
            this.postTime = postTime;
            this.judge = judge;
            this.postAutoGraph = postAutoGraph;
            this.postHeadImg = postHeadImg;
            this.postTopImg = postTopImg;
            this.postBGImg = postBGImg;
        }
    }
}
