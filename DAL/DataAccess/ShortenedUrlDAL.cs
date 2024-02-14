using System;
using System.Data.SqlClient;

namespace DAL.DataAccess
{
    /* 
        Basic DAL using SqlCommands just to get things going as quickly/simply as possible.
    */
    public class ShortenedUrlDAL
    {
        /* Improvements: Connection string must be in the config file. */
        string connectionString = "Data Source=DESKTOP-ODH78VQ\\SQLEXPRESS;Initial Catalog=PayrocUrlShortner;Integrated Security=True;";

        /* Improvements: Error handling incase DB communication fails for whatever reason. */
        public void SaveShortenedUrl(string longUrl, string token)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO dbo.ShortenedUrl (LongUrl,Token,DateCreated) VALUES (@longUrl, @token, @dateCreated)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@longUrl", longUrl);
                    command.Parameters.AddWithValue("@token", token);
                    command.Parameters.AddWithValue("@dateCreated", DateTime.Now);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                }
            }
        }

        public string GetLongUrl(string token)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = $"SELECT * FROM dbo.ShortenedUrl WHERE Token = '{token}'";

                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader["LongUrl"].ToString();
                        }
                        else
                        {
                            return string.Empty;
                        }
                    }
                }
            }
        }

        public bool IsUniqueToken(string token)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = $"SELECT * FROM dbo.ShortenedUrl WHERE Token = '{token}'";

                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return !reader.HasRows;
                    }
                }
            }
        }
    }
}
