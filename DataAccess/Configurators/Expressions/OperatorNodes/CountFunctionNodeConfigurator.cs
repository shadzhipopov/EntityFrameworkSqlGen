using DataAccess.EntityFramework.Entities.Expressions.OperatorNodes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityFramework.Configurators.Expressions.OperatorNodes
{
    class CountFunctionNodeConfigurator : BaseFunctionWithParametersNodeConfigurator<CountFunctionEntity>
    {
        public override void Configure(EntityTypeBuilder<CountFunctionEntity> builder)
        {
            base.Configure(builder);
            builder.Property(c => c.CountAll);
        }
    }
}
