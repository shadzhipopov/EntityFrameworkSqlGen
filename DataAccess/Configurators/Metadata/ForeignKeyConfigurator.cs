using DataAccess.EntityFramework.Configurators.Base;
using DataAccess.EntityFramework.Entities.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityFramework.Configurators.Metadata
{
    public class ForeignKeyConfigurator : BaseConfigurator<ForeignKeyEntity>
    {
        public ForeignKeyConfigurator()
        {
        }

        public override void Configure(EntityTypeBuilder<ForeignKeyEntity> builder)
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
