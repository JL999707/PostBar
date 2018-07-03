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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.barName.Text = this.Session["barName"].ToString();

            Model.Bar barID = barBll.getBarID(this.barName.Text);

            int i = barAttBll.checkCountBarID(barID.barID);
            this.barAtt.Text = i.ToString();

            int j = postBll.checkCountBarID(barID.barID);
            this.postNum.Text = j.ToString();
        }
    }

    protected void barName_Click(object sender, EventArgs e)
    {
        Response.Redirect("Bar.aspx");
    }
}