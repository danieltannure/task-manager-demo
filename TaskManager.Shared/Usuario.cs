using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Shared
{
    [Table("dbo.usuarios")]
    public class Usuario
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("username")]
        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Column("password")]
        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        // Relacionamento com Tarefas
        public ICollection<Tarefa> Tarefas { get; set; }
    }
}
