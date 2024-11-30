using MAMAJI_APP.Class;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MAMAJI_APP.Utilities
{
    public partial class NewBroadcast : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["conn"].ToString(); // Replace with your actual connection string
        private BroadcastManager broadcastManager;

        protected void Page_Load(object sender, EventArgs e)
        {
            broadcastManager = new BroadcastManager(connectionString);

            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            decimal broadcastID = Convert.ToDecimal(GridView1.DataKeys[e.RowIndex].Values["BroadcastID"]);
            broadcastManager.DeleteBroadcast(broadcastID);

            BindGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];

            decimal broadcastID = Convert.ToDecimal(GridView1.DataKeys[e.RowIndex].Values["BroadcastID"]);
            decimal broadcastType = Convert.ToDecimal(((TextBox)row.FindControl("txtBroadcastType")).Text);
            string broadcastContent = ((TextBox)row.FindControl("txtBroadcastContent")).Text;
            string broadcastRemark = ((TextBox)row.FindControl("txtBroadcastRemark")).Text;
            string broadcastStatus = ((DropDownList)row.FindControl("ddlBroadcastStatus")).SelectedValue;
            string releaseStatus = ((DropDownList)row.FindControl("ddlReleaseStatus")).SelectedValue;

            Broadcast broadcast = new Broadcast
            {
                BroadcastID = broadcastID,
                BroadcastType = broadcastType,
                BroadcastContent = broadcastContent,
                BroadcastRemark = broadcastRemark,
                BroadcastStatus = broadcastStatus,
                ReleaseStatus = releaseStatus
            };

            broadcastManager.UpdateBroadcast(broadcast);

            GridView1.EditIndex = -1;
            BindGrid();
        }

       

        private void BindGrid()
        {
            List<Broadcast> broadcasts = broadcastManager.GetBroadcasts();
            GridView1.DataSource = broadcasts;
            GridView1.DataBind();
        }


        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
           
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Request.Form["functionality"] == "message")
            {
                string messageText = message.Text;
                // Handle broadcast message
                Response.Write("<script>alert('Message broadcasted successfully!');</script>");
            }
            else if (Request.Form["functionality"] == "image")
            {
                if (imageUpload.HasFile)
                {
                    string imagePath = Server.MapPath("~/Uploads/") + imageUpload.FileName;
                    imageUpload.SaveAs(imagePath);
                    // Handle image upload
                    Response.Write("<script>alert('Image uploaded successfully!');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Please select an image to upload.');</script>");
                }
            }
            else if (Request.Form["functionality"] == "video")
            {
                string videoUrl = videoLink.Text;
                // Handle video link
                Response.Write("<script>alert('Video link uploaded successfully!');</script>");
            }
        }
    }
}