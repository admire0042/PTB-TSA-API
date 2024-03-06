using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public static class EntityTypeBuilderExtensions
    {
        public static void ConfigureBaseEntity<T>(this EntityTypeBuilder<T> builder) where T : Entity
        {
            builder.HasKey(x => x.Id);
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.Property(x => x.DateAdded).HasColumnType("DateTime2").IsRequired(false);
            builder.Property(x => x.DateModified).HasColumnType("DateTime2").IsRequired(false);
        }
    }
}
