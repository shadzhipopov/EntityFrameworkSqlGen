using DataAccess.EntityFramework.Entities.Expressions.Leafs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityFramework.Configurators.Expressions.LeafNodes
{
    class BusinessObjectLeafNodeConfigurator : MetadataPathNodeConfigurator<BusinessObjectLeafEntity>
    {

        public override void Configure(EntityTypeBuilder<BusinessObjectLeafEntity> builder)
        {
            base.Configure(builder);
            builder.HasOne(c => c.TargetObject).WithMany().HasForeignKey(c => c.TargetObjectId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
