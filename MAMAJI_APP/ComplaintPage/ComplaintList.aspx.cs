using MAMAJI_APP.Class;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MAMAJI_APP.ComplaintPage
{
    public partial class ComplaintList : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["conn"].ToString(); // Replace with your actual connection string
        private ComplaintManager complaintManager;
        protected void Page_Load(object sender, EventArgs e)
        {
            complaintManager = new ComplaintManager(connectionString);
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView(string searchTerm = "")
        {
            if (Request.QueryString["st"] != null)
            {
                string status = HttpUtility.UrlDecode(Request.QueryString["st"].ToString());

                //string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
                List<Complaint> complaints = complaintManager.GetComplaints();
                List<Complaint> filteredComplaints = new List<Complaint>();
                if (status == "o")
                {
                    filteredComplaints = complaints.Where(c => c.Status == "Open").ToList();
                }
                if (status == "c")
                {
                    filteredComplaints = complaints.Where(c => c.Status == "Closed").ToList();
                }
                if (status == "w")
                {
                    filteredComplaints = complaints.Where(c => c.Status == "WIP").ToList();
                }

                gvComplaints.DataSource = filteredComplaints;
                gvComplaints.DataBind();
            }
            //using (SqlConnection con = new SqlConnection(connectionString))
            //{
            //    using (SqlCommand cmd = new SqlCommand("GetComplaints", con))
            //    {
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        if (!string.IsNullOrEmpty(searchTerm))
            //        {
            //            cmd.Parameters.AddWithValue("@SearchTerm", searchTerm);
            //        }
            //        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            //        {
            //            DataTable dt = new DataTable();
            //            sda.Fill(dt);
            //            gvComplaints.DataSource = dt;
            //            gvComplaints.DataBind();
            //        }
            //    }
            //}
        }

      

        protected void gvComplaints_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvComplaints.PageIndex = e.NewPageIndex;
            BindGridView();
        }
    }
}