using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class control_replyChat : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRelease_Click(object sender, EventArgs e)
    {
        if (this.Session["postID"] != null)
        {
            if (this.Session["userID"] != null)
            {
                int psotID = Convert.ToInt32(this.Session["postID"].ToString());
                int userID = Convert.ToInt32(this.Session["userID"].ToString());
                string replyName = this.Session["userID"].ToString() + "的回复";
                string replyContent = this.txtContent.Text;
                string replyTime = DateTime.Now.ToString();
                Reply reply = new Reply(userID, psotID, replyName, replyContent, replyTime);
                ReplyBll bll = new ReplyBll();
                OperationResult postAdd = bll.replyAdd(reply);
            }
        }
    }
}