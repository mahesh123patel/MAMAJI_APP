using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MAMAJI_APP.Class
{
    public class Officer
    {
        public decimal OfficerID { get; set; }
        public string OfficerName { get; set; }
        public string OfficerMobile { get; set; }
        public string OfficerEmail { get; set; }
        public string OfficerDesignation { get; set; }
        public decimal OfficerDistrict { get; set; }
        public string OfficerDistrictName { get; set; }
        public decimal CreatedBY { get; set; }
        public DateTime CreatedDate { get; set; }
        public string IsBlocked { get; set; }
    }

    public class OfficerManager
    {
        private string connectionString;

        public OfficerManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void InsertOfficer(Officer officer)
        {
            ExecuteNonQuery("sp_InsertOfficerMaster", officer);
        }

        public void UpdateOfficer(Officer officer)
        {
            ExecuteNonQuery("sp_UpdateOfficerMaster", officer);
        }

        public void DeleteOfficer(decimal officerID)
        {
            ExecuteNonQuery("sp_DeleteOfficerMaster", new Officer { OfficerID = officerID });
        }

        public List<Officer> GetOfficers(decimal? officerID = null)
        {
            return ExecuteQuery("sp_SelectOfficerMaster", officerID);
        }

        private void ExecuteNonQuery(string storedProcedure, Officer officer)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (storedProcedure == "sp_UpdateOfficerMaster")
                        cmd.Parameters.AddWithValue("@OfficerID", officer.OfficerID != 0 ? (object)officer.OfficerID : DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@CreatedBY", officer.CreatedBY != 0 ? (object)officer.CreatedBY : DBNull.Value);
                    cmd.Parameters.AddWithValue("@OfficerName", officer.OfficerName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@OfficerMobile", officer.OfficerMobile ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@OfficerEmail", officer.OfficerEmail ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@OfficerDesignation", officer.OfficerDesignation ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@OfficerDistrict", officer.OfficerDistrict != 0 ? (object)officer.OfficerDistrict : DBNull.Value);
                    
                    cmd.Parameters.AddWithValue("@IsBlocked", officer.IsBlocked ?? (object)DBNull.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private List<Officer> ExecuteQuery(string storedProcedure, decimal? officerID)
        {
            List<Officer> officers = new List<Officer>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OfficerID", officerID.HasValue ? (object)officerID.Value : DBNull.Value);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Officer officer = new Officer
                            {
                                OfficerID = reader.GetDecimal(reader.GetOrdinal("OfficerID")),
                                OfficerName = reader.GetString(reader.GetOrdinal("OfficerName")),
                                OfficerMobile = reader.GetString(reader.GetOrdinal("OfficerMobile")),
                                OfficerEmail = reader.GetString(reader.GetOrdinal("OfficerEmail")),
                                OfficerDesignation = reader.GetString(reader.GetOrdinal("OfficerDesignation")),
                                OfficerDistrict = reader.GetDecimal(reader.GetOrdinal("OfficerDistrict")),
                                OfficerDistrictName = reader.GetString(reader.GetOrdinal("DistrictName")),
                                CreatedBY = reader.GetDecimal(reader.GetOrdinal("CreatedBY")),
                                CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
                                IsBlocked = reader.GetString(reader.GetOrdinal("IsBlocked"))
                            };

                            officers.Add(officer);
                        }
                    }
                }
            }

            return officers;
        }
    }
}