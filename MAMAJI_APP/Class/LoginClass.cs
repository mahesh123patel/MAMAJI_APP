using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MAMAJI_APP.Class
{
    public class LoginClass
    {
         private string connectionString;

         public LoginClass(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<PersonInfo> LoginUser(string UserID ,string Password)
        {
            List<PersonInfo> personInfos = new List<PersonInfo>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_loginUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@userid", UserID);
                    cmd.Parameters.AddWithValue("@password", Password);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PersonInfo personInfo = new PersonInfo
                            {
                                PersonInfoID = reader.GetDecimal(reader.GetOrdinal("PersonInfoID")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Mobile = reader.GetString(reader.GetOrdinal("Mobile")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                Address = reader.GetString(reader.GetOrdinal("Address")),
                                DistrictID = reader.IsDBNull(reader.GetOrdinal("DistrictID")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("DistrictID")),
                                BlockID = reader.IsDBNull(reader.GetOrdinal("BlockID")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("BlockID")),
                                DesignationID = reader.IsDBNull(reader.GetOrdinal("DesignationID")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("DesignationID")),
                                CreatedBy = reader.GetDecimal(reader.GetOrdinal("CreatedBy")),
                                CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
                                ISBlocked = reader.GetString(reader.GetOrdinal("ISBlocked")),
                                UserID = reader.GetString(reader.GetOrdinal("UserID")),
                                Password = reader.GetString(reader.GetOrdinal("Password")),
                                DistrictName = reader.GetString(reader.GetOrdinal("DistrictName")),
                                BlockName = reader.GetString(reader.GetOrdinal("BlockName")),
                                DesignationName = reader.GetString(reader.GetOrdinal("DesignationName"))
                            };

                            personInfos.Add(personInfo);
                        }
                    }
                }
            }

            return personInfos;
        }
    }
  
}