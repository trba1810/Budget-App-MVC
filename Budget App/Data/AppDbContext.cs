using Microsoft.EntityFrameworkCore;

namespace Budget_App.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


    }
}
