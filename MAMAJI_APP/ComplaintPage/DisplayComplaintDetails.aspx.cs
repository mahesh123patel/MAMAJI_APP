using MAMAJI_APP.Class;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MAMAJI_APP.ComplaintPage
{
    public partial class DisplayComplaintDetails : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["conn"].ToString(); // Replace with your actual connection string
        private ComplaintManager complaintManager;
        protected void Page_Load(object sender, EventArgs e)
        {
            complaintManager = new ComplaintManager(connectionString);
            LoadComplaint();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }
        private void LoadComplaint()
        {
            if (Request.QueryString["C"] != null)
            {
                CommonClass cls = new CommonClass();
                string ss = HttpUtility.UrlDecode(Request.QueryString["C"].ToString());
                byte[] s = Convert.FromBase64String(ss.Replace(" ","+"));
                decimal complaintID = Convert.ToDecimal(cls.Decrypt(s));
                var complaint = complaintManager.GetComplaints(complaintID)[0];
                lblComplaintID.Text = complaint.ComplaintID.ToString();
                lblComplaintName.Text = complaint.ComplaintName;
                lblDistrict.Text = complaint.DistrictName;
                lblBlockID.Text = complaint.BlockName;
                lblComplaintAddress.Text = complaint.ComplaintAddress;
                lblConTypeID.Text = complaint.ConType.ToString();
                lblMobileNo.Text = complaint.MobileNo;
                lblDescription.Text = complaint.Description;
                lblAssignOfficerID.Text = complaint.OfficerName!=null ? complaint.OfficerName.ToString():"";

                LoadComplaintRemarks(complaintID);
               
            }
            if (Request.QueryString["st"] != null)
            {
               // CommonClass cls = new CommonClass();
                string status = HttpUtility.UrlDecode(Request.QueryString["st"].ToString());
               // byte[] s = Convert.FromBase64String(ss.Replace(" ", "+"));
               // decimal complaintID = Convert.ToDecimal(cls.Decrypt(s));
               // var complaint = complaintManager.GetComplaints(complaintID)[0];

                List<Complaint> complaints = complaintManager.GetComplaints();
                List<Complaint> filteredComplaints = new List<Complaint>();
                //lblOpenCount.Text = complaints.Where(c => c.Status == "Open").Count().ToString();
                //lblClosedCount.Text = complaints.Where(c => c.Status == "Closed").Count().ToString();
                //lblWIPCount.Text = complaints.Where(c => c.Status == "WIP").Count().ToString();

                               
                if (status=="o")
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
                
                GV1.DataSource=filteredComplaints;
                GV1.DataBind();

            }
            else
            {
                // Handle the case where the ComplaintID is not provided
                Response.Write("Complaint ID is required in the query string.");
            }
        }
        private void LoadComplaintRemarks(decimal complaintID)
        {
            ComplaintRemarkManager _compRemarkManager = new ComplaintRemarkManager(connectionString);
            List<ComplaintRemark> _listRemark = new List<ComplaintRemark>();
            _listRemark = _compRemarkManager.GetComplaintRemarks(complaintID);
            GridView1.DataSource = _listRemark;
            GridView1.DataBind();

        }
    }
}