using BLL;
using Model;
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
    BLL.AtBll atBll = new BLL.AtBll();
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
            Model.Post post = postBll.checkAllPost(this.postName.Text);
            Model.Post userID = postBll.getPostUserID(Convert.ToInt32(post.postID));
            Model.UserInfo postUserName = postBll.getUserName(Convert.ToInt32(userID.userID));
            this.userName.Text = postUserName.userName.ToString();
            this.labTime.Text = post.postTime.ToString();
            this.postContent.Text = post.postContent.ToString();
            this.Session["postID"] = post.postID;

            Model.Reply reply = replyBll.checkAllReplyPostID(post.postID);

            if (reply.replyName == this.userName.Text)
            {
                bool isAccurate = false;
                List<Reply> replyList = replyBll.likeCheckReply(this.userName.Text, isAccurate);
                this.GridView1.DataSource = replyList;
                this.GridView1.DataBind();

                for (int i = 0; i < this.GridView1.Rows.Count; i++)
                {
                    Button userName = (Button)GridView1.Rows[i].FindControl("userName");
                    Model.UserInfo replyUserName = postBll.getUserName(Convert.ToInt32(reply.userID));
                    userName.Text = replyUserName.userName.ToString();

                    Panel replySon = (Panel)this.GridView1.Rows[i].FindControl("replySon");
                    replySon.Visible = false;
                }
            }
        }
    }

    protected void barName_Click(object sender, EventArgs e)
    {
        Response.Redirect("Bar.aspx");
    }

    protected void btnReply1_Click(object sender, EventArgs e)
    {
        int row = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;

        Panel replySon = (Panel)this.GridView1.Rows[row].FindControl("replySon");
        replySon.Visible = !replySon.Visible;

        Button userName = (Button)GridView1.Rows[row].FindControl("userName");

        Model.Reply reply = replyBll.checkAllReply(userName.Text);

        if (reply.postID == Convert.ToInt32(this.Session["postID"]) )
        {
            bool isAccurate = false;
            List<Reply> replyList = replyBll.likeCheckReply(userName.Text, isAccurate);
            GridView GridView2 = (GridView)this.GridView1.Rows[row].FindControl("GridView2");
            GridView2.DataSource = replyList;
            GridView2.DataBind();

            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                Label replyUserName = (Label)GridView2.Rows[i].FindControl("replyUserName");
                Model.UserInfo replyName = postBll.getUserName(Convert.ToInt32(reply.userID));
                replyUserName.Text = replyName.userName.ToString();

                Label replyContent = (Label)GridView2.Rows[i].FindControl("replyContent");
                replyContent.Text = reply.replyContent.ToString();

                Label replyTime = (Label)GridView2.Rows[i].FindControl("replyTime");
                replyTime.Text = reply.replyTime.ToString();
            }
        }
        Panel addReplySon = (Panel)this.GridView1.Rows[row].FindControl("addReplySon");
        
        addReplySon.Visible = replySon.Visible;
    }

    protected void btnReplySon_Click(object sender, EventArgs e)
    {
        int row = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;

        Panel addReplySon = (Panel)this.GridView1.Rows[row].FindControl("addReplySon");
        addReplySon.Visible = !addReplySon.Visible;
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        int row = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;

        string userName = this.Session["userName"].ToString();
        Model.UserInfo user = postBll.getUserID(userName);
        Button name = (Button)GridView1.Rows[row].FindControl("userName");
        TextBox txtContent = (TextBox)GridView1.Rows[row].FindControl("txtContent");

        int userID = user.userID;
        int postID = Convert.ToInt32(this.Session["postID"]);
        string replyName = name.Text;
        string replyContent = txtContent.Text;
        string replyTime = DateTime.Now.ToLocalTime().ToString();
        string replyPic = "1";
        Reply reply = new Reply(userID,postID, replyName,replyContent, replyTime, replyPic);
        OperationResult replyadd = replyBll.replyAdd(reply);

        if (replyadd.ToString() == "success")
        {
            Response.AddHeader("Refresh", "0");
        }
        else if (replyadd.ToString() == "failure")
        {
            Response.Write("<script>alert('failure')</script>");
        }
        else
        {
            Response.Write("<script>alert('用户已存在')</script>");
        }
    }
}