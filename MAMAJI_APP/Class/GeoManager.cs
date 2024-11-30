using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace MAMAJI_APP.Class
{
    public class Geo
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Parent { get; set; }
        public string Name { get; set; }
        public string GeoCode { get; set; }       

    }

    public class GeoManager
    {
        private string connectionString;

        public GeoManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Geo> GetStates(string code)
        {
            return ExecuteQuery("STATE",code);
        }
        public List<Geo> GetDistrict(string code)
        {
            return ExecuteQuery("DISTRICT", code);
        }
        public List<Geo> GetVidhanshabha(string code = null)
        {
            return ExecuteQuery("VIDHANSHABHA", code);
        }
        public List<Geo> GetUpkhand(string code = null)
        {
            return ExecuteQuery("UPKHAND", code);
        }
        public List<Geo> GetBlock(string code = null)
        {
            return ExecuteQuery("BLOCK", code);
        }
        public List<Geo> GetTahsil(string code = null)
        {
            return ExecuteQuery("TAHSIL", code);
        }
        public List<Geo> GetThana(string code = null)
        {
            return ExecuteQuery("THANA", code);
        }
        public List<Geo> GetVillage(string code = null)
        {
            return ExecuteQuery("VILLAGE", code);
        }
        public List<Geo> GetVillPanchayat(string code = null)
        {
            return ExecuteQuery("VILLPANCHAYAT", code);
        }
        private List<Geo> ExecuteQuery(string action, string code)
        {
            List<Geo> geos = new List<Geo>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ManageGeo", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", action);
                    cmd.Parameters.AddWithValue("@Code", code);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Geo geo = new Geo
                            {
                                Id = reader.GetInt64(reader.GetOrdinal("Id")),
                                Code = reader.GetString(reader.GetOrdinal("Code")),
                                Parent = reader.GetString(reader.GetOrdinal("Parent")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                GeoCode = reader.GetString(reader.GetOrdinal("GeoCode"))
                            };

                            geos.Add(geo);
                        }
                    }
                }
            }

            return geos;
        }
        
    }
}