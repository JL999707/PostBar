using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    BLL.BarBll bll = new BLL.BarBll();
    BLL.BarAttBll mrg = new BLL.BarAttBll();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.barName.Text = this.Session["barName"].ToString();

            //BLL.BarAttBll mrg = new BLL.BarAttBll();

            //int i = mrg.checkCountID();
        }
    }
}