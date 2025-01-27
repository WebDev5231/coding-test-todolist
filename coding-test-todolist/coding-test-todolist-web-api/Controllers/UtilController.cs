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

        // Método para listar todas as tarefas
        [HttpGet("ListarTodasTarefas")]
        public IActionResult GetAllTasks()
        {
            using (var db = Connection)
            {
                string sql = "SELECT * FROM TAREFAS";
                var tasks = db.Query<Tarefas>(sql).ToList();
                return Ok(tasks);
            }
        }

        // Método para deletar uma tarefa
        [HttpDelete("DeletarTarefa/{id}")]
        public IActionResult DeleteTask(int id)
        {
            using (var db = Connection)
            {
                var task = db.QueryFirstOrDefault<Tarefas>("SELECT * FROM TAREFAS WHERE Id = @Id", new { Id = id });
                if (task == null)
                {
                    return NotFound(new { Message = "Tarefa não encontrada" });
                }

                string deleteSql = "DELETE FROM TAREFAS WHERE Id = @Id";
                var affectedRows = db.Execute(deleteSql, new { Id = id });

                if (affectedRows > 0)
                {
                    return Ok(new { Message = "Tarefa deletada com sucesso!" });
                }

                return BadRequest(new { Message = "Erro ao deletar a tarefa" });
            }
        }

        // Método para adicionar uma nova tarefa
        [HttpPost("AdicionarTarefa")]
        public IActionResult AddTask([FromBody] Tarefas task)
        {
            if (task == null || string.IsNullOrEmpty(task.Titulo) || string.IsNullOrEmpty(task.Descricao) || task.DataTermino == null)
            {
                return BadRequest(new { Message = "Todos os campos são obrigatórios" });
            }

            using (var db = Connection)
            {
                string insertSql = "INSERT INTO TAREFAS (Titulo, Descricao, DataTermino) VALUES (@Titulo, @Descricao, @DataTermino)";
                var affectedRows = db.Execute(insertSql, new { task.Titulo, task.Descricao, task.DataTermino });

                if (affectedRows > 0)
                {
                    return Ok(new { Message = "Tarefa adicionada com sucesso!" });
                }

                return BadRequest(new { Message = "Erro ao adicionar a tarefa" });
            }
        }
    }
}
