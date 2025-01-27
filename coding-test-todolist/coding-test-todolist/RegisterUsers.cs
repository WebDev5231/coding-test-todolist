using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace coding_test_todolist
{
    public class RegisterUsers
    {
        // Verifica se o nome de usuário já existe no banco de dados
        public bool IsUsernameExists(string username)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var query = "SELECT COUNT(1) FROM Users WHERE Username = @Username";
                return connection.ExecuteScalar<int>(query, new { Username = username }) > 0;
            }
        }

        // Método para registrar um novo usuário no banco de dados
        public void RegisterNewUser(string username, string password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var query = "INSERT INTO Users (Username, PasswordHash) VALUES (@Username, @Password)";
                connection.Execute(query, new { Username = username, Password = password });
            }
        }
    }

}