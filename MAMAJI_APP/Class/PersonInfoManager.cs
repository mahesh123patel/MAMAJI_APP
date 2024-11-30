using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MAMAJI_APP.Class
{
    public class PersonInfoManager
    {
        private string connectionString;

        public PersonInfoManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public string InsertPersonInfo(PersonInfo personInfo)
        {
            string s = "";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertPersonInfo", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", personInfo.Name ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Mobile", personInfo.Mobile ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", personInfo.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", personInfo.Address ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DistrictID", personInfo.DistrictID.HasValue ? (object)personInfo.DistrictID : DBNull.Value);
                    cmd.Parameters.AddWithValue("@BlockID", personInfo.BlockID.HasValue ? (object)personInfo.BlockID : DBNull.Value);
                    cmd.Parameters.AddWithValue("@DesignationID", personInfo.DesignationID.HasValue ? (object)personInfo.DesignationID : DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedBy", personInfo.CreatedBy != 0 ? (object)personInfo.CreatedBy : DBNull.Value);
                    cmd.Parameters.AddWithValue("@ISBlocked", personInfo.ISBlocked ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@UserID", personInfo.UserID);
                    cmd.Parameters.AddWithValue("@Password", personInfo.Password);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                             s = Convert.ToString(reader.GetInt64(reader.GetOrdinal("Status")));
                        }
                        
                    }
                }
            }
            if(s == "3")
            {
                return "This User is Already Register";
            }
            else if(s == "0")
            {
                return "User Not Registered successfully";
            }
            else
            {
                return "User Registered successfully";
            }
        }

        public string UpdatePersonInfo(PersonInfo personInfo)
        {
            int s = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdatePersonInfo", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PersonInfoID", personInfo.PersonInfoID);
                    cmd.Parameters.AddWithValue("@Name", personInfo.Name ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Mobile", personInfo.Mobile ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", personInfo.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", personInfo.Address ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DistrictID", personInfo.DistrictID.HasValue ? (object)personInfo.DistrictID : DBNull.Value);
                    cmd.Parameters.AddWithValue("@BlockID", personInfo.BlockID.HasValue ? (object)personInfo.BlockID : DBNull.Value);
                    cmd.Parameters.AddWithValue("@DesignationID", personInfo.DesignationID.HasValue ? (object)personInfo.DesignationID : DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedBy", personInfo.CreatedBy != 0 ? (object)personInfo.CreatedBy : DBNull.Value);
                    cmd.Parameters.AddWithValue("@ISBlocked", personInfo.ISBlocked ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@UserID", personInfo.UserID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Password", personInfo.Password ?? (object)DBNull.Value);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            s = reader.GetInt32(reader.GetOrdinal("Status"));
                        }
                    }
                }
            }
            if(s==-1)
            {
                return "This UserID is Already Registered.";
            }
            else if(s==0)
            {
                return "User Profile Not Updated Successfully.";
            }
            else{
                return "User Profile Updated Successfully.";
            }
        }

        public void DeletePersonInfo(decimal personInfoID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_DeletePersonInfo", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PersonInfoID", personInfoID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<PersonInfo> GetPersonInfos(decimal? personInfoID = null)
        {
            List<PersonInfo> personInfos = new List<PersonInfo>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetPersonInfo", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (personInfoID.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@PersonInfoID", personInfoID.Value);
                    }

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

    public class PersonInfo
    {
        public decimal PersonInfoID { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public decimal? DistrictID { get; set; }
        public decimal? BlockID { get; set; }
        public decimal? DesignationID { get; set; }
        public decimal CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ISBlocked { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public string DistrictName { get; set; }
        public string BlockName { get; set; }
        public string DesignationName { get; set; }
    }
}