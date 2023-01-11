using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Expressions.OperatorNodes;

namespace DataAccess.Configurators.Expressions.OperatorNodes
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
