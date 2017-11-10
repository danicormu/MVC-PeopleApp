using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using PeopleApp.Models;


namespace PeopleApp.Data
{
    public class UserDB
    {
        //Connection String from Web Config
        private string cs = ConfigurationManager.ConnectionStrings["signup"].ConnectionString;


        //Add User
        public int AddUser(Users us)
        {
            int i = 0;
            SqlConnection conn = new SqlConnection(cs);
            try {
                conn.Open();
                SqlCommand query = new SqlCommand("Insert_user", conn);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.AddWithValue("@Username", us.Username);
                query.Parameters.AddWithValue("@Name", us.Name);
                query.Parameters.AddWithValue("@Surname1", us.Surname1);
                query.Parameters.AddWithValue("@Surname2", us.Surname2);
                query.Parameters.AddWithValue("@Phone", us.Phone);
                query.Parameters.AddWithValue("@Address1", us.Address);
                query.Parameters.AddWithValue("@Active", us.Active);
                i = query.ExecuteNonQuery();                              
            }
            catch (SqlException e) {
                Console.WriteLine(e.Message);
            }
            finally {
                conn.Close();
            }
            return i;
        }

        //Retrieve all user
        public List<Users> GetAllUser()
        {
            List<Users> list = new List<Users>();
            SqlConnection conn = new SqlConnection(cs);
            try {
                conn.Open();
                SqlCommand query = new SqlCommand("RetrieveAll_user", conn);
                query.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Users
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Username = reader["Username"].ToString(),
                        Name = reader["Name"].ToString(),
                        Surname1 = reader["Surname1"].ToString(),
                        Surname2 = reader["Surname2"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Address = reader["Address1"].ToString(),
                        Active = Convert.ToBoolean(reader["Active"]),
                    });
                }
            }
            catch (SqlException e) {
                Console.WriteLine(e.Message);
            }
            finally {
                conn.Close();
            }            
            return list;
        }

        //Retrieve by Id
        public Users RetrieveById(int id)
        {
            Users us = null;
            SqlConnection conn = new SqlConnection(cs);
            try {
                conn.Open();
                SqlCommand query = new SqlCommand("RetrieveById_user", conn);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = query.ExecuteReader();
                reader.Read();
                us = new Users(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetBoolean(7));
            }
            catch (SqlException e) {
                Console.WriteLine(e.Message);
            }
            finally {
                conn.Close();
            }
            return us;
        }

        //Update
        public int UpdateUser(Users us)
        {
            int i = 0;
            SqlConnection conn = new SqlConnection(cs);
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("Update_user");
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.AddWithValue("@Id", us.Id);
                query.Parameters.AddWithValue("@Username", us.Username);
                query.Parameters.AddWithValue("@Name", us.Name);
                query.Parameters.AddWithValue("@Surname1", us.Surname1);
                query.Parameters.AddWithValue("@Surname2", us.Surname2);
                query.Parameters.AddWithValue("@Phone", us.Phone);
                query.Parameters.AddWithValue("@Address1", us.Address);
                query.Parameters.AddWithValue("@Active", us.Active);
                i = query.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return i;
        }

        //Delete
        public int DeleteUser()
        {
            int i = 0;
            SqlConnection conn = new SqlConnection(cs);
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("Delete_user", conn);
                query.CommandType = CommandType.StoredProcedure;
                i = query.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return i;
        }

        //Delete By Id
        public int DeleteUserById(int id)
        {
            int i = 0;
            SqlConnection conn = new SqlConnection(cs);
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("DeleteById_user", conn);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.AddWithValue("@Id", id);
                i = query.ExecuteNonQuery();
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return i;
        }

    }
}