using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace pTriplanar
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> user_data { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=dataVault;Username=postgres;Password=C9s0v0yf");
        }
    }
}
