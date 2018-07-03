using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    BLL.PostBll mgr = new BLL.PostBll();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string userName = null;
            bool isAccurate = false;
            List<Model.Post> postList = mgr.checkPostDesc(userName, isAccurate);
            this.GridView1.DataSource = postList;
            this.GridView1.DataBind();

            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                Button barName = (Button)GridView1.Rows[i].FindControl("barName");
                Model.Bar getBarName = mgr.getBarName(Convert.ToInt32(barName.Text));
                barName.Text = getBarName.barName.ToString();

                Label postAuthor = (Label)GridView1.Rows[i].FindControl("postAuthor");
                Model.UserInfo getUserName = mgr.getUserName(Convert.ToInt32(postAuthor.Text));
                postAuthor.Text = getUserName.userName.ToString();
            }

            if (this.Session["userName"] != null)
            {
                this.userName.Text = this.Session["userName"].ToString();
            }
        }
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
        Response.Redirect("Bar.aspx");
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