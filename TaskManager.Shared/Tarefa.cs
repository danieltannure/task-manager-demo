using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Shared
{
    [Table("dbo.tarefas")]
    public class Tarefa
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("titulo")]
        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }

        [Column("descricao")]
        [StringLength(255)]
        public string Descricao { get; set; }

        [Column("data_entrega")]
        public DateTime? DataEntrega { get; set; }

        [Column("responsavel_id")]
        public int? ResponsavelId { get; set; }

        [Column("dificuldade")]
        [StringLength(20)]
        public string Dificuldade { get; set; }

        [Column("concluida")]
        public bool Concluida { get; set; }

        // Navegação para o Usuário responsável
        public Usuario Responsavel { get; set; }
    }
}
