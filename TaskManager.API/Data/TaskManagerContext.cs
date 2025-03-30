using Microsoft.EntityFrameworkCore;
using TaskManager.Shared;

namespace TaskManager.API.Data
{
    public class TaskManagerContext : DbContext
    {
        // Construtor que recebe as opções via injeção de dependência
        public TaskManagerContext(DbContextOptions<TaskManagerContext> options)
            : base(options)
        {
        }

        // DbSets que representam as tabelas do banco
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeia os nomes das tabelas do banco explicitamente
            modelBuilder.Entity<Usuario>().ToTable("usuarios");
            modelBuilder.Entity<Tarefa>().ToTable("tarefas");
        }
    }
}
