using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Persistence.Configurations
{
    public class TSAReportConfiguration : IEntityTypeConfiguration<TSAReport>
    {
        public void Configure(EntityTypeBuilder<TSAReport> builder)
        {
            builder.ConfigureBaseEntity();

            builder.Property(x => x.Name).HasColumnType("varchar(100)");
            builder.Property(x => x.DeliveryPrice).HasColumnType("decimal(18, 2)");
            builder.Property(x => x.Price).HasColumnType("decimal(18, 2)");
        }
    }
}
