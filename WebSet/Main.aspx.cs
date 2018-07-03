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
        //Button barName = GridView1.Rows[0].FindControl("barName") as Button;
        //int row = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;

        //BLL.PostBll bll = new BLL.PostBll();
        //for (int i = 0;i < this.GridView1.Rows.Count;i++)
        //{
        //    Button barName = (Button)GridView1.Rows[i].FindControl("barName");
        //    Model.Bar getBarName = bll.getBarName(Convert.ToInt32(barName.Text));

        //    barName.Text = getBarName.ToString();
        //    //Response.Write("<script>alert(" + barName.Text + ")</script>");
        //}

        

    }

    protected void collection_Click(object sender, EventArgs e)
    {
        Response.Redirect("Own.aspx");
    }

    protected void barName_Click(object sender, EventArgs e)
    {
        int row = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
        Button barName = (Button)GridView1.Rows[row].FindControl("barName");

        if (this.Session["barName"] != null)
        {
            this.Session["barName"] = null;
            this.Session["barName"] = barName.Text;
        }
        else
        {
            this.Session["barName"] = barName.Text;
        }
        //Response.Redirect("Bar.aspx");
        BLL.PostBll bll = new BLL.PostBll();
        Model.Bar bar = bll.getBarName(Convert.ToInt32(barName.Text));

        //barName.Text = getBarName.ToString();
        Response.Write("<script>alert(" + bar.barID.ToString() + ")</script>");
    }

    protected void postName_Click(object sender, EventArgs e)
    {
        int row = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
        Button barName = (Button)GridView1.Rows[row].FindControl("barName");
        Button postName = (Button)GridView1.Rows[row].FindControl("postName");

        this.Session["barName"] = barName.Text;
        if (this.Session["postName"] != null)
        {
            this.Session["postName"] = null;
            this.Session["postName"] = postName.Text;
        }
        else
        {
            this.Session["postName"] = postName.Text;
        }
        Response.Redirect("BarContent.aspx");
    }
}