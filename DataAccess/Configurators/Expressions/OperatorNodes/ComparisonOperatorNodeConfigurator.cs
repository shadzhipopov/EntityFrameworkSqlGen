using DataAccess.EntityFramework.Entities.Expressions.OperatorNodes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityFramework.Configurators.Expressions.OperatorNodes
{
    class ComparisonOperatorNodeConfigurator : ChildrenNodeConfigurator<ComparisonOperatorEntity>
    {
        public override void Configure(EntityTypeBuilder<ComparisonOperatorEntity> builder)
        {
            base.Configure(builder);
            builder.Property(b => b.Operation);
        }
    }
}
