using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MAMAJI_APP.Class
{
    public class Block
    {
        public decimal BlockID { get; set; }
        public string BlockName { get; set; }
        public string BlockHindiName { get; set; }
        public decimal? DistrictID { get; set; }
        public decimal? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ISBlocked { get; set; }
    }

    public class BlockManager
    {
        private string connectionString;

        public BlockManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void InsertBlock(Block block)
        {
            ExecuteNonQuery("INSERT", block);
        }

        public void UpdateBlock(Block block)
        {
            ExecuteNonQuery("UPDATE", block);
        }

        public void DeleteBlock(decimal blockID)
        {
            ExecuteNonQuery("DELETE", new Block { BlockID = blockID });
        }

        //public List<Block> GetBlocks(decimal? blockID = null)
        public List<Block> GetBlocks(string DistId = null)
        {
            return ExecuteQuery("SELECT", DistId);
        }

        private void ExecuteNonQuery(string action, Block block)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ManageBlock", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", action);
                    cmd.Parameters.AddWithValue("@BlockID", block.BlockID != 0 ? (object)block.BlockID : DBNull.Value);
                    cmd.Parameters.AddWithValue("@BlockName", block.BlockName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@BlockHindiName", block.BlockHindiName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DistrictID", block.DistrictID.HasValue ? (object)block.DistrictID.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedBy", block.CreatedBy.HasValue ? (object)block.CreatedBy.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@ISBlocked", block.ISBlocked ?? (object)DBNull.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //private List<Block> ExecuteQuery(string action, decimal? blockID)
        private List<Block> ExecuteQuery(string action, string DistId)
        {
            List<Block> blocks = new List<Block>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ManageBlock", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", action);
                    //cmd.Parameters.AddWithValue("@BlockID", blockID.HasValue ? (object)blockID.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@BlockID", DistId);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Block block = new Block
                            {
                                BlockID = reader.GetDecimal(reader.GetOrdinal("BlockID")),
                                BlockName = reader.GetString(reader.GetOrdinal("BlockName")),
                                BlockHindiName = reader.GetString(reader.GetOrdinal("BlockHindiName")),
                                DistrictID = reader.IsDBNull(reader.GetOrdinal("DistrictID")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("DistrictID")),
                                CreatedBy = reader.IsDBNull(reader.GetOrdinal("CreatedBy")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("CreatedBy")),
                                CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
                                ISBlocked = reader.GetString(reader.GetOrdinal("ISBlocked"))
                            };

                            blocks.Add(block);
                        }
                    }
                }
            }

            return blocks;
        }
    }
}