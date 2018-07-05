using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
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
    //int reValue;
    protected void Page_Load(object sender, EventArgs e)
    {

        UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
    }

    protected void btnZhuCe_Click(object sender, EventArgs e)
    {

        try
        {

            BLL.UserBll bll = new BLL.UserBll();
            string name = this.userName.Text.Trim();
            string sex = this.Sex.Value;
            string pwd = this.UserPassWord.Text.Trim();
            string repwd = this.RePassWord.Text.Trim();
            string time = DateTime.Now.ToLongDateString().ToString();
            string telNum = this.telNum.Text;
            string graph = "签名";
            string headimg = "0";
            string topimg = "0";
            string bgimg = "0";
            string email = this.Email.Text.Trim();
            string MD5pwd = GetMD5(pwd);
            string MD5repwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "MD5");

            UserInfo user = new UserInfo(name, MD5pwd, sex, time, telNum, graph, headimg, topimg, bgimg);
            OperationResult userRegist = bll.userRegist(user);
            if (this.TextBox1.Text.Trim() == Session["chkCode"].ToString())
            {
                if (userRegist.ToString() == "success")
                {
                    Response.Redirect("Main.aspx");
                }
                else if (userRegist.ToString() == "failure")
                {
                    Response.Write("<script>alert('failure')</script>");
                }
                else
                {
                    Response.Write("<script>alert('用户已存在')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('验证码输入错误');</script>");
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
       protected void lnkbtnCheck_Click(object sender, EventArgs e)
    {
    }

    protected void login_Click(object sender, EventArgs e)
    {
        Response.Redirect("Main.aspx");
    }
}