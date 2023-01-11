using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Expressions.OperatorNodes;

namespace DataAccess.Configurators.Expressions.OperatorNodes
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
