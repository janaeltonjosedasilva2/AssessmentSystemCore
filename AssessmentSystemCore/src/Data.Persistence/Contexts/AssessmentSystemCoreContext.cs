using AssessmentSystemCore.Data.Persistence.Configurations;
using AssessmentSystemCore.Domain.Core.Entities;
using AssessmentSystemCore.Domain.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentSystemCore.Data.Persistence.Contexts
{
    public class AssessmentSystemCoreContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AssessmentSystemCoreContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public AssessmentSystemCoreContext(string connectionString) : base(new DbContextOptionsBuilder().UseSqlServer(connectionString).Options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            ChangeTracker
                .Entries()
                .Where(t => t.State == EntityState.Modified)
                .Select(t => t.Entity as Entity)
                .AsParallel()
                .ForAll(entity => entity.LastUpdate = DateTime.Now);

            return base.SaveChanges();
        }
    }
}
