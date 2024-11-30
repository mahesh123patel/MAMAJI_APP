using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MAMAJI_APP.Class
{
    public class District
    {
        public decimal DistrictID { get; set; }
        public string DistrictName { get; set; }
        public string DistrictHindiName { get; set; }
        public decimal CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ISBlocked { get; set; }
    }

    public class DistrictManager
    {
        private string connectionString;

        public DistrictManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void InsertDistrict(District district)
        {
            ExecuteNonQuery("INSERT", district);
        }

        public void UpdateDistrict(District district)
        {
            ExecuteNonQuery("UPDATE", district);
        }

        public void DeleteDistrict(decimal districtID)
        {
            ExecuteNonQuery("DELETE", new District { DistrictID = districtID });
        }

        public List<District> GetDistricts(decimal? districtID = null)
        {
            return ExecuteQuery("SELECT", districtID);
        }

        private void ExecuteNonQuery(string action, District district)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ManageDistrict", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", action);
                    cmd.Parameters.AddWithValue("@DistrictID", district.DistrictID != 0 ? (object)district.DistrictID : DBNull.Value);
                    cmd.Parameters.AddWithValue("@DistrictName", district.DistrictName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DistrictHindiName", district.DistrictHindiName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedBy", district.CreatedBy != 0 ? (object)district.CreatedBy : DBNull.Value);
                    cmd.Parameters.AddWithValue("@ISBlocked", district.ISBlocked ?? (object)DBNull.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private List<District> ExecuteQuery(string action, decimal? districtID)
        {
            List<District> districts = new List<District>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ManageDistrict", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", action);
                    cmd.Parameters.AddWithValue("@DistrictID", districtID.HasValue ? (object)districtID.Value : DBNull.Value);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            District district = new District
                            {
                                DistrictID = reader.GetDecimal(reader.GetOrdinal("DistrictID")),
                                DistrictName = reader.GetString(reader.GetOrdinal("DistrictName")),
                                DistrictHindiName = reader.GetString(reader.GetOrdinal("DistrictHindiName")),
                                CreatedBy = reader.GetDecimal(reader.GetOrdinal("CreatedBy")),
                                CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
                                ISBlocked = reader.GetString(reader.GetOrdinal("ISBlocked"))
                            };

                            districts.Add(district);
                        }
                    }
                }
            }

            return districts;
        }
    }

}