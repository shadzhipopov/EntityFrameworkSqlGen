using DataAccess.EntityFramework.Entities.Expressions.OperatorNodes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityFramework.Configurators.Expressions.OperatorNodes
{
    class QueryExpressionConfigurator : ChildrenNodeConfigurator<QueryExpressionEntity>
    {
        public override void Configure(EntityTypeBuilder<QueryExpressionEntity> builder)
        {
            base.Configure(builder);
            builder.Property(c => c.FromId);
        }
    }
}
