using ProjectTest.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjectTest.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Candidat> Candidats { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Candidat>().ToTable("candidats");
        }
    }
}
