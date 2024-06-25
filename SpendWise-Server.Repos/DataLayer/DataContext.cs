using Microsoft.EntityFrameworkCore;
using SpendWise_Server.Models;

namespace SpendWise_Server.Repos.DataLayer
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users").HasKey(k => k.Id);
        }
    }
}
