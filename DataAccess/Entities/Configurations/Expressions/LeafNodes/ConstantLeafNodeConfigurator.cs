using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Expressions.LeafNodes;

namespace DataAccess.Configurators.Expressions.LeafNodes
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
