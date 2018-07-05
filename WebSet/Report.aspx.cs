using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    { 
        this.beReportName.Text = this.Session["userName"].ToString();
        this.replyContent.Text = this.Session["postContent"].ToString();
        this.replyTime.Text = this.Session["postTime"].ToString();
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Label1.Text = "个人/企业举报 > ";
        this.Label2.Text = this.RadioButtonList1.SelectedValue.ToString();
    }

    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Label1.Text = "垃圾举报 > ";
        this.Label2.Text = this.RadioButtonList2.SelectedValue.ToString();
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {

        Response.Write("<script>alert('由于本公司法律顾问最近脑阔有点问题，所以，举报功能暂时不能更进一步，谢谢您的谅解！')</script>");
        Response.Flush();
    }
}