using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Expressions.LeafNodes;

namespace DataAccess.Configurators.Expressions.LeafNodes
{
    class BusinessObjectLeafNodeConfigurator : MetadataPathNodeConfigurator<BusinessObjectLeafNode>
    {

        public override void Configure(EntityTypeBuilder<BusinessObjectLeafNode> builder)
        {
            base.Configure(builder);
            builder.HasOne(c=>c.TargetObject).WithMany().HasForeignKey(c=>c.TargetObjectId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
