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
    public partial class UserMaster : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["conn"].ToString(); // Replace with your actual connection string
        private PersonInfoManager personInfoManager;
        protected void Page_Load(object sender, EventArgs e)
        {
            personInfoManager = new PersonInfoManager(connectionString);
            if (!IsPostBack)
            {
                FillDistrict(ddlDistrict);
                FillDesignation(ddlDesignation);
                FillBlock(ddlBlock);
                fillGrid();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Insert a new PersonInfo
            PersonInfo newPerson = new PersonInfo
            {
                Name = txtName.Text.Trim(),
                Mobile = txtMobile.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                DistrictID = Convert.ToInt16(ddlDistrict.SelectedItem.Value),
                BlockID = 1,//Convert.ToInt16(ddlBlock.SelectedItem.Value),
                DesignationID = Convert.ToInt16(ddlDesignation.SelectedItem.Value),
                CreatedBy = 1,
                ISBlocked = "A",
                UserID = txtUserID.Text.Trim(),
                Password = txtPassword.Text.Trim()
            };

            string s = personInfoManager.InsertPersonInfo(newPerson);
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + s + "');", true);
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
        private void FillDesignation(DropDownList ddlDesignation)
        {
            List<Designation> _designations = new List<Designation>();
            DesignationManager _designationManager = new DesignationManager(connectionString);
            _designations = _designationManager.GetDesignations();
            ddlDesignation.DataSource = _designations;
            ddlDesignation.DataTextField = "DesignationName";
            ddlDesignation.DataValueField = "DesignationID";
            ddlDesignation.DataBind();
        }
        private void FillBlock(DropDownList ddlBlock)
        {
            List<Block> _blocks = new List<Block>();
            BlockManager _blockManager = new BlockManager(connectionString);
            _blocks = _blockManager.GetBlocks();
            ddlBlock.DataSource = _blocks;
            ddlBlock.DataTextField = "BlockName";
            ddlBlock.DataValueField = "BlockID";
            ddlBlock.DataBind();
        }
        private void fillGrid()
        {
            List<PersonInfo> personInfo = new List<PersonInfo>();
            personInfo = personInfoManager.GetPersonInfos();
            GridView1.DataSource = personInfo;
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //GridViewRow row = GridView1.Rows[e.NewEditIndex];
            //GridView1.EditIndex = e.NewEditIndex;
            // Set the row to be edited
            GridView1.EditIndex = e.NewEditIndex;
            fillGrid(); // Rebind the GridView to refresh the data

            // Find the TextBox control in the editing row
            GridViewRow row = GridView1.Rows[e.NewEditIndex];

            DropDownList ddlDesignation = (DropDownList)row.FindControl("ddlDesignation");
            FillDesignation(ddlDesignation);
            HiddenField hdnDesignationID = (HiddenField)row.FindControl("hdnDesignationID");
            ddlDesignation.SelectedValue = hdnDesignationID.Value;
            DropDownList ddlDistrict = (DropDownList)row.FindControl("ddlDistrict");
            FillDistrict(ddlDistrict);
            HiddenField hdnDistrictID = (HiddenField)row.FindControl("hdnDistrictID");
            ddlDistrict.SelectedValue = hdnDistrictID.Value;
            DropDownList ddlBlock = (DropDownList)row.FindControl("ddlBlock");
            FillBlock(ddlBlock);
            HiddenField hdnBlockID = (HiddenField)row.FindControl("hdnBlockID");
            ddlBlock.SelectedValue = hdnBlockID.Value;
            DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
            HiddenField hdnStatus = (HiddenField)row.FindControl("hdnStatus");
            ddlStatus.SelectedValue = hdnStatus.Value;
            //fillGrid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            fillGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            decimal PersonInfoID = Convert.ToDecimal(GridView1.DataKeys[e.RowIndex].Values[0]);
            string txtName = ((TextBox)row.FindControl("txtName")).Text;
            string txtMobile = ((TextBox)row.FindControl("txtMobile")).Text;
            string txtEmail = ((TextBox)row.FindControl("txtEmail")).Text;
            string txtAddress = ((TextBox)row.FindControl("txtAddress")).Text;
            string txtUserID = ((TextBox)row.FindControl("txtUserID")).Text;
            string txtPassword = ((TextBox)row.FindControl("txtPassword")).Text;
            string isBlocked = ((DropDownList)row.FindControl("ddlStatus")).SelectedValue;
            string ddlDistrict = ((DropDownList)row.FindControl("ddlDistrict")).SelectedValue;
            string ddlBlock = ((DropDownList)row.FindControl("ddlBlock")).SelectedValue;
            string ddlDesignation = ((DropDownList)row.FindControl("ddlDesignation")).SelectedValue;


            PersonInfo newPerson = new PersonInfo
            {
                PersonInfoID = PersonInfoID,
                Name = txtName.Trim(),
                Mobile = txtMobile.Trim(),
                Email = txtEmail.Trim(),
                Address = txtAddress.Trim(),
                DistrictID = Convert.ToInt16(ddlDistrict),
                BlockID = Convert.ToInt16(ddlBlock),
                DesignationID = Convert.ToInt16(ddlDesignation),
                CreatedBy = 1,
                ISBlocked = isBlocked,
                UserID = txtUserID.Trim(),
                Password = txtPassword.Trim()
            };

            string s = personInfoManager.UpdatePersonInfo(newPerson);
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + s + "');", true);
            GridView1.EditIndex = -1;
            fillGrid();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            decimal PersonInfoID = Convert.ToDecimal(GridView1.DataKeys[e.RowIndex].Values[0]);
            personInfoManager.DeletePersonInfo(PersonInfoID);
            fillGrid();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}