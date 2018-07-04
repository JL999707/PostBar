using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    BLL.BarBll barBll = new BLL.BarBll();
    BLL.PostBll postBll = new BLL.PostBll();
    BLL.BarAttBll barAttBll = new BLL.BarAttBll();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.barName.Text = this.Session["barName"].ToString();

            Model.Bar barID = barBll.getBarID(this.barName.Text);

            int attNum = barAttBll.checkCountBarID(barID.barID);
            this.barAtt.Text = attNum.ToString();

            int postNum = postBll.checkCountBarID(barID.barID);
            this.postNum.Text = postNum.ToString();

            Model.Bar graph = barBll.checkAllBar(this.barName.Text);
            this.graph.Text = graph.barAutoGraph.ToString();
            
            bool isAccurate = false;
            List<Model.Post> postList = postBll.checkBarIDDesc(barID.barID, isAccurate);
            this.GridView1.DataSource = postList;
            this.GridView1.DataBind();

            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                Button postName = (Button)GridView1.Rows[i].FindControl("postName");
                Model.Post postID = postBll.getPostID(postName.Text);
                Model.Post userID = postBll.getPostUserID(Convert.ToInt32(postID.postID));
                Model.UserInfo postUserName = postBll.getUserName(Convert.ToInt32(userID.userID));
                Button userName = (Button)GridView1.Rows[i].FindControl("userName");
                userName.Text = postUserName.userName.ToString();
            }
        }
    }

    protected void postName_Click(object sender, EventArgs e)
    {
        int row = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
        Button postName = (Button)GridView1.Rows[row].FindControl("postName");
        if (this.Session["postName"] != null)
        {
            this.Session["postName"] = null;
            this.Session["postName"] = postName.Text;
        }
        else {
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

    protected void btnReply_Click(object sender, EventArgs e)
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