using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<Consulta> Consulta { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Port=5432;Database=WhiteTooth;" +
                "User Id=postgres;" +
                "Password=admin;"
                ));
        }

    }
}
