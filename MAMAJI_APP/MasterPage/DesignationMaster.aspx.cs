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
    public partial class DesignationMaster : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["conn"].ToString(); // Replace with your actual connection string
        private DesignationManager designationManager;

        protected void Page_Load(object sender, EventArgs e)
        {
            designationManager = new DesignationManager(connectionString);
            if (!IsPostBack)
            {
                 BindGridView();
            }
        }

        protected void btnAddDesignation_Click(object sender, EventArgs e)
        {
            Designation designation = new Designation
            {
                DesignationName = txtDesignation.Text.Trim(),
                CreatedBy = 1, // Replace with actual user ID or logic to get user ID
                ISBlocked = "A" // Example default value
            };

            designationManager.InsertDesignation(designation);
            ClearAndRefresh();
        }
        private void ClearAndRefresh()
        {
            txtDesignation.Text = string.Empty;
            BindGridView();
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                decimal designationID = Convert.ToDecimal(GridView1.DataKeys[e.RowIndex].Values["DesignationID"]);
                string designationName = ((TextBox)row.FindControl("txtDesignation")).Text.Trim(); // Assuming you have a TextBox with ID "txtDesignationName"
                string status = ((DropDownList)row.FindControl("ddlStatus")).SelectedItem.Value.ToString();
                // Assuming you have a designationManager with a method to update designation
                
                
                Designation updatedDesignation = new Designation
                {
                    DesignationID = designationID,
                    DesignationName = designationName,
                    CreatedBy = 1, // Replace with actual user ID or logic to get user ID
                    ISBlocked = status // Example default value
                };

                designationManager.UpdateDesignation(updatedDesignation);
                GridView1.EditIndex = -1; // Exit edit mode after update
                BindGridView(); // Rebind the GridView after update
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw ex; // Example, handle appropriately in real scenario
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridView();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            try
            {
                // Check if e.RowIndex is within the valid range
                if (e.RowIndex >= 0 && e.RowIndex < GridView1.Rows.Count)
                {
                    decimal designationID = Convert.ToDecimal(GridView1.DataKeys[e.RowIndex].Value);
                    designationManager.DeleteDesignation(designationID);
                    BindGridView(); // Rebind the GridView after deletion
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw ex; // Example, handle appropriately in real scenario
            }
        }
        private void BindGridView()
        {
            GridView1.DataSource = designationManager.GetDesignations();
            GridView1.DataBind();
        }
    }
}