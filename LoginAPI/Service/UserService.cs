using LoginApi.Models;
using LoginApi.Service.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace LoginApi.Service
{
    public class UserService : IUser
    {

        private readonly string _connectionString;
        public UserService(string connectionString) 
        { 
            _connectionString = connectionString;
        }

        public void CreateUser(User user)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("Proc_CreateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Username", user.UserName);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Delete(string id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE id = "+ id, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public User GetUser(string username, string password)
        {
            User user = new User();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string sqlQuery = "SELECT * FROM Student WHERE username= " + username + " AND password="+ password;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    user.Id = new Guid(rdr["id"].ToString());
                    user.Name = rdr["name"].ToString();
                    user.UserName = rdr["username"].ToString();
                    user.Password = rdr["password"].ToString();
                }
            }
            return user;
        }

        public void UpdateUser(User user)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("Proc_UpdateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", user.Id);
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Username", user.UserName);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
