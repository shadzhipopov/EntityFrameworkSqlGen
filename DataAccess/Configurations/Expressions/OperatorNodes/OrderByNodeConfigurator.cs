using DataAccess.Entities.Expressions.OperatorNodes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Expressions.OperatorNodes
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
