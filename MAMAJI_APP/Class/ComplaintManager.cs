using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MAMAJI_APP.Class
{
    public class Complaint
    {
        public decimal ComplaintID { get; set; }
        public string ComplaintName { get; set; }
        public string DistrictCode { get; set; }
        public string DistrictName { get; set; }
        public string VidhanShabhaCode { get; set; }
        public string VidhanShabhaName { get; set; }
        public string UpkhandCode { get; set; }
        public string UpkhandName { get; set; }
        public string BlockCode { get; set; }
        public string BlockName { get; set; }
        public string TahsilCode { get; set; }
        public string TahsilName { get; set; }
        public string ThanaCode { get; set; }
        public string ThanaName { get; set; }
        public string ComplaintAddress { get; set; }
        public decimal? ConTypeID { get; set; }
        public string ConType { get; set; }
        public string MobileNo { get; set; }
        public string Description { get; set; }
        public decimal? CreatedBY { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        public long AssignOfficerID { get; set; }
        public string ISBlocked { get; set; }
        public string OfficerName { get; set; }

    }

    public class ComplaintManager
    {
        private string connectionString;

        public ComplaintManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public string InsertComplaint(Complaint complaint)
        {
            return ExecuteScalar("INSERT", complaint);
        }

        public void UpdateComplaint(Complaint complaint)
        {
            ExecuteNonQuery("UPDATE", complaint);
        }

        public void DeleteComplaint(decimal complaintID)
        {
            ExecuteNonQuery("DELETE", new Complaint { ComplaintID = complaintID });
        }

        public List<Complaint> GetComplaints(decimal? complaintID = null)
        {
            return ExecuteQuery("SELECT", complaintID);
        }
        
        private void ExecuteNonQuery(string action, Complaint complaint)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ManageComplaint", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", action);
                    cmd.Parameters.AddWithValue("@ComplaintID", complaint.ComplaintID != 0 ? (object)complaint.ComplaintID : DBNull.Value);
                    cmd.Parameters.AddWithValue("@ComplaintName", complaint.ComplaintName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DistrictCode", complaint.DistrictCode ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@VidhanShabhaCode", complaint.VidhanShabhaCode?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@UpkhandCode", complaint.UpkhandCode ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@BlockCode", complaint.BlockCode ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TahsilCode", complaint.TahsilCode ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ThanaCode", complaint.ThanaCode ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ComplaintAddress", complaint.ComplaintAddress ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ConTypeID", complaint.ConTypeID.HasValue ? (object)complaint.ConTypeID.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@MobileNo", complaint.MobileNo ?? (object)DBNull.Value);
                    
                    cmd.Parameters.AddWithValue("@Description", complaint.Description ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedBY", complaint.CreatedBY.HasValue ? (object)complaint.CreatedBY.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Status", complaint.Status ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@AssignOfficerID", complaint.AssignOfficerID != 0 ? (object)complaint.AssignOfficerID : DBNull.Value);
                    cmd.Parameters.AddWithValue("@ISBlocked", complaint.ISBlocked ?? (object)DBNull.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private List<Complaint> ExecuteQuery(string action, decimal? complaintID)
        {
            List<Complaint> complaints = new List<Complaint>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ManageComplaint", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", action);
                    cmd.Parameters.AddWithValue("@ComplaintID", complaintID.HasValue ? (object)complaintID.Value : DBNull.Value);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Complaint complaint = new Complaint
                            {
                                ComplaintID = reader.GetDecimal(reader.GetOrdinal("ComplaintID")),
                                ComplaintName = reader.IsDBNull(reader.GetOrdinal("ComplaintName")) ? null : reader.GetString(reader.GetOrdinal("ComplaintName")),
                                DistrictCode = reader.IsDBNull(reader.GetOrdinal("DistrictCode")) ? null : reader.GetString(reader.GetOrdinal("DistrictCode")),
                                DistrictName = reader.IsDBNull(reader.GetOrdinal("DistrictName")) ? null : reader.GetString(reader.GetOrdinal("DistrictName")),
                                VidhanShabhaCode = reader.IsDBNull(reader.GetOrdinal("VidhanShabhaCode")) ? null : reader.GetString(reader.GetOrdinal("VidhanShabhaCode")),
                                VidhanShabhaName = reader.IsDBNull(reader.GetOrdinal("VidhanShabhaName")) ? null : reader.GetString(reader.GetOrdinal("VidhanShabhaName")),
                                UpkhandCode = reader.IsDBNull(reader.GetOrdinal("UpkhandCode")) ? null : reader.GetString(reader.GetOrdinal("UpkhandCode")),
                                UpkhandName = reader.IsDBNull(reader.GetOrdinal("UpkhandName")) ? null : reader.GetString(reader.GetOrdinal("UpkhandName")),
                                BlockCode = reader.IsDBNull(reader.GetOrdinal("BlockCode")) ? null : reader.GetString(reader.GetOrdinal("BlockCode")),
                                BlockName = reader.IsDBNull(reader.GetOrdinal("BlockName")) ? null : reader.GetString(reader.GetOrdinal("BlockName")),
                                TahsilCode = reader.IsDBNull(reader.GetOrdinal("TahsilCode")) ? null : reader.GetString(reader.GetOrdinal("TahsilCode")),
                                TahsilName = reader.IsDBNull(reader.GetOrdinal("TahsilName")) ? null : reader.GetString(reader.GetOrdinal("TahsilName")),
                                ThanaCode = reader.IsDBNull(reader.GetOrdinal("ThanaCode")) ? null : reader.GetString(reader.GetOrdinal("ThanaCode")),
                                ThanaName = reader.IsDBNull(reader.GetOrdinal("ThanaName")) ? null : reader.GetString(reader.GetOrdinal("ThanaName")),
                                ComplaintAddress = reader.IsDBNull(reader.GetOrdinal("ComplaintAddress")) ? null : reader.GetString(reader.GetOrdinal("ComplaintAddress")),
                                ConTypeID = reader.IsDBNull(reader.GetOrdinal("ConTypeID")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("ConTypeID")),
                                MobileNo = reader.IsDBNull(reader.GetOrdinal("MobileNo")) ? null : reader.GetString(reader.GetOrdinal("MobileNo")),
                                Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                                CreatedBY = reader.IsDBNull(reader.GetOrdinal("CreatedBY")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("CreatedBY")),
                                CreatedDate = reader.IsDBNull(reader.GetOrdinal("CreatedDate")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
                                Status = reader.IsDBNull(reader.GetOrdinal("Status")) ? null : reader.GetString(reader.GetOrdinal("Status")),
                                AssignOfficerID = reader.IsDBNull(reader.GetOrdinal("AssignOfficerID")) ? 0 : reader.GetInt64(reader.GetOrdinal("AssignOfficerID")),
                                ISBlocked = reader.IsDBNull(reader.GetOrdinal("ISBlocked")) ? null : reader.GetString(reader.GetOrdinal("ISBlocked")),
                                ConType = reader.IsDBNull(reader.GetOrdinal("ConType")) ? null : reader.GetString(reader.GetOrdinal("ConType")),
                                OfficerName = reader.IsDBNull(reader.GetOrdinal("OfficerName")) ? null : reader.GetString(reader.GetOrdinal("OfficerName")),
                            };

                            complaints.Add(complaint);
                        }
                    }
                }
            }

            return complaints;
        }
        //private List<Complaint> ExecuteQuery(string action, decimal? complaintID)
        //{
        //    List<Complaint> complaints = new List<Complaint>();

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("sp_ManageComplaint", conn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@Action", action);
        //            cmd.Parameters.AddWithValue("@ComplaintID", complaintID.HasValue ? (object)complaintID.Value : DBNull.Value);

        //            conn.Open();

        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    Complaint complaint = new Complaint
        //                    {
        //                        ComplaintID = reader.GetDecimal(reader.GetOrdinal("ComplaintID")),
        //                        ComplaintName = reader.GetString(reader.GetOrdinal("ComplaintName")),
        //                        DistrictCode = reader.GetString(reader.GetOrdinal("DistrictCode")),
        //                        BlockCode = reader.GetString(reader.GetOrdinal("BlockCode")),
        //                        ComplaintAddress = reader.GetString(reader.GetOrdinal("ComplaintAddress")),
        //                        ConTypeID = reader.IsDBNull(reader.GetOrdinal("ConTypeID")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("ConTypeID")),
        //                        MobileNo = reader.GetString(reader.GetOrdinal("MobileNo")),
        //                        Description = reader.GetString(reader.GetOrdinal("Description")),
        //                        CreatedBY = reader.IsDBNull(reader.GetOrdinal("CreatedBY")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("CreatedBY")),
        //                        CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
        //                        Status = reader.GetString(reader.GetOrdinal("Status")),
        //                        AssignOfficerID = reader.IsDBNull(reader.GetOrdinal("AssignOfficerID")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("AssignOfficerID")),
        //                        ISBlocked = reader.GetString(reader.GetOrdinal("ISBlocked")),
        //                        //DistrictHindiName = reader.GetString(reader.GetOrdinal("DistrictHindiName")),
        //                        //BlockHindiName = reader.GetString(reader.GetOrdinal("BlockHindiName")),
        //                        ConType = reader.GetString(reader.GetOrdinal("ConType")),
        //                        OfficerName = reader.GetString(reader.GetOrdinal("OfficerName")),
        //                    };

        //                    complaints.Add(complaint);
        //                }
        //            }
        //        }
        //    }

        //    return complaints;
        //}

        private string ExecuteScalar(string action, Complaint complaint)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ManageComplaint", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", action);
                    cmd.Parameters.AddWithValue("@ComplaintID", complaint.ComplaintID != 0 ? (object)complaint.ComplaintID : DBNull.Value);
                    cmd.Parameters.AddWithValue("@ComplaintName", complaint.ComplaintName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@BlockCode", complaint.BlockCode ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DistrictCode", complaint.DistrictCode ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TahsilCode", complaint.TahsilCode ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ThanaCode", complaint.ThanaCode ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@UpkhandCode", complaint.UpkhandCode ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@VidhanShabhaCode", complaint.VidhanShabhaCode ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ComplaintAddress", complaint.ComplaintAddress ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ConTypeID", complaint.ConTypeID.HasValue ? (object)complaint.ConTypeID.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@MobileNo", complaint.MobileNo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Description", complaint.Description ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedBY", complaint.CreatedBY.HasValue ? (object)complaint.CreatedBY.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Status", complaint.Status ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@AssignOfficerID", complaint.AssignOfficerID!=0 ? (object)complaint.AssignOfficerID : DBNull.Value);
                    cmd.Parameters.AddWithValue("@ISBlocked", complaint.ISBlocked ?? (object)DBNull.Value);

                    conn.Open();
                    return cmd.ExecuteScalar().ToString();
                }
            }
        }
    }
}