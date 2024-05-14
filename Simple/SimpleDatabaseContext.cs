using Microsoft.EntityFrameworkCore;
using Simple.Models;

namespace Simple
{
    public class SimpleDatabaseContext : DbContext
    {
        public SimpleDatabaseContext(DbContextOptions<SimpleDatabaseContext> dbContextOptions) : base(dbContextOptions)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Simple");
        }

        public DbSet<Student> Student { get; set; }
    }
}
