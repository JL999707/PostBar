using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    BLL.BarBll barBll = new BLL.BarBll();
    BLL.PostBll postBll = new BLL.PostBll();
    BLL.BarAttBll barAttBll = new BLL.BarAttBll();
    BLL.ReplyBll replyBll = new BLL.ReplyBll();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.barName.Text = this.Session["barName"].ToString();

            Model.Bar barID = barBll.getBarID(this.barName.Text);

            int barAtt = barAttBll.checkCountBarID(barID.barID);
            this.barAtt.Text = barAtt.ToString();

            int postNum = postBll.checkCountBarID(barID.barID);
            this.postNum.Text = postNum.ToString();

            Model.Bar graph = barBll.checkAllBar(this.barName.Text);
            this.graph.Text = graph.barAutoGraph.ToString();

            this.postName.Text = this.Session["postName"].ToString();
            Model.Post postID = postBll.getPostID(postName.Text);
            Model.Post userID = postBll.getPostUserID(Convert.ToInt32(postID.postID));
            Model.UserInfo postUserName = postBll.getUserName(Convert.ToInt32(userID.userID));
            this.userName.Text = postUserName.userName.ToString();
            Model.Post post = postBll.checkAllPost(this.postName.Text);
            this.postContent.Text = post.postContent.ToString();
            this.labTime.Text = post.postTime.ToString();


        }
    }

    protected void barName_Click(object sender, EventArgs e)
    {
        Response.Redirect("Bar.aspx");
    }
}