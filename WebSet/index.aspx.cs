using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using DAL;

public partial class index : System.Web.UI.Page
{
    UserBll bll = new UserBll();
    UserDAO dao = new UserDAO();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //增加、注册
    protected void regist_Click(object sender, EventArgs e)
    {
        UserInfo user = new UserInfo(this.registName.Text.Trim(), this.registPwd.Text.Trim(), this.radio.SelectedValue, this.txtRegistTIme.Text.Trim(), this.registContact.Text.Trim(),
                                   this.registAutoGraph.Text.Trim(), this.txtRegistHeadPho.Text.Trim(), this.txtRegistTopImg.Text.Trim(), this.txtRegistBGIng.Text.Trim());
        OperationResult userRegist = bll.userRegist(user);

        if (userRegist.ToString() == "success")
        {
            tishi.Text = "注册成功";
        }
        else if (userRegist.ToString() == "failure")
        {
            tishi.Text = "注册失败";
        }
        else if (userRegist.ToString() == "exist")
        {
            tishi.Text = "该用户已存在";
        }

    }
    //更新
    protected void btnUp_Click(object sender, EventArgs e)
    {
        UserInfo user = new UserInfo(this.upName.Text.Trim(), this.txtUpPwd.Text.Trim(), this.txtUpContact.Text.Trim(), this.txtUpAutoGraph.Text.Trim(),
                                   this.txtUpUserHeadImg.Text.Trim(), this.txtUpUserTopImg.Text.Trim(), this.txtUpUserBGImg.Text.Trim());
        if (bll.Update(user) == true)
        {
            tishi.Text = " 更新成功";
        }
        else
        {
            tishi.Text = " 更新失败";
        }
    }
    //删除
    protected void btnDelet_Click(object sender, EventArgs e)
    {
        string userName = this.txtDelet.Text.Trim();
        if (bll.deletUser(userName) == true)
        {
            tishi.Text = "删除成功";
        }
        else
        {
            tishi.Text = "删除失败";
        }
    }
    //检索单条记录的所有信息
    protected void check_Click(object sender, EventArgs e)
    {
        string userName = txtcheck.Text.Trim();
        BLL.UserBll mgr = new BLL.UserBll();
        Model.UserInfo checkAllUser = mgr.checkAllUser(userName);

        if (checkAllUser != null)
        {
            this.tishi.Text = checkAllUser.userID.ToString() + checkAllUser.userName + checkAllUser.pwd + checkAllUser.userSex + checkAllUser.autoGraph + checkAllUser.userContactInfo + checkAllUser.userHeadImg + checkAllUser.userTopImg + checkAllUser.userBGImg;
        }
        else
        {
            this.tishi.Text = "查找不到";
        }
    }
    //模糊搜索
    protected void likeCheck_Click(object sender, EventArgs e)
    {
        string userName = txtLike.Text.Trim();
        bool isAccurate = false;
        BLL.UserBll mgr = new BLL.UserBll();
        List<UserInfo> userList = mgr.CheckUsers(userName, isAccurate);
        if (userList != null && isAccurate == false)
        {
            this.GridView2.DataSource = userList;
            this.GridView2.DataBind();
        }
        else
        {
            this.tishi.Text = "查找不到";
        }
    }
    //登陆验证
    protected void Button1_Click(object sender, EventArgs e)
    {
        //UI层将用户输入数据传递给BLL层
        UserInfo user = new UserInfo(this.txtName.Text, this.txtPwd.Text);
        user = bll.userLogin(user);
        if (user == null)
        {
            tishi.Text = "用户名或密码错误";
        }
        else
        {
            tishi.Text = user.userName;
        }
    }
    //重置密码
    protected void btnResetPwd_Click(object sender, EventArgs e)
    {
        UserInfo user = new UserInfo(this.txtResetName.Text.Trim(), this.txtResetPwd.Text.Trim(), this.txtUpContact.Text.Trim(), this.txtUpAutoGraph.Text.Trim(),
                                     this.txtUpUserHeadImg.Text.Trim(), this.txtUpUserTopImg.Text.Trim(), this.txtUpUserBGImg.Text.Trim());
        if (bll.ResetPwd(user))
        {
            labRestPwd.Text = "重置成功" + user.pwd;
        }
        else
        {
            labRestPwd.Text = "重置失败";

        }
    }

    //At表
    //根据用户姓名得到用户ID并且获取到该用户在At表里面的所有信息
    protected void btnGetUserID_Click(object sender, EventArgs e)
    {
        string userName = txtGetUserID.Text.Trim();
        BLL.AtBll mgr = new BLL.AtBll();
        Model.UserInfo getUserID = mgr.getUserID(userName);

        if (getUserID != null)
        {
            this.lbGetUserID.Text = getUserID.userID.ToString();
        }
        else
        {
            this.lbGetUserID.Text = "查找不到";
        }

        Model.At checkAllAt = mgr.checkAllAt(getUserID.userID);

        if (checkAllAt != null)
        {
            this.labIDTiShi.Text = checkAllAt.atID.ToString()+ checkAllAt.replyID.ToString()+ checkAllAt.atUserID.ToString()+ checkAllAt.beAtUserID.ToString()+ checkAllAt.atContent+ checkAllAt.atTime;
        }
        else
        {
            this.labIDTiShi.Text = "查找不到";
        }
    }

