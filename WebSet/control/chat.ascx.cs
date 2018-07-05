using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class chat : System.Web.UI.UserControl
{
    BLL.BarBll barBll = new BarBll();
    BLL.PostBll postBll = new PostBll();
    protected void Page_Load(object sender, EventArgs e){}

    protected void btnUpPic_Click(object sender, EventArgs e)
    {
        
        if(this.FileUpload1.Visible == false)
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
                        this.ViewState["postPic"] = "~/postImgs/" + FileUpload1.FileName;
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

    //增加
    protected void btnRelease_Click(object sender, EventArgs e)
    {
        
        Model.Bar bar = barBll.getBarID(this.Session["barName"].ToString());
        Model.UserInfo user = postBll.getUserID(this.Session["userName"].ToString());


        int barID =Convert.ToInt32(bar.barID);
        int userID = Convert.ToInt32(user.userID);
        string postName = this.txtPostTitle.Text.Trim();
        string postContent = this.txtContent.Text;
        string postTime = DateTime.Now.ToLocalTime().ToString();
        string postPic = "0";
        string oo = "0";
        string nn = "0";
        string qq = "0";
        string ww = "0";
        string tt = "0";
        Post post = new Post(barID, userID, postName, postContent, postTime, postPic, oo, nn, qq, ww, tt);
        PostBll bll = new PostBll();
        OperationResult postAdd = bll.postAdd(post);

        if (postAdd.ToString() == "success")
        {
            tiShi2.Text = "发表成功";
            this.txtPostTitle.Text = "";
            this.txtContent.Text = "";
            Response.AddHeader("Refresh", "0");
        }
        else if (postAdd.ToString() == "failure")
        {
            tiShi2.Text = "发表失败";
        }
        else if (postAdd.ToString() == "exist")
        {
            tiShi2.Text = "发表的贴子已存在，请重命名";
        }
    }
}