using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MAMAJI_APP
{
    public partial class DashboardMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["PersonInfo"]==null)
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["PersonInfo"] = null;
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
    }
}