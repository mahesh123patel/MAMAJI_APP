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
    public partial class ComplaintTypeMaster : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["conn"].ToString(); // Replace with your actual connection string
        private ConTypeManager conTypeManager;

        protected void Page_Load(object sender, EventArgs e)
        {
            conTypeManager = new ConTypeManager(connectionString);

            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        private void BindGrid()
        {
            List<ConType> conTypes = conTypeManager.GetConTypes();
            GridView1.DataSource = conTypes;
            GridView1.DataBind();
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

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            decimal conTypeID = Convert.ToDecimal(GridView1.DataKeys[e.RowIndex].Values[0]);
            string conTypeName = ((TextBox)row.FindControl("txtConType")).Text;
            string isBlocked = ((DropDownList)row.FindControl("ddlStatus")).SelectedValue;

            ConType conType = new ConType
            {
                ConTypeID = conTypeID,
                ConTypeName = conTypeName,
                CreatedBy = 1,
                ISBlocked = isBlocked
            };

            conTypeManager.UpdateConType(conType);
            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            decimal conTypeID = Convert.ToDecimal(GridView1.DataKeys[e.RowIndex].Values[0]);
            conTypeManager.DeleteConType(conTypeID);
            BindGrid();
        }

        protected void btnAddComplaintType_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ConType conType = new ConType
                {
                    ConTypeName = txtComplaintType.Text.Trim(),
                    CreatedBy = 1,
                    ISBlocked = "A"
                };

                conTypeManager.InsertConType(conType);
                ClearAndRefresh();
            }
        }
        private void ClearAndRefresh()
        {
            txtComplaintType.Text = string.Empty;
            BindGrid();
        }
    }
}