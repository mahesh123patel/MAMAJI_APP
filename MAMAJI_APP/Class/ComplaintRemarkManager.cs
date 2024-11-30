using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MAMAJI_APP.Class
{
    public class ComplaintRemark
    {
        public decimal ComplaintRemarkID { get; set; }
        public decimal ComplaintID { get; set; }
        public decimal RemarkBy { get; set; }
        public string Remark { get; set; }
        public string CurrentStatus { get; set; }
        public DateTime RemarkDate { get; set; }
        public string ISBlocked { get; set; }
    }

    public class ComplaintRemarkManager
    {
        private readonly string _connectionString;

        public ComplaintRemarkManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void InsertComplaintRemark(ComplaintRemark remark)
        {
            ExecuteNonQuery("INSERT", remark);
        }

        public void UpdateComplaintRemark(ComplaintRemark remark)
        {
            ExecuteNonQuery("UPDATE", remark);
        }

        public void DeleteComplaintRemark(decimal complaintRemarkID)
        {
            ExecuteNonQuery("DELETE", new ComplaintRemark { ComplaintRemarkID = complaintRemarkID });
        }

        public List<ComplaintRemark> GetComplaintRemarks(decimal? complaintID = null)
        {
            return ExecuteQuery("SELECT", complaintID);
        }

        private void ExecuteNonQuery(string action, ComplaintRemark remark)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ManageComplaintRemark", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", action);
                    cmd.Parameters.AddWithValue("@ComplaintRemarkID", remark.ComplaintRemarkID != 0 ? (object)remark.ComplaintRemarkID : DBNull.Value);
                    cmd.Parameters.AddWithValue("@ComplaintID", remark.ComplaintID != 0 ? (object)remark.ComplaintID : DBNull.Value);
                    cmd.Parameters.AddWithValue("@RemarkBy", remark.RemarkBy != 0 ? (object)remark.RemarkBy : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Remark", remark.Remark ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CurrentStatus", remark.CurrentStatus ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ISBlocked", remark.ISBlocked ?? (object)DBNull.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private List<ComplaintRemark> ExecuteQuery(string action, decimal? complaintID)
        {
            List<ComplaintRemark> remarks = new List<ComplaintRemark>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ManageComplaintRemark", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", action);
                    cmd.Parameters.AddWithValue("@ComplaintID", complaintID.HasValue ? (object)complaintID.Value : DBNull.Value);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ComplaintRemark remark = new ComplaintRemark
                            {
                                ComplaintRemarkID = reader.GetDecimal(reader.GetOrdinal("ComplaintRemarkID")),
                                ComplaintID = reader.GetDecimal(reader.GetOrdinal("ComplaintID")),
                                RemarkBy = reader.GetDecimal(reader.GetOrdinal("RemarkBy")),
                                Remark = reader.GetString(reader.GetOrdinal("Remark")),
                                CurrentStatus = reader.GetString(reader.GetOrdinal("CurrentStatus")),
                                RemarkDate = reader.GetDateTime(reader.GetOrdinal("RemarkDate")),
                                ISBlocked = reader.GetString(reader.GetOrdinal("ISBlocked"))
                            };

                            remarks.Add(remark);
                        }
                    }
                }
            }

            return remarks;
        }
    }

}