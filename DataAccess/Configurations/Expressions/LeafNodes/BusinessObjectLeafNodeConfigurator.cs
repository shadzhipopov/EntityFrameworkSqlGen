using DataAccess.Entities.Expressions.LeafNodes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Expressions.LeafNodes
{
    class BusinessObjectLeafNodeConfigurator : MetadataPathNodeConfigurator<BusinessObjectLeafNode>
    {

        public override void Configure(EntityTypeBuilder<BusinessObjectLeafNode> builder)
        {
            base.Configure(builder);
            builder.HasOne(c => c.TargetObject).WithMany().HasForeignKey(c => c.TargetObjectId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
