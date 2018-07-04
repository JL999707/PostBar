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



    //public SqlConnection GetCon()
    //{
    //    string myStr = ConfigurationManager.AppSettings["tb"].ToString();
    //    SqlConnection myConn = new SqlConnection(myStr);
    //    return myConn;
    //}
    //    public int sqlEx(string cmdstr)
    //    {

    //        SqlConnection conn = GetCon();//连接数据库
    //        conn.Open();//打开连接
    //        SqlCommand cmd = new SqlCommand(cmdstr, conn);
    //        cmd.ExecuteNonQuery();
    //        try
    //        {

    //            return 1;
    //        }
    //        catch (Exception e)
    //        {
    //            return 0;
    //        }
    //        finally
    //        {
    //            conn.Dispose();//释放连接对象资源
    //        }

    //    }
    //    public DataTable reDt(string cmdstr)
    //    {
    //        SqlConnection conn = GetCon();
    //        conn.Open();
    //        SqlDataAdapter da = new SqlDataAdapter(cmdstr, conn);
    //        DataSet ds = new DataSet();
    //        da.Fill(ds);
    //        return (ds.Tables[0]);

    //    }
    //    public int CheckName()
    //    {

    //        SqlConnection myconn = GetCon();
    //        myconn.Open();
    //        string str = "select  from [tb_User] where UserName ='" + this.UserName.Text + "'";


    //        try
    //        {
    //            DataTable dt = reDt(str);
    //            if (dt.Rows[0][0].ToString() != "0")
    //            {
    //                return -1;//该用户名已经存在
    //            }
    //            else
    //            {
    //                return 2;//该用户名尚未注册
    //            }
    //        }
    //        catch (Exception ee)
    //        {
    //            return 0;
    //        }

    //    }
    //    public string GetMD5(string strPwd)
    //    {
    //        MD5 md5 = new MD5CryptoServiceProvider();
    //        byte[] data = System.Text.Encoding.Default.GetBytes(strPwd);
    //        byte[] md5data = md5.ComputeHash(data);
    //        md5.Clear();
    //        string str = "";
    //        for (int i = 0; i < md5data.Length - 1; i++)
    //        {
    //            str += md5data[i].ToString("x").PadLeft(2, '0');
    //        }
    //        return str;
    //    }

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
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        

        
        
        

        //SqlConnection myConn = GetCon();
        //myConn.Open();
        //string cmdstr = "insert into tb_User(UserName ,UserPassWord ,Email) values('" + Name + "','" + MD5pwd + "','" + email + "')";
        //SqlCommand command = new SqlCommand();
        //command.Connection = myConn;
        //command.CommandText = cmdstr;

        //try
        //{
        //    reValue = sqlEx(cmdstr);
        //    if (reValue == 1)
        //    {
        //        Response.Write("<script>alert('注册成功！');location='登陆.aspx'</script>");

        //    }
        //    else if (reValue == 0)
        //    {
        //        Response.Write("<script>alert('注册失败');</script>");
        //    }
        //}

        //catch (Exception ee)
        //{
        //    Response.Write("<script>alert('该用户名已经存在');</script>");
        //}
    }

       protected void lnkbtnCheck_Click(object sender, EventArgs e)
       {
    //        //查找用户名是否存在，已经存在则返回-1，不存在返回2
    //        reValue = CheckName();
    //        if (reValue == -1)
    //        {
    //            Response.Write("<script>alert('用户名存在!');</script>");
    //            this.UserName.Focus();
    //        }
    //        else if (reValue == 2)
    //        {
    //            Response.Write("<script>alert('该用户尚未注册!');</script>");
    //            this.UserName.Focus();
        // }
       }

    protected void login_Click(object sender, EventArgs e)
    {
        Response.Redirect("Main.aspx");
    }
}