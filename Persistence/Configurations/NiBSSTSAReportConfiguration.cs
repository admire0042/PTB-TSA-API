using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Persistence.Configurations
{
    public class NiBSSTSAReportConfiguration : IEntityTypeConfiguration<NiBSSTSAReport>
    {
        public void Configure(EntityTypeBuilder<NiBSSTSAReport> builder)
        {
            builder.ConfigureBaseEntity();

            //builder.Property(x => x.Name).HasColumnType("varchar(100)");
            //builder.Property(x => x.Description).HasColumnType("varchar(500)");

            //builder.HasOne(x => x.Product)
            //                  .WithMany(x => x.ProductOptions)
            //                  .HasForeignKey(x => x.ProductId)
            //                  .OnDelete(DeleteBehavior.Cascade);


        }

    }
}
