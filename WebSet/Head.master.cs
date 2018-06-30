using BLL;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Head : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Session["userName"] != null)
        {
            this.Session["userName"] = null;
        }
    }

    protected void check_Click(object sender, EventArgs e)
    {

    }

    protected void likeCheck_Click(object sender, EventArgs e)
    {

    }

    protected void Login_btn_Click(object sender, EventArgs e)
    {
        if (this.Login_link.Text == "登录")
        {
            BLL.UserBll bll = new UserBll();
            UserInfo user = new UserInfo(this.userName_txt.Text, this.pwd_txt.Text);
            user = bll.userLogin(user);
            if (user == null)
            {
                this.zheZhao.Style["display"] = "block";
                this.main.Style["display"] = "block";
                this.userName_txt.Text = "";
                this.pwd_txt.Text = "";
                this.tishi.Text = "用户名或密码错误";
            }
            else
            {
                if (this.Session["userName"] != null)
                {
                    this.Session["userName"] = null;
                }
                else
                {
                    this.Session["userName"] = this.userName_txt.Text;
                }
                this.zheZhao.Style["display"] = "none";
                this.main.Style["display"] = "none";
                this.Login_link.Text = this.userName_txt.Text;
                this.userName_txt.Text = "";
                this.pwd_txt.Text = "";
            }
        }
        else
        {
            Response.Write(this.Login_link.Text);
        }
    }
}
