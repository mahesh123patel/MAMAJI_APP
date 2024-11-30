using MAMAJI_APP.Class;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MAMAJI_APP.MasterPage
{
    public partial class OfficerMaster : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["conn"].ToString(); // Replace with your actual connection string
        private OfficerManager officerManager;
        protected void Page_Load(object sender, EventArgs e)
        {
            officerManager = new OfficerManager(connectionString);
            if(!IsPostBack)
            {
                FillDistrict(ddlOfficerDistrict);
                fillGrid();
            }
        }
        private void fillGrid()
        {
            List<Officer> officerinfo = new List<Officer>();
            officerinfo = officerManager.GetOfficers();
            GridView1.DataSource = officerinfo;
            GridView1.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Insert a new PersonInfo
            Officer newOfficer = new Officer
            {
                OfficerName = txtOfficerName.Text.Trim(),
                OfficerMobile = txtOfficerMobile.Text.Trim(),
                OfficerEmail = txtOfficerEmail.Text.Trim(),
                OfficerDesignation = txtOfficerDesignation.Text.Trim(),
                OfficerDistrict = Convert.ToInt16(ddlOfficerDistrict.SelectedItem.Value),
                CreatedBY = 1,
                IsBlocked = "A"
            };

            officerManager.InsertOfficer(newOfficer);
            fillGrid();
            Console.WriteLine("New PersonInfo inserted successfully.");
        }
        private void FillDistrict(DropDownList ddlDistrict)
        {
            List<District> dist = new List<District>();
            DistrictManager _districtManager = new DistrictManager(connectionString);
            dist = _districtManager.GetDistricts();
            ddlDistrict.DataSource = dist;
            ddlDistrict.DataTextField = "DistrictName";
            ddlDistrict.DataValueField = "DistrictID";
            ddlDistrict.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
           
            GridView1.EditIndex = e.NewEditIndex;
            fillGrid();
            GridViewRow row = GridView1.Rows[e.NewEditIndex];
            DropDownList ddlDistrict = (DropDownList)row.FindControl("ddlOfficerDistrict");
            FillDistrict(ddlDistrict);
            HiddenField hdnDistrictID = (HiddenField)row.FindControl("hdnOfficerDistrictID");
            ddlDistrict.SelectedValue = hdnDistrictID.Value;
            DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
            HiddenField hdnStatus = (HiddenField)row.FindControl("hdnStatus");
            ddlStatus.SelectedValue = hdnStatus.Value;
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            fillGrid();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            decimal OfficerID = Convert.ToDecimal(GridView1.DataKeys[e.RowIndex].Values[0]);
            officerManager.DeleteOfficer(OfficerID);
            fillGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            decimal OfficerID = Convert.ToDecimal(GridView1.DataKeys[e.RowIndex].Values[0]);
            string txtName = ((TextBox)row.FindControl("txtName")).Text;
            string txtMobile = ((TextBox)row.FindControl("txtMobile")).Text;
            string txtOfficerEmail = ((TextBox)row.FindControl("txtOfficerEmail")).Text;
            string txtOfficerDesignation = ((TextBox)row.FindControl("txtOfficerDesignation")).Text;

            string isBlocked = ((DropDownList)row.FindControl("ddlStatus")).SelectedValue;
            string ddlDistrict = ((DropDownList)row.FindControl("ddlOfficerDistrict")).SelectedValue;
            


            Officer newOfficer = new Officer
            {
                OfficerID = OfficerID,
                OfficerName = txtName.Trim(),
                OfficerMobile = txtMobile.Trim(),
                OfficerEmail = txtOfficerEmail.Trim(),
                OfficerDesignation = txtOfficerDesignation.Trim(),
                OfficerDistrict = Convert.ToInt16(ddlDistrict),
                CreatedBY = 1,
                IsBlocked = isBlocked
            };

            officerManager.UpdateOfficer(newOfficer);
            fillGrid();
            Console.WriteLine("New PersonInfo inserted successfully.");
        }

        protected void btnSubmit_Click1(object sender, EventArgs e)
        {

        }
    }
}