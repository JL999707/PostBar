using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Session["userName"] != null)
        {
            this.userName.Text = this.Session["userName"].ToString();
        }

        //for (int i = 1;i <= 10;i++)
        //{
        //    this.dynamic_hot.Controls.Add(TemplateControl.LoadControl("~/control/tabContent.ascx"));
        //}

        //Response.Write("<script>alert(" + dynamic_hot.Controls + ")</script>");

        BLL.PostBll bll = new BLL.PostBll(); 
    }

    protected void collection_Click(object sender, EventArgs e)
    {
        Response.Redirect("Own.aspx");
    }

    protected void barName_Click(object sender, EventArgs e)
    {
        
    }
}