    //bar表
    //

    //barAtt表
    //根据barNAme
    protected void btnByBarName_Click(object sender, EventArgs e)
    {
        string barName = this.txtByBarName.Text.Trim();
        BLL.BarAttBll mgr = new BLL.BarAttBll();
        Model.BarAttention checkAllBarAtt1 = mgr.checkAllBarAtt1(barName);

        if (checkAllBarAtt1 != null)
        {
            this.labBarAtt.Text = checkAllBarAtt1.barAttName+ checkAllBarAtt1.barAttID+ checkAllBarAtt1.barID+ checkAllBarAtt1.userID+ checkAllBarAtt1.barAttTime;
        }
        else
        {
            this.labBarAtt.Text = "查找不到";
        }
    }
    //根据userID
    protected void btnByUserID_Click(object sender, EventArgs e)
    {
        int userID = Convert.ToInt32(this.txtByUserID.Text.Trim());
        BLL.BarAttBll mgr = new BLL.BarAttBll();
        Model.BarAttention checkAllBarAtt2 = mgr.checkAllBarAtt2(userID);

        if (checkAllBarAtt2 != null)
        {
            this.labBarAtt.Text = checkAllBarAtt2.userID.ToString()+ checkAllBarAtt2.barAttID + checkAllBarAtt2.barID + checkAllBarAtt2.barAttName+ checkAllBarAtt2.barAttTime;
        }
        else
        {
            this.labBarAtt.Text = "查找不到";
        }
    }
    //根据贴吧名称查询某项符合某记录的数量
    protected void btnBarAttCountName_Click(object sender, EventArgs e)
    {
        string name = this.txtBarAttCountName.Text.Trim();
        BLL.BarAttBll mgr = new BLL.BarAttBll();
        int checkCountName = mgr.checkCountName(name);
        this.labBarAttCount.Text = checkCountName.ToString();
    }
    //根据userID查询某项符合某记录的数量
    protected void btnBarAttCountID_Click(object sender, EventArgs e)
    {
        string userName = this.txtBarAttCountID.Text.Trim();
        BLL.BarAttBll mgr = new BLL.BarAttBll();
        Model.UserInfo getUserID = mgr.getUserID(userName);
        int checkCountID = mgr.checkCountID(getUserID.userID);
        this.labBarAttCount.Text = checkCountID.ToString();
    }

    //barType表
    //精确查询
    protected void btnBarType_Click(object sender, EventArgs e)
    {
        string barTypeName = this.txtBarType.Text.Trim();
        BLL.BarTypeBll mgr = new BLL.BarTypeBll();
        Model.BarType checkAllBarType = mgr.checkAllBarType(barTypeName);

        if (checkAllBarType != null)
        {
            this.labBarType.Text = Convert.ToInt32(checkAllBarType.barTypeID)+ checkAllBarType.barTypeName;
        }
        else
        {
            this.labBarType.Text = "查找不到";
        }
    }
    //模糊查询
    protected void btnCheckLike_Click(object sender, EventArgs e)
    {
        string barTypeName =txtBarType.Text.Trim();
        bool isAccurate = false;
        BLL.BarTypeBll mgr = new BLL.BarTypeBll();
        List<BarType> barTypeList = mgr.CheckLikeBarType(barTypeName, isAccurate);
        if (barTypeList != null && isAccurate == false)
        {
            this.GridView2.DataSource = barTypeList;
            this.GridView2.DataBind();
        }
        else
        {
            this.labBarType.Text = "查找不到";
        }
    }

    //notice表
    //精确查询
    protected void btntxtNotice_Click(object sender, EventArgs e)
    {
        string noticeName = this.txtNotice.Text.Trim();
        BLL.NoticeBll mgr = new BLL.NoticeBll();
        Model.Notice checkAllNotice = mgr.checkAllNotice(noticeName);

        if (checkAllNotice != null)
        {
            this.labNotice.Text = Convert.ToInt32(checkAllNotice.noticeID) + checkAllNotice.noticeName+ checkAllNotice.noticeTime;
        }
        else
        {
            this.labNotice.Text = "查找不到";
        }
    }
    //模糊查询
    protected void txtNoticeLikeCheck_Click(object sender, EventArgs e)
    {
        string noticeName = this.txtNotice.Text.Trim();
        bool isAccurate = false;
        BLL.NoticeBll mgr = new BLL.NoticeBll();
        List<Notice> noticeList = mgr.CheckLikeNotice(noticeName, isAccurate);
        if (noticeList != null && isAccurate == false)
        {
            this.GridView2.DataSource = noticeList;
            this.GridView2.DataBind();
        }
        else
        {
            this.labNotice.Text = "查找不到";
        }
    }
    //picture表
    //
    //post表
    //
    //postCollection表
    //
    //privateLetter表
    //
    //reply表
    //
    //report表
    //
    //rotation表
    //
    //rule表
    //
    //userAtt表
    //





}