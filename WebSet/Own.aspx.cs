using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    BLL.UserBll userBll = new BLL.UserBll();
    BLL.BarBll barBll = new BLL.BarBll();
    BLL.PostBll postBll = new BLL.PostBll();
    BLL.BarAttBll barAttBll = new BLL.BarAttBll();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.userName1.Text = this.Session["userName"].ToString();
            this.userName2.Text = this.Session["userName"].ToString();

            Model.UserInfo user = userBll.checkAllUser(this.userName1.Text);
            bool isAccurate = false;
            List<Model.Post> postList = postBll.userIDlikeCheckPost(user.userID,isAccurate);
            this.GridView1.DataSource = postList;
            this.GridView1.DataBind();
            this.GridView2.DataSource = postList;
            this.GridView2.DataBind();

            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                Button postName = (Button)GridView1.Rows[i].FindControl("postName");
                Model.Post post = postBll.checkAllPost(postName.Text);
                Model.UserInfo userName = userBll.getUserName(post.userID);
                Button postUserName = (Button)GridView1.Rows[i].FindControl("userName");
                postUserName.Text = userName.userName.ToString();
            }
            for (int i = 0; i < this.GridView2.Rows.Count; i++)
            {
                Button postName = (Button)GridView2.Rows[i].FindControl("postName");
                Model.Post post = postBll.checkAllPost(postName.Text);
                Model.UserInfo userName = userBll.getUserName(post.userID);
                Button postUserName = (Button)GridView2.Rows[i].FindControl("userName");
                postUserName.Text = userName.userName.ToString();
            }
        }
    }

    protected void postName_Click(object sender, EventArgs e)
    {
        int row = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
        Button postName = (Button)GridView1.Rows[row].FindControl("postName");

        Model.Post post = postBll.checkAllPost(postName.Text);
        Model.Bar barName = barBll.getBarName(post.barID);
        this.Session["barName"] = barName.barName.ToString();

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

    protected void postContent_Click(object sender, EventArgs e)
    {
        int row = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
        Button postName = (Button)GridView1.Rows[row].FindControl("postName");
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