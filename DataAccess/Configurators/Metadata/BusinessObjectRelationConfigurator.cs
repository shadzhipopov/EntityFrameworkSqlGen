using DataAccess.EntityFramework.Configurators.Base;
using DataAccess.EntityFramework.Entities.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityFramework.Configurators.Metadata
{
    class BusinessObjectRelationConfigurator : BaseConfigurator<BusinessObjectRelationEntity>
    {
        public BusinessObjectRelationConfigurator()
        {

        }

        public override void Configure(EntityTypeBuilder<BusinessObjectRelationEntity> builder)
        {
            base.Configure(builder);

            builder.HasOne(r => r.FromObject)
                .WithMany(c => c.FromRelations)
                .HasForeignKey(r => r.FromObjectId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            builder.HasOne(r => r.ToObject)
                .WithMany(c => c.ToRelations)
                .HasForeignKey(r => r.ToObjectId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            builder.HasMany(c => c.ForeignKeys)
                .WithOne(c => c.BusinessObjectRelation)
                .HasForeignKey(c => c.BusinessObjectRelationId);
        }
    }
}
