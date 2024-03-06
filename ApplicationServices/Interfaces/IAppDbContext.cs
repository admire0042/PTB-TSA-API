using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ApplicationServices.Interfaces
{
    public interface IAppDbContext
    {
        public DbSet<TSAReport> TSAReports { get; set; }
        public DbSet<NiBSSTSAReport> NiBSSTSAReports { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}