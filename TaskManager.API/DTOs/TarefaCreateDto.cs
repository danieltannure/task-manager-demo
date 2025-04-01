using System.ComponentModel.DataAnnotations;

namespace TaskManager.API.DTOs
{
    public class TarefaCreateDto
    {
        [Required]
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataEntrega { get; set; }
        [Required]
        public string Dificuldade { get; set; }
        public bool Concluida { get; set; }
        [Required]
        public int? ResponsavelId { get; set; }
    }
}
