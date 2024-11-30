using MAMAJI_APP.Class;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MAMAJI_APP.ComplaintPage
{
    public partial class ComplaintRegistration1 : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["conn"].ToString(); // Replace with your actual connection string
        private ComplaintManager complaintManager;
        protected void Page_Load(object sender, EventArgs e)
        {
            complaintManager = new ComplaintManager(connectionString);
            if (!IsPostBack)
            {
                FillOfficer(ddlOfficer);
                FillConType(ddlConType);
                FillDistrict();
            }
        }

        protected void ComplaintSubmit_Click(object sender, EventArgs e)
        {
            Complaint complaint = new Complaint
            {
                ComplaintName = txtComplaintName.Text.Trim(),
                DistrictCode = ddlDistrict.SelectedItem != null ? ddlDistrict.SelectedItem.Value : null,
                VidhanShabhaCode = ddlVidhanshabha.SelectedItem != null ? ddlVidhanshabha.SelectedItem.Value : null,
                UpkhandCode = ddlUpkhand.SelectedItem != null ? ddlUpkhand.SelectedItem.Value : null,
                TahsilCode = ddlTahsil.SelectedItem != null ? ddlTahsil.SelectedItem.Value : null,
                ThanaCode = ddlThana.SelectedItem != null ? ddlThana.SelectedItem.Value : null,
                BlockCode = ddlBlock.SelectedItem != null ? ddlBlock.SelectedItem.Value : null,
                ComplaintAddress = txtComplaintAddress.Text.Trim(),
                ConTypeID = ddlConType.SelectedItem != null ? Convert.ToInt16(ddlConType.SelectedItem.Value) : (short?)null,
                MobileNo = txtMobileNo.Text.Trim(),
                //Description = txtDescription.Text.Trim(),
                Description = Request.Form["txtDescription"],
                CreatedBY = 1,
                Status = "WIP",
                AssignOfficerID = Convert.ToInt64(ddlOfficer.SelectedItem.Value),
                //AssignOfficerID = ddlDistrict.SelectedItem.Value : null,
                ISBlocked = "A"
            };


            string compid = complaintManager.InsertComplaint(complaint);
            CommonClass cls = new CommonClass();
            string s = Convert.ToBase64String(cls.Encrypt(compid));
            // upload file
            if (FileUploadControl.HasFiles)
            {
                //string complaintNumber = compid+"-"+DateTime.Now.ToString("yyyyMMddmmss");
                string uploadDirectory = Server.MapPath("~/Complaints/");

                if (!Directory.Exists(uploadDirectory))
                {
                    Directory.CreateDirectory(uploadDirectory);
                }
                string concatenatedFilePath = string.Empty;
                foreach (var file in FileUploadControl.PostedFiles)
                {
                    string fileName = string.Empty;
                    if (IsValidFileType(file.FileName))
                    {
                        fileName = GetUniqueFileName(compid, file.FileName);
                        string filePath = Path.Combine(uploadDirectory, fileName);
                        file.SaveAs(filePath);                
                    }
                    else
                    {
                        StatusLabel.Text += $"File type not allowed: {file.FileName}<br/>";
                    }
                    concatenatedFilePath += fileName + ",";
                }

                StatusLabel.Text += "File(s) uploaded successfully!";
                // save file path in database
                if (!SaveFilePathToDatabase(compid, concatenatedFilePath))
                    Response.Write("Uploaded complaint document(s) could not saved in database.");


            }
            Response.Redirect("../ComplaintPage/DisplayComplaintDetails.aspx?C=" + HttpUtility.UrlEncode(s));
        }
        private void FillConType(DropDownList ddlConType)
        {
            List<ConType> contyps = new List<ConType>();
            ConTypeManager _conTypeManager = new ConTypeManager(connectionString);
            contyps = _conTypeManager.GetConTypes();
            ddlConType.DataSource = contyps;
            ddlConType.DataTextField = "ConTypeName";
            ddlConType.DataValueField = "ConTypeID";
            ddlConType.DataBind();
        }
        //private void FillDistrict(DropDownList ddlUpkhand)
        //{
        //    List<District> dist = new List<District>();
        //    DistrictManager _districtManager = new DistrictManager(connectionString);
        //    dist = _districtManager.GetDistricts();
        //    ddlUpkhand.DataSource = dist;
        //    ddlUpkhand.DataTextField = "DistrictName";
        //    ddlUpkhand.DataValueField = "DistrictID";
        //    ddlUpkhand.DataBind();
        //}
        private void FillOfficer(DropDownList ddlOfficer)
        {
            List<Officer> _officers = new List<Officer>();
            OfficerManager _officerManager = new OfficerManager(connectionString);
            _officers = _officerManager.GetOfficers();
            ddlOfficer.DataSource = _officers;
            ddlOfficer.DataTextField = "OfficerName";
            ddlOfficer.DataValueField = "OfficerID";
            ddlOfficer.DataBind();
        }
        //private void FillBlock(DropDownList ddlBlock)
        private void FillState()
        {
            List<Geo> geos = new List<Geo>();
            GeoManager geoManager = new GeoManager(connectionString);
            geos = geoManager.GetStates("1");
            ddlDistrict.DataSource = geos;
            ddlDistrict.DataTextField = "Name";
            ddlDistrict.DataValueField = "Code";
            ddlDistrict.DataBind();
            //ddlDistrict.Items.Insert(0, "Select");
            ddlDistrict.Items.Insert(0, new ListItem("Select", "-1"));
        }
        private void FillDistrict()
        {
            List<Geo> geos = new List<Geo>();
            GeoManager geoManager = new GeoManager(connectionString);
            geos = geoManager.GetDistrict("1");
            ddlDistrict.DataSource = geos;
            ddlDistrict.DataTextField = "Name";
            ddlDistrict.DataValueField = "Code";
            ddlDistrict.DataBind();
            //ddlDistrict.Items.Insert(0, "Select");
            ddlDistrict.Items.Insert(0, new ListItem("Select", "-1"));
        }
        private void FillVidhanshabha(string code)
        {
            List<Geo> geos = new List<Geo>();
            GeoManager geoManager = new GeoManager(connectionString);
            geos = geoManager.GetVidhanshabha(code);
            ddlVidhanshabha.DataSource = geos;
            ddlVidhanshabha.DataTextField = "Name";
            ddlVidhanshabha.DataValueField = "Code";
            ddlVidhanshabha.DataBind();
            ddlVidhanshabha.Items.Insert(0,new ListItem("Select","-1"));
        }

        private void FillUpkhand(string code)
        {
            List<Geo> geos = new List<Geo>();
            GeoManager geoManager = new GeoManager(connectionString);
            geos = geoManager.GetUpkhand(code);
            ddlUpkhand.DataSource = geos;
            ddlUpkhand.DataTextField = "Name";
            ddlUpkhand.DataValueField = "Code";
            ddlUpkhand.DataBind();
            //ddlUpkhand.Items.Insert(0, "Select");
            ddlUpkhand.Items.Insert(0, new ListItem("Select", "-1"));
        }
        private void FillBlock(string code)
        {
            List<Geo> geos = new List<Geo>();
            GeoManager geoManager = new GeoManager(connectionString);
            geos = geoManager.GetBlock(code);
            ddlBlock.DataSource = geos;
            ddlBlock.DataTextField = "Name";
            ddlBlock.DataValueField = "Code";
            ddlBlock.DataBind();
            //ddlBlock.Items.Insert(0, "Select");
            ddlBlock.Items.Insert(0, new ListItem("Select", "-1"));
        }



        private void FillTahsil(string code)
        {
            List<Geo> geos = new List<Geo>();
            GeoManager geoManager = new GeoManager(connectionString);
            geos = geoManager.GetTahsil(code);
            ddlTahsil.DataSource = geos;
            ddlTahsil.DataTextField = "Name";
            ddlTahsil.DataValueField = "Code";
            ddlTahsil.DataBind();
            //ddlTahsil.Items.Insert(0, "Select");
            ddlTahsil.Items.Insert(0, new ListItem("Select", "-1"));
        }
        private void FillThana(string code)
        {
            List<Geo> geos = new List<Geo>();
            GeoManager geoManager = new GeoManager(connectionString);
            geos = geoManager.GetThana(code);
            ddlThana.DataSource = geos;
            ddlThana.DataTextField = "Name";
            ddlThana.DataValueField = "Code";
            ddlThana.DataBind();
            //ddlThana.Items.Insert(0, "Select");
            ddlThana.Items.Insert(0, new ListItem("Select", "-1"));
        }


        private void FillVillage(string code)
        {
            List<Geo> geos = new List<Geo>();
            GeoManager geoManager = new GeoManager(connectionString);
            geos = geoManager.GetVillage(code);
            ddlVillage.DataSource = geos;
            ddlVillage.DataTextField = "Name";
            ddlVillage.DataValueField = "Code";
            ddlVillage.DataBind();
            //ddlVillage.Items.Insert(0, "Select");
            ddlVillage.Items.Insert(0, new ListItem("Select", "-1"));
        }
        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillVidhanshabha(ddlDistrict.SelectedItem.Value);
        }
        
        protected void ddlVidhanshabha_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillUpkhand(ddlVidhanshabha.SelectedItem.Value);
        }

        protected void ddlUpkhand_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillBlock(ddlUpkhand.SelectedItem.Value);
        }
        protected void ddlBlock_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillTahsil(ddlBlock.SelectedItem.Value);
        }
        protected void ddlTahsil_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillThana(ddlTahsil.SelectedItem.Value);
        }        
        
        //protected void ddlThana_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    FillVillage(ddlThana.SelectedItem.Value);
        //}
       
        private string GetUniqueFileName(string complaintNumber, string originalFileName)
        {
            string fileExtension = Path.GetExtension(originalFileName);
            string uniqueFileName = $"{complaintNumber}_{DateTime.Now:yyyyMMddHHmmss}{fileExtension}";
            return uniqueFileName;
        }

        private bool IsValidFileType(string fileName)
        {
            string[] allowedExtensions = { ".pdf", ".doc", ".docx", ".jpg", ".jpeg", ".png" };
            string fileExtension = Path.GetExtension(fileName).ToLower();
            return Array.IndexOf(allowedExtensions, fileExtension) >= 0;
        }
        private bool SaveFilePathToDatabase(string complaintNumber, string filePath)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "update tbl_Complaint set Docs=@FilePath where ComplaintID=@ComplaintNumber";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ComplaintNumber", complaintNumber);
                    command.Parameters.AddWithValue("@FilePath", filePath);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return true;

        }

        
    }
}