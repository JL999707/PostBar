using BLL;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Head : System.Web.UI.MasterPage
{
    public string GetMD5(string strPwd)
    {
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] data = System.Text.Encoding.Default.GetBytes(strPwd);
        byte[] md5data = md5.ComputeHash(data);
        md5.Clear();
        string str = "";
        for (int i = 0; i < md5data.Length - 1; i++)
        {
            str += md5data[i].ToString("x").PadLeft(2, '0');
        }
        return str;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (this.Session["userName"] != null)
            {
                this.Login_link.Text = this.Session["userName"].ToString();
            }
        }
    }

    protected void check_Click(object sender, EventArgs e)
    {
        string search = this.textCheck.Text;
        BLL.BarBll bll = new BarBll();
        Model.Bar result = bll.checkAllBar(search);
        if (result != null && result.barID != 0)
        {
            this.Session["barName"] = search;
            Response.Redirect("Bar.aspx");
        }
        else
        {
            Response.Write("<script>alert('无此吧！请创建新吧！')</script>");
            this.Session["newBarName"] = this.textCheck.Text;
            Response.Redirect("NewBar.aspx");
        }
    }

    protected void likeCheck_Click(object sender, EventArgs e)
    {
        string search = this.textCheck.Text;
        BLL.BarBll bll = new BarBll();
        Model.Bar result = bll.checkAllBar(search);
        if (result != null && result.barID != 0)
        {
            this.Session["barName"] = search;
            Response.Redirect("Search.aspx");
        }
        else
        {
            Response.Write("<script>alert('无相关内容')</script>");
        }
    }

    protected void Login_btn_Click(object sender, EventArgs e)
    {
        string MD5pwd = GetMD5(this.pwd_txt.Text);
        BLL.UserBll bll = new UserBll();
        UserInfo user = new UserInfo(this.userName_txt.Text, MD5pwd);
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
            this.Session["userName"] = this.userName_txt.Text;
            this.zheZhao.Style["display"] = "none";
            this.main.Style["display"] = "none";
            this.Login_link.Text = this.Session["userName"].ToString();
            Response.AddHeader("Refresh", "0");
        }
    }

    protected void registerOn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }
}