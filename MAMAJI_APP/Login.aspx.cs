using MAMAJI_APP.Class;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MAMAJI_APP
{
    public partial class Login : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["conn"].ToString(); // Replace with your actual connection string
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text != null && txtUserID.Text != "" && txtPassword.Text != null && txtPassword.Text != "")
            {
                LoginClass login = new LoginClass(connectionString);
                List<PersonInfo> UserDetails = login.LoginUser(txtUserID.Text, txtPassword.Text);
                if(UserDetails.Count>0)
                {
                    Session["PersonInfo"]  = UserDetails;
                    Response.Redirect("~/DashBoard.aspx");
                }
                else
                {
                    lblMessage.Text = "UserID or Password Invalid.";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('UserID or Password Invalid.');", true);
                }
            }
            else
            {
                lblMessage.Text = "UserID or Password cannot be blank.";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('UserID or Password cannot be blank.');", true);
            }

        }
    }
}