using ApiDotnet5SqliteSample.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiDotnet5SqliteSample.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite(connectionString: "DataSource=app.db;Cache=Shared");
    }
}