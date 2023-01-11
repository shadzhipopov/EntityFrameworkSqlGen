using DataAccess.Entities.Expressions;
using DataAccess.Entities.Expressions.OperatorNodes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq.Expressions;

namespace DataAccess.Configurations.Expressions.OperatorNodes
{
    class AggregateFunctionNodeConfigurator : BaseFunctionWithParametersNodeConfigurator<AggregateFunctionNode>
    {
        public override void Configure(EntityTypeBuilder<AggregateFunctionNode> builder)
        {
            builder.HasBaseType(typeof(ExpressionNode));
            base.Configure(builder);
        }
    }
}
