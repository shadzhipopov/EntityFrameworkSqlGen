using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Expressions.OperatorNodes;

namespace DataAccess.Configurators.Expressions.OperatorNodes
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
