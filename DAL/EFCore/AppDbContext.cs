using Backend_Architecture.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Backend_Architecture.DAL.EFCore
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<AboutSolution> AboutSolutions { get; set; }
        public DbSet<Fag> Fags { get; set; }    
        public DbSet<Service> Services { get; set; }   
        public DbSet<SubServices> SubServices { get; set; }
    }
}
