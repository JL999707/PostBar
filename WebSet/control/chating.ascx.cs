using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class control_chating : System.Web.UI.UserControl
{
    BLL.PostBll postBll = new PostBll();
    BLL.ReplyBll replyBll = new ReplyBll();
    protected void Page_Load(object sender, EventArgs e){}

    protected void btnUpPic_Click(object sender, EventArgs e)
    {
        if (this.FileUpload1.Visible == false)
        {
            this.FileUpload1.Visible = true;
        }
        else
        {
            bool files = false;
            if (this.FileUpload1.HasFile)
            {
                //获取上传文件的后缀
                String fileExtension = System.IO.Path.GetExtension(this.FileUpload1.FileName).ToLower();
                String[] restrictExtension = { ".gif", ".jpg", ".bmp", ".png" };
                //判断文件类型是否符合
                for (int i = 0; i < restrictExtension.Length; i++)
                {
                    if (fileExtension == restrictExtension[1])
                    {
                        files = true;
                    }
                }
                //调用SaveAs方法实现上传
                if (files == true)
                {
                    try
                    {
                        this.Image1.Visible = true;
                        this.FileUpload1.SaveAs(Server.MapPath("~/postImgs/") + FileUpload1.FileName);
                        this.Image1.ImageUrl = "~/postImgs/" + FileUpload1.FileName;
                        this.ViewState["replyPic"] = "~/postImgs/" + FileUpload1.FileName;
                        //this.Image1.ImageUrl = this.ViewState["postPic"].ToString();
                        this.FileUpload1.Visible = false;
                        this.btnUpPic.Visible = false;
                    }
                    catch
                    {
                        this.tiShi.Text = "图片上传不成功";
                    }
                }
                else
                {
                    this.tiShi.Text = "只能够上传后缀为.gif、 .jpg、 .bmp、.png的图片";
                }
            }
        }
    }

    protected void btnRelease_Click(object sender, EventArgs e)
    {
        if (this.Session["userName"] != null)
        {
            string userName = this.Session["userName"].ToString();
            Model.UserInfo user = postBll.getUserID(userName);

            int userID = user.userID;
            int postID = Convert.ToInt32(this.Session["postID"]);
            string replyName = this.Session["postUserNameToReplyName"].ToString();
            string replyContent = txtContent.Text;
            string replyTime = DateTime.Now.ToLocalTime().ToString();
            string replyPic = "1";
            Reply reply = new Reply(userID, postID, replyName, replyContent, replyTime, replyPic);
            OperationResult replyadd = replyBll.replyAdd(reply);

            if (replyadd.ToString() == "success")
            {
                Response.AddHeader("Refresh", "0");
            }
            else if (replyadd.ToString() == "failure")
            {
                Response.Write("<script>alert('failure')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('请登录！')</script>");
        }

        //if (this.Session["postID"] != null)
        //{
        //    if (this.Session["userID"] != null)
        //    {
        //        int psotID = Convert.ToInt32(this.Session["postID"].ToString());
        //        int userID = Convert.ToInt32(this.Session["userID"].ToString());
        //        string replyName = this.txtReplyTitle.Text.Trim();
        //        string replyContent = this.txtContent.Text;
        //        string replyTime = DateTime.Now.ToString();
        //        string replyPic = this.ViewState["replyPic"].ToString();
        //        Reply reply = new Reply(userID, psotID, replyName, replyContent, replyTime, replyPic);
        //        ReplyBll bll = new ReplyBll();
        //        OperationResult postAdd = bll.replyAdd(reply);

        //        if (postAdd.ToString() == "success")
        //        {
        //            tiShi2.Text = "发表成功";
        //        }
        //        else if (postAdd.ToString() == "failure")
        //        {
        //            tiShi2.Text = "发表失败";
        //        }
        //        else if (postAdd.ToString() == "exist")
        //        {
        //            tiShi2.Text = "发表的贴子已存在，请重命名";
        //        }
        //    }
        //    else
        //    {
        //        tiShi2.Text = "请登录";
        //    }
        //}
        //else
        //{
        //    tiShi2.Text = "贴吧不存在";
        //}
    }
}