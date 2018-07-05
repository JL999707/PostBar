using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewBar : System.Web.UI.Page
{
    BLL.BarBll barBll = new BLL.BarBll();
    BLL.BarTypeBll barTypeBll = new BLL.BarTypeBll();
    BLL.UserBll userBll = new BLL.UserBll();
    protected void Page_Load(object sender, EventArgs e)
    {
        UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

        if (this.Session["userName"] != null)
        {
            this.UserName.Text = this.Session["userName"].ToString();
            this.barName.Text = this.Session["newBarName"].ToString();
        }
    }

    protected void btnZhuCe_Click(object sender, EventArgs e)
    {
        Model.BarType bartype = barTypeBll.checkAllBarType(this.DropDownList1.SelectedValue.ToString());
        Model.UserInfo user = userBll.checkAllUser(this.UserName.Text);

        int barTypeID = bartype.barTypeID;
        int userID = user.userID;
        string barName = this.barName.Text;
        string barTime = DateTime.Now.ToLocalTime().ToString();
        string barAutoGraph = "0";
        string barHeadImg = "0";
        string barTopImg = "0";
        string barBGImg = "0";

        Model.Bar bar = new Bar(barTypeID, userID,barName, barTime, barAutoGraph, barHeadImg, barTopImg, barBGImg);
        OperationResult barAdd = barBll.barAdd(bar);
        if (this.chkCode.Text.Trim() == Session["chkCode"].ToString())
        {
            if (barAdd.ToString() == "success")
            {
                Response.Write("<script>alert('创建成功！')</script>");
                this.Session["barName"] = this.barName.Text;
                Response.Redirect("Bar.aspx");
            }
            else if (barAdd.ToString() == "failure")
            {
                Response.Write("<script>alert('failure')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('验证码输入错误');</script>");
        }
    }
}