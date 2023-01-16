using DataAccess.EntityFramework.Configurators.Base;
using DataAccess.EntityFramework.Entities.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityFramework.Configurators.Metadata
{
    class MetadataItemPathRelationConfigurator : BaseConfigurator<MetadataItemPathRelationEntity>
    {
        public MetadataItemPathRelationConfigurator()
        {
        }

        public override void Configure(EntityTypeBuilder<MetadataItemPathRelationEntity> builder)
        {
            base.Configure(builder);

            builder.HasOne(c => c.PathNode)
                .WithMany(c => c.PathToTarget)
                .HasForeignKey(c => c.PathNodeId);
        }
    }
}
