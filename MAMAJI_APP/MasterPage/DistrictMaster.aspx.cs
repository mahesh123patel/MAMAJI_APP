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
    public partial class DistrictMaster : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["conn"].ToString(); // Replace with your actual connection string
        private DistrictManager districtManager;
        protected void Page_Load(object sender, EventArgs e)
        {
            districtManager = new DistrictManager(connectionString);

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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            decimal districtID = Convert.ToDecimal(GridView1.DataKeys[e.RowIndex].Values["DistrictID"]);
            districtManager.DeleteDistrict(districtID);

            BindGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];

            decimal districtID = Convert.ToDecimal(GridView1.DataKeys[e.RowIndex].Values["DistrictID"]);
            string districtName = ((TextBox)row.FindControl("txtDistrictName")).Text;
            string districtHindiName = ((TextBox)row.FindControl("txtDistrictHindiName")).Text;
            string isBlocked = ((DropDownList)row.FindControl("ddlStatus")).SelectedValue;

            District district = new District
            {
                DistrictID = districtID,
                DistrictName = districtName,
                DistrictHindiName = districtHindiName,
                CreatedBy = 1,
                ISBlocked = isBlocked
            };

            districtManager.UpdateDistrict(district);

            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void btnAddDistrict_Click(object sender, EventArgs e)
        {

            District district = new District
            {
                DistrictName = txtDistrictEng.Text.Trim(),
                DistrictHindiName = txtDistrictHin.Text.Trim(),
                CreatedBy = 1,
                ISBlocked = "A"
            };

            districtManager.InsertDistrict(district);

            BindGrid();
        }
        private void BindGrid()
        {
            List<District> districts = districtManager.GetDistricts();
            GridView1.DataSource = districts;
            GridView1.DataBind();
        }
    }
}