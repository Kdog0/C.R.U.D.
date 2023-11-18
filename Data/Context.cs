using Microsoft.EntityFrameworkCore;
using prova.models;

namespace prova.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Aluno> Alunos { get; set; }
    }
}
