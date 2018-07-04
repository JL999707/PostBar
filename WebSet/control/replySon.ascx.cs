using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class control_replySon : System.Web.UI.UserControl
{
    BLL.ReplyBll replyBll = new BLL.ReplyBll();
    BLL.PostBll postBll = new BLL.PostBll();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (this.Session["beReplyUserName"] != null)
            {
                Model.Reply reply = replyBll.checkAllReply(this.Session["beReplyUserName"].ToString());

                if (reply.postID == Convert.ToInt32(this.Session["postID"]))
                {
                    bool isAccurate = false;
                    List<Reply> replyList = replyBll.likeCheckReply(this.Session["beReplyUserName"].ToString(), isAccurate);
                    this.GridView1.DataSource = replyList;
                    this.GridView1.DataBind();

                    for (int i = 0; i < this.GridView1.Rows.Count; i++)
                    {
                        Label userName = (Label)GridView1.Rows[i].FindControl("replyUserName");
                        userName.Text = reply.replyName.ToString();

                        Label replyTime = (Label)GridView1.Rows[i].FindControl("replyTime");
                        replyTime.Text = reply.replyTime.ToString();
                    }
                }
            }
        }
    }
}