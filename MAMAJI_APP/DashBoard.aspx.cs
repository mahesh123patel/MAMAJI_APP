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

    public partial class DashBoard : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["conn"].ToString(); // Replace with your actual connection string
        private ComplaintManager complaintManager;
        protected void Page_Load(object sender, EventArgs e)
        {
            complaintManager = new ComplaintManager(connectionString);
            if (!IsPostBack)
            {
                FillComplaint();                
            }

        }
        protected void FillComplaint()
        {
            List<Complaint> complaints = complaintManager.GetComplaints();
            lblOpenCount.Text  = complaints.Where(c => c.Status == "Open").Count().ToString();
            lblClosedCount.Text = complaints.Where(c => c.Status == "Closed").Count().ToString();
            lblWIPCount.Text = complaints.Where(c => c.Status == "WIP").Count().ToString();
            
        }

        
    }
}