using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Expressions.OperatorNodes;

namespace DataAccess.Configurators.Expressions.OperatorNodes
{
    class OrderByNodeItemConfigurator : ChildrenNodeConfigurator<OrderByItemNode>
    {
        public override void Configure(EntityTypeBuilder<OrderByItemNode> builder)
        {
            base.Configure(builder);
            builder.Property(c => c.OrderDirection);
        }
    }
}
