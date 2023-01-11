using DataAccess.Entities.Expressions.OperatorNodes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Expressions.OperatorNodes
{
    class ComparisonOperatorNodeConfigurator : ChildrenNodeConfigurator<ComparisonOperatorNode>
    {
        public override void Configure(EntityTypeBuilder<ComparisonOperatorNode> builder)
        {
            base.Configure(builder);
            builder.Property(b => b.Operation);
        }
    }
}
