using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class control_tableCon : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        this.tiShi.Text = "";
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
                        this.FileUpload1.SaveAs(Server.MapPath("~/imgs/") + FileUpload1.FileName);
                        this.Image1.Src = "~/imgs/" + FileUpload1.FileName;
                        this.ViewState["headImg"] = "~/imgs/" + FileUpload1.FileName;
                        
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

    //更新信息
    protected void btnRelease_Click(object sender, EventArgs e)
    {
        //int barID = Convert.ToInt32(this.Session["barID"].ToString());
        string barName = this.Session["barName"].ToString();
        string userName = this.Session["userName"].ToString();
        string barAutoGraph = this.Session["barAutoGraph"].ToString();
        string barTypeName = this.Session["barTypeName"].ToString();
        string headImg = this.ViewState["headImg"].ToString();

        UserBll userBll = new UserBll();
        UserInfo user = userBll.getUserID(userName);

        BarTypeBll barTypeBll = new BarTypeBll();
        BarType barType = barTypeBll.getBarTypeID(barTypeName);
        //     userID = user.userID

        Bar bar = new Bar(user.userID,barType.barTypeID ,barName, barAutoGraph, headImg);
        BarBll bll = new BarBll();
        bool barUpDate = bll.Update(bar);

        if (barUpDate)
        {
            tiShi.Text = "更新成功";
        }
        else
        {
            tiShi.Text = "更新失败";
        }
    }
}

/*后台数据代码
 userDao
 //根据userName得到userID
        public UserInfo getUserID(string userName)
        {
            string cmdText = "select * from T_User where userName=@userName";
            string[] paramList = { "@userName" };
            object[] valueList = { userName };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            UserInfo user = new UserInfo();
            if (reader.Read())
            {
                user.userName = userName;
                user.userID = Convert.ToInt32(reader["userID"].ToString());
            }
            reader.Close();
            return user;
        }
     
    userBll
     //根据userName得到userID
        public Model.UserInfo getUserID(string userName)
        {
            Model.UserInfo getUserID = dao.getUserID(userName);
            //int getUserID1 = Convert.ToInt32(getUserID);
            //不需要访问数据源，直接执行业务逻辑
            if (getUserID != null)
            {
                return getUserID;
            }
            else
            {
                return getUserID;
            }
        }

    barTypeDao
     //根据barTypeName得到barTypeID
        public BarType getBarTypeID(string barTypeName)
        {
            string cmdText = "select * from T_BarType where barTypeName=@barTypeName";
            string[] paramList = { "@barTypeName" };
            object[] valueList = { barTypeName };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            BarType barType = new BarType();
            if (reader.Read())
            {
                barType.barTypeName = barTypeName;
                barType.barTypeID = Convert.ToInt32(reader["barTypeID"].ToString());
            }
            reader.Close();
            return barType;
        }

    barTypeBll
    //根据barTypeName得到barTypeID
        public Model.BarType getBarTypeID(string barTypeName)
        {
            Model.BarType getBarTypeID = dao.getBarTypeID(barTypeName);
            //int getUserID1 = Convert.ToInt32(getUserID);
            //不需要访问数据源，直接执行业务逻辑
            if (getBarTypeID != null)
            {
                return getBarTypeID;
            }
            else
            {
                return getBarTypeID;
            }
        }
*/
