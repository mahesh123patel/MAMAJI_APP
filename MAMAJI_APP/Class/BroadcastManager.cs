using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MAMAJI_APP.Class
{
    public class BroadcastManager
    {
        private string connectionString;

        public BroadcastManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void InsertBroadcast(Broadcast broadcast)
        {
            ExecuteNonQuery("INSERT", broadcast);
        }

        public void UpdateBroadcast(Broadcast broadcast)
        {
            ExecuteNonQuery("UPDATE", broadcast);
        }

        public void DeleteBroadcast(decimal broadcastID)
        {
            ExecuteNonQuery("DELETE", new Broadcast { BroadcastID = broadcastID });
        }

        public void UpdateReleaseStatus(decimal broadcastID, string releaseStatus, DateTime? releaseDate = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_UpdateReleaseStatus", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BroadcastID", broadcastID);
                    cmd.Parameters.AddWithValue("@ReleaseStatus", releaseStatus);
                    cmd.Parameters.AddWithValue("@ReleaseDate", releaseDate ?? (object)DBNull.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Broadcast> GetBroadcasts(decimal? broadcastID = null)
        {
            return ExecuteQuery("SELECT", broadcastID);
        }

        private void ExecuteNonQuery(string action, Broadcast broadcast)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ManageBroadcast", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", action);
                    cmd.Parameters.AddWithValue("@BroadcastID", broadcast.BroadcastID != 0 ? (object)broadcast.BroadcastID : DBNull.Value);
                    cmd.Parameters.AddWithValue("@BroadcastType", broadcast.BroadcastType != 0 ? (object)broadcast.BroadcastType : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Broadcast", broadcast.BroadcastContent ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@BroadcastDate", broadcast.BroadcastDate != DateTime.MinValue ? (object)broadcast.BroadcastDate : DBNull.Value);
                    cmd.Parameters.AddWithValue("@BroadcastRemark", broadcast.BroadcastRemark ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@BroadcastStatus", broadcast.BroadcastStatus ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ReleaseStatus", broadcast.ReleaseStatus ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ReleaseDate", broadcast.ReleaseDate != DateTime.MinValue ? (object)broadcast.ReleaseDate : DBNull.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private List<Broadcast> ExecuteQuery(string action, decimal? broadcastID)
        {
            List<Broadcast> broadcasts = new List<Broadcast>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ManageBroadcast", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", action);
                    cmd.Parameters.AddWithValue("@BroadcastID", broadcastID.HasValue ? (object)broadcastID.Value : DBNull.Value);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Broadcast broadcast = new Broadcast
                            {
                                BroadcastID = reader.GetDecimal(reader.GetOrdinal("BroadcastID")),
                                BroadcastType = reader.GetDecimal(reader.GetOrdinal("BroadcastType")),
                                BroadcastContent = reader.GetString(reader.GetOrdinal("Broadcast")),
                                BroadcastDate = reader.GetDateTime(reader.GetOrdinal("BroadcastDate")),
                                BroadcastRemark = reader.GetString(reader.GetOrdinal("BroadcastRemark")),
                                BroadcastStatus = reader.GetString(reader.GetOrdinal("BroadcastStatus")),
                                ReleaseStatus = reader.GetString(reader.GetOrdinal("ReleaseStatus")),
                                ReleaseDate = reader.GetDateTime(reader.GetOrdinal("ReleaseDate"))
                            };

                            broadcasts.Add(broadcast);
                        }
                    }
                }
            }

            return broadcasts;
        }
    }
    public class Broadcast
    {
        public decimal BroadcastID { get; set; }
        public decimal BroadcastType { get; set; }
        public string BroadcastContent { get; set; }
        public DateTime BroadcastDate { get; set; }
        public string BroadcastRemark { get; set; }
        public string BroadcastStatus { get; set; }
        public string ReleaseStatus { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}