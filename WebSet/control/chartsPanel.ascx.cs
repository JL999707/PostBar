using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class chartsPanel : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userName = null;
        bool isAccurate = false;
        BLL.BarBll mgr = new BLL.BarBll();
        List<Bar> barList = mgr.checkBarDesc(userName, isAccurate);
        
        this.GridView1.DataSource = barList;
        this.GridView1.DataBind();

        //Response.Write("<script>alert('" + barList.ToString() + "')</script>");
        //else
        //{
        //    this.tishi.Text = "查找不到";
        //}
    }
}