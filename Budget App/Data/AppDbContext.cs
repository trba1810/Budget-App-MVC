using Budget_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Budget_App.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().HasData(
                new Transaction() { Id = 1, Name = "Bills", Date = DateTime.Now, CategoryId = 1 }
                );

            modelBuilder.Entity<Category>().HasData(new Category() { Id = 1, Name = "Expences" }
            );
        }
    }
}
