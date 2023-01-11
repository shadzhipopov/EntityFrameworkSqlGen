using DataAccess.Entities.Expressions.LeafNodes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Expressions.LeafNodes
{
    class ConstantLeafNodeConfigurator : LeafNodeConfigurator<ConstantLeafNode>
    {
        public override void Configure(EntityTypeBuilder<ConstantLeafNode> builder)
        {
            base.Configure(builder);
            builder.Property(c => c.ConstantType);
        }
    }
}
