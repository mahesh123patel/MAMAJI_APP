using MAMAJI_APP.Class;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace MAMAJI_APP
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["conn"].ToString();

        private string DataTableToJson(DataTable dataTable)
        {
            // Convert DataTable to List of Dictionary
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();

            foreach (DataRow row in dataTable.Rows)
            {
                Dictionary<string, object> rowDict = new Dictionary<string, object>();
                foreach (DataColumn column in dataTable.Columns)
                {
                    rowDict[column.ColumnName] = row[column];
                }
                rows.Add(rowDict);
            }

            // Serialize List of Dictionary to JSON
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(rows);
        }
      
        [WebMethod]
        public string GetCompaintType()
        {
            DataTable dt = new DataTable();
            ConTypeManager conTypeManager = new ConTypeManager(connectionString);
            List<ConType> conTypes = conTypeManager.GetConTypes();
            string[] columnName = { "ConTypeID", "ConTypeName" };
            DataTable dataTable = conTypes.ToDataTable(columnName);
            return DataTableToJson(dataTable);
        }
        [WebMethod]
        public string GetDistrict()
        {
            DataTable dt = new DataTable();
            DistrictManager Manager = new DistrictManager(connectionString);
            List<District> conTypes = Manager.GetDistricts();
            string[] columnName = { "DistrictID", "DistrictName", "DistrictHindiName" };
            DataTable dataTable = conTypes.ToDataTable(columnName);
            return DataTableToJson(dataTable);
        }
        //[WebMethod]
        //public string GetCompaintType()
        //{
        //    DataTable dt = new DataTable();
        //    ConTypeManager conTypeManager = new ConTypeManager(connectionString);
        //    List<ConType> conTypes = conTypeManager.GetConTypes();
        //    string[] columnName = { "ConTypeID", "ConTypeName" };
        //    DataTable dataTable = conTypes.ToDataTable(columnName);
        //    return DataTableToJson(dataTable);
        //}
       

        [WebMethod]
        public string PostMethod(string name, int age)
        {
            var data = new { message = "Hello {name}, you are {age} years old." };
            return new JavaScriptSerializer().Serialize(data);
        }
    }
}
