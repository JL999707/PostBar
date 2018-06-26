using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserInfo
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public string pwd { get; set; }
        public string userSex { get; set; }
        public string userContactInfo { get; set; }
        public string userTime { get; set; }
        public string autoGraph { get; set; }
        public string userHeadImg { get; set; }
        public string userTopImg { get; set; }
        public string userBGImg { get; set; }

        public UserInfo() { }

        //根据用户用户姓名获得用户ID
        public UserInfo(int userID)
        {
            this.userID = userID;
        }

        //修改密码
        public UserInfo(string pwd)
        {
            this.pwd = pwd;
        }
        //登录
        public UserInfo(string userName, string pwd)
        {
            this.userName = userName;
            this.pwd = pwd;
        }

        //注册基本信息
        public UserInfo(string userName, string pwd, string userSex, string userTime, string userContactInfo, string autoGraph, string userHeadImg, string userTopImg, string userBGImg)
        {
            this.userName = userName;
            this.pwd = pwd;
            this.userSex = userSex;
            this.autoGraph = autoGraph;
            this.userContactInfo = userContactInfo;
            this.userTime = userTime;
            this.userHeadImg = userHeadImg;
            this.userTopImg = userTopImg;
            this.userBGImg = userBGImg;
        }

        //修改、更新用户基本信息,图片
        public UserInfo(string userName, string pwd, string userContactInfo, string autoGraph, string userHeadImg, string userTopImg, string userBGImg)
        {
            this.userName = userName;
            this.pwd = pwd;
            this.autoGraph = autoGraph;
            this.userContactInfo = userContactInfo;
            this.userHeadImg = userHeadImg;
            this.userTopImg = userTopImg;
            this.userBGImg = userBGImg;
        }

        //查询全部
        public UserInfo(int userID, string userName, string pwd, string userSex, string userContactInfo, string userTime, string autoGraph, string userHeadImg, string userTopImg, string userBGImg)
        {
            this.userID = userID;
            this.userName = userName;
            this.pwd = pwd;
            this.userSex = userSex;
            this.userContactInfo = userContactInfo;
            this.userTime = userTime;
            this.autoGraph = autoGraph;
            this.userHeadImg = userHeadImg;
            this.userTopImg = userTopImg;
            this.userBGImg = userBGImg;
        }
    }
}
