using DataAccess.EntityFramework.Entities.Expressions;
using DataAccess.EntityFramework.Entities.Expressions.OperatorNodes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq.Expressions;

namespace DataAccess.EntityFramework.Configurators.Expressions.OperatorNodes
{
    class AggregateFunctionNodeConfigurator : BaseFunctionWithParametersNodeConfigurator<AggregateFunctionEntity>
    {
        public override void Configure(EntityTypeBuilder<AggregateFunctionEntity> builder)
        {
            builder.HasBaseType(typeof(ExpressionEntity));
            base.Configure(builder);
        }
    }
}
