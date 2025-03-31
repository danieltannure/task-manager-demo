namespace TaskManager.API.DTOs
{
    public class TarefaDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataEntrega { get; set; }
        public string Dificuldade { get; set; }
        public bool Concluida { get; set; }
        public int? ResponsavelId { get; set; }
    }
}
