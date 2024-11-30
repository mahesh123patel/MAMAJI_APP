using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MAMAJI_APP.Class
{
    public class DesignationManager
    {
        private string connectionString;

        public DesignationManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void InsertDesignation(Designation designation)
        {
            ExecuteNonQuery("INSERT", designation);
        }

        public void UpdateDesignation(Designation designation)
        {
            ExecuteNonQuery("UPDATE", designation);
        }

        public void DeleteDesignation(decimal designationID)
        {
            ExecuteNonQuery("DELETE", new Designation { DesignationID = designationID });
        }

        //public List<Designation> GetDesignations(decimal? designationID = null)
        //{
        //    List<Designation> designations = new List<Designation>();

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("sp_ManageDesignation", conn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@Action", "SELECT");
        //            cmd.Parameters.AddWithValue("@DesignationID", designationID.HasValue ? (object)designationID.Value : DBNull.Value);

        //            conn.Open();

        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    Designation designation = new Designation
        //                    {
        //                        DesignationID = reader.GetDecimal(reader.GetOrdinal("DesignationID")),
        //                        DesignationName = reader.GetString(reader.GetOrdinal("DesignationName")),
        //                        CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
        //                        CreatedBy = reader.GetDecimal(reader.GetOrdinal("CreatedBy")),
        //                        ISBlocked = reader.GetString(reader.GetOrdinal("ISBlocked"))
        //                    };

        //                    designations.Add(designation);
        //                }
        //            }
        //        }
        //    }

        //    return designations;
        //}

        public List<Designation> GetDesignations(string designationID = null)
        {
            List<Designation> designations = new List<Designation>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ManageDesignation", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "SELECT");
                    cmd.Parameters.AddWithValue("@DesignationID", (designationID!=null)? (object)designationID : DBNull.Value);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Designation designation = new Designation();

                            designation.DesignationID = reader.IsDBNull(reader.GetOrdinal("DesignationID")) ? 0 : reader.GetDecimal(reader.GetOrdinal("DesignationID"));
                            designation.DesignationName = reader.IsDBNull(reader.GetOrdinal("DesignationName")) ? null : reader.GetString(reader.GetOrdinal("DesignationName"));
                            designation.CreatedDate = reader.IsDBNull(reader.GetOrdinal("CreatedDate")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("CreatedDate"));
                            designation.CreatedBy = reader.IsDBNull(reader.GetOrdinal("CreatedBy")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CreatedBy"));
                            designation.ISBlocked = reader.IsDBNull(reader.GetOrdinal("ISBlocked")) ? null : reader.GetString(reader.GetOrdinal("ISBlocked"));

                            designations.Add(designation);
                        }
                    }
                }
            }

            return designations;
        }


        private void ExecuteNonQuery(string action, Designation designation)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ManageDesignation", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", action);
                    cmd.Parameters.AddWithValue("@DesignationID", designation.DesignationID != 0 ? (object)designation.DesignationID : DBNull.Value);
                    cmd.Parameters.AddWithValue("@DesignationName", designation.DesignationName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedBy", designation.CreatedBy != 0 ? (object)designation.CreatedBy : DBNull.Value);
                    cmd.Parameters.AddWithValue("@ISBlocked", designation.ISBlocked ?? (object)DBNull.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
    public class Designation
    {
        public decimal DesignationID { get; set; }
        public string DesignationName { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal CreatedBy { get; set; }
        public string ISBlocked { get; set; }
    }
}