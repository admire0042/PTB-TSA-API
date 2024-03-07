using ApplicationServices.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Persistence.DBContexts
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<TSAReport> TSAReports { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            OnBeforeSaveChanges();
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        private void OnBeforeSaveChanges()
        {
            ChangeTracker.DetectChanges();
            foreach (var entry in ChangeTracker.Entries<Entity>().ToList())
            {
                if (entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;

                foreach (var property in entry.Properties)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.DateAdded = DateTime.Now;
                            break;
                        case EntityState.Deleted:
                            entry.Entity.IsDeleted = true;
                            entry.State = EntityState.Modified;
                            break;
                        case EntityState.Modified:
                            entry.Entity.DateModified = DateTime.Now;
                            break;
                    }
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}