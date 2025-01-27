using System.ComponentModel.DataAnnotations.Schema;

namespace coding_test_todolist_web_api.Models
{
    [Table("Tarefas")]
    public class Tarefas
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataTermino { get; set; }
    }
}
