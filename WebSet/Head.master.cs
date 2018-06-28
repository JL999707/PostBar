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
    UserBll bll = new UserBll();
    UserDAO dao = new UserDAO();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void check_Click(object sender, EventArgs e)
    {

    }

    protected void likeCheck_Click(object sender, EventArgs e)
    {

    }

    protected void Login_btn_Click(object sender, EventArgs e)
    {
        UserInfo user = new UserInfo(this.userName_txt.Text, this.pwd_txt.Text);
        user = bll.userLogin(user);
        if (user == null)
        {
            Response.Write("用户名或密码错误");
        }
        else
        {
            this.Session["userName"] = this.userName_txt.Text;
            this.Login_link.Text = this.Session["userName"].ToString();
        }
        
    }
}
