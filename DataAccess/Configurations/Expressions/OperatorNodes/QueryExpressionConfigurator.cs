using DataAccess.Entities.Expressions.OperatorNodes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Expressions.OperatorNodes
{
    class QueryExpressionConfigurator : ChildrenNodeConfigurator<QueryExpression>
    {
        public override void Configure(EntityTypeBuilder<QueryExpression> builder)
        {
            base.Configure(builder);
            builder.Property(c => c.FromId);
        }
    }
}
