using DataAccess.EntityFramework.Entities.Expressions.OperatorNodes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityFramework.Configurators.Expressions.OperatorNodes
{
    class LogicalOperatorNodeConfigurator : ChildrenNodeConfigurator<LogicalOperatorEntity>
    {
        public override void Configure(EntityTypeBuilder<LogicalOperatorEntity> builder)
        {
            base.Configure(builder);
            builder.Property(c => c.LogicalOperator);
        }
    }
}
