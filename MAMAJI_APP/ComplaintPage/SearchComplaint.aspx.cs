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
    public partial class SearchComplaint : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["conn"].ToString(); // Replace with your actual connection string
        private ComplaintManager complaintManager;
        protected void Page_Load(object sender, EventArgs e)
        {
            complaintManager = new ComplaintManager(connectionString);
        }

        protected void btnSearchComplaint_Click(object sender, EventArgs e)
        {
            if (txtComplaintNo.Text != "")
            {
                LoadComplaint(txtComplaintNo.Text);
                CompDetailsDiv.Visible = true;
                CompRemarkDiv.Visible = true;
            }
            else
            {
                CompDetailsDiv.Visible = false;
                CompRemarkDiv.Visible = false;
            }

        }
        private void LoadComplaint(string complaintid)
        {

            decimal complaintID = Convert.ToDecimal(complaintid);
            var complaint = complaintManager.GetComplaints(complaintID)[0];
            lblComplaintID.Text = complaint.ComplaintID.ToString();
            lblComplaintName.Text = complaint.ComplaintName;
            lblDistrict.Text = complaint.DistrictName.ToString();
            lblBlockID.Text = complaint.BlockName.ToString();
            lblComplaintAddress.Text = complaint.ComplaintAddress;
            lblConTypeID.Text = complaint.ConType.ToString();
            lblMobileNo.Text = complaint.MobileNo.ToString();
            lblDescription.Text = complaint.Description;
            lblAssignOfficerID.Text = complaint.OfficerName.ToString();

            LoadComplaintRemarks(complaintID);


        }
        private void LoadComplaintRemarks(decimal complaintID)
        {
            ComplaintRemarkManager _compRemarkManager = new ComplaintRemarkManager(connectionString);
            List<ComplaintRemark> _listRemark = new List<ComplaintRemark>();
            _listRemark = _compRemarkManager.GetComplaintRemarks(complaintID);
            GridView1.DataSource = _listRemark;
            GridView1.DataBind();

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtComplaintNo.Text = "";
            CompDetailsDiv.Visible = false;
            CompRemarkDiv.Visible = false;
        }
    }
}