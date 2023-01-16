using DataAccess.EntityFramework.Entities.Expressions.OperatorNodes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityFramework.Configurators.Expressions.OperatorNodes
{
    class OrderByNodeItemConfigurator : ChildrenNodeConfigurator<OrderByItemEntity>
    {
        public override void Configure(EntityTypeBuilder<OrderByItemEntity> builder)
        {
            base.Configure(builder);
            builder.Property(c => c.OrderDirection);
        }
    }
}
