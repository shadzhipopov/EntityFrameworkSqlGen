using DataAccess.Configurations.Base;
using DataAccess.Entities.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Metadata
{
    public class ForeignKeyConfigurator : BaseConfigurator<ForeignKey>
    {
        public ForeignKeyConfigurator()
        {
        }

        public override void Configure(EntityTypeBuilder<ForeignKey> builder)
        {
            base.Configure(builder);
            builder.HasOne(r => r.PrimaryKeyProperty)
                .WithMany()
                .HasForeignKey(t => t.PrimaryKeyPropertyId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            builder.HasOne(r => r.ForeignKeyProperty)
                .WithMany()
                .HasForeignKey(t => t.ForeignKeyPropertyId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
        }
    }
}
