using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MAMAJI_APP.Class
{
    public class ConTypeManager
    {
        private string connectionString;

        public ConTypeManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void InsertConType(ConType conType)
        {
            ExecuteNonQuery("INSERT", conType);
        }

        public void UpdateConType(ConType conType)
        {
            ExecuteNonQuery("UPDATE", conType);
        }

        public void DeleteConType(decimal conTypeID)
        {
            ExecuteNonQuery("DELETE", new ConType { ConTypeID = conTypeID });
        }

        public List<ConType> GetConTypes(decimal? conTypeID = null)
        {
            return ExecuteQuery("SELECT", conTypeID);
        }

        private void ExecuteNonQuery(string action, ConType conType)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ManageConType", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", action);
                    cmd.Parameters.AddWithValue("@ConTypeID", conType.ConTypeID != 0 ? (object)conType.ConTypeID : DBNull.Value);
                    cmd.Parameters.AddWithValue("@ConType", conType.ConTypeName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedBy", conType.CreatedBy != 0 ? (object)conType.CreatedBy : DBNull.Value);
                    cmd.Parameters.AddWithValue("@ISBlocked", conType.ISBlocked ?? (object)DBNull.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private List<ConType> ExecuteQuery(string action, decimal? conTypeID)
        {
            List<ConType> conTypes = new List<ConType>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ManageConType", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", action);
                    cmd.Parameters.AddWithValue("@ConTypeID", conTypeID.HasValue ? (object)conTypeID.Value : DBNull.Value);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ConType conType = new ConType
                            {
                                ConTypeID = reader.GetDecimal(reader.GetOrdinal("ConTypeID")),
                                ConTypeName = reader.GetString(reader.GetOrdinal("ConType")),
                                CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
                                CreatedBy = reader.GetDecimal(reader.GetOrdinal("CreatedBy")),
                                ISBlocked = reader.GetString(reader.GetOrdinal("ISBlocked"))
                            };

                            conTypes.Add(conType);
                        }
                    }
                }
            }

            return conTypes;
        }
    }
    public class ConType
    {
        public decimal ConTypeID { get; set; }
        public string ConTypeName { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal CreatedBy { get; set; }
        public string ISBlocked { get; set; }
    }

}