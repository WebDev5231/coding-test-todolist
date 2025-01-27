using coding_test_todolist_web_api.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace coding_test_todolist_web_api.Controllers
{
    public class UtilController : Controller
    {
        private readonly string _connectionString;

        public UtilController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new ArgumentNullException("DefaultConnection", "Connection string is required");
        }

        private IDbConnection Connection => new SqlConnection(_connectionString);

        [HttpGet("ListarTodasTarefas")]
        public IActionResult GetTaskById()
        {
            using (var db = Connection)
            {
                string sql = "SELECT * FROM TAREFAS";
                var tasks = db.Query<Tarefas>(sql).ToList();
                return Ok(tasks);
            }
        }
    }
}
