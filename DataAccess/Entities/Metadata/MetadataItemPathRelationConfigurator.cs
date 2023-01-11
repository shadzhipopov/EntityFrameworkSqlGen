using DataAccess.Configurators.Base;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurators.Metadata
{
    class MetadataItemPathRelationConfigurator : BaseConfigurator<MetadataItemPathRelation>
    {
        public MetadataItemPathRelationConfigurator()
        {            
        }

        public override void Configure(EntityTypeBuilder<MetadataItemPathRelation> builder)
        {
            base.Configure(builder);

            builder.HasOne(c => c.PathNode)
                .WithMany(c => c.PathToTarget)
                .HasForeignKey(c => c.PathNodeId);
        }
    }
}
