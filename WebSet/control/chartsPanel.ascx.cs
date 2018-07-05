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
        if (!IsPostBack)
        {
            string userName = null;
            bool isAccurate = false;
            BLL.BarBll mgr = new BLL.BarBll();
            List<Bar> barList = mgr.checkBarDesc(userName, isAccurate);

            this.GridView1.DataSource = barList;
            this.GridView1.DataBind();

            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                Button barName = (Button)GridView1.Rows[i].FindControl("barName");

                int barNum = mgr.checkCountBarName(barName.Text);

                Label peopleNum = (Label)GridView1.Rows[i].FindControl("peopleNum");
                peopleNum.Text = barNum.ToString();
            }
        }
    }

    protected void barName_Click(object sender, EventArgs e)
    {
        int row = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
        Button barName = (Button)GridView1.Rows[row].FindControl("barName");
        this.Session["barName"] = barName.Text;
        Response.Redirect("Bar.aspx");
    }
}