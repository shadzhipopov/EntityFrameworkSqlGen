using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Expressions;
using Model.Expressions.OperatorNodes;
using System.Linq.Expressions;

namespace DataAccess.Configurators.Expressions.OperatorNodes
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
