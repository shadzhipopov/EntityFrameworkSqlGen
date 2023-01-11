using DataAccess.Entities.Expressions.OperatorNodes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Expressions.OperatorNodes
{
    class LogicalOperatorNodeConfigurator : ChildrenNodeConfigurator<LogicalOperatorNode>
    {
        public override void Configure(EntityTypeBuilder<LogicalOperatorNode> builder)
        {
            base.Configure(builder);
            builder.Property(c => c.LogicalOperator);
        }
    }
}
