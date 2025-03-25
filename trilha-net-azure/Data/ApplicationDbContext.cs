using Microsoft.EntityFrameworkCore;
using trilha_net_azure.Models.DbHrContext;

namespace trilha_net_azure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Log> Log { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.Email)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
