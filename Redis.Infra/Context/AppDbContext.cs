using Microsoft.EntityFrameworkCore;
using Redis.Business.Models;

namespace Redis.Infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {}

        public DbSet<Produto> Produtos {get; set;}
        public DbSet<Usuario> Users { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().Property(p => p.Id);
            modelBuilder.Entity<Produto>().Property(p => p.CreateAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Usuario>().Property(u => u.Id);
        }
    }
}