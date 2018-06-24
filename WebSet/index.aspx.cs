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

}