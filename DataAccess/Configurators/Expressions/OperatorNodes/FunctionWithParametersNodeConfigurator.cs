using DataAccess.EntityFramework.Entities.Expressions.OperatorNodes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityFramework.Configurators.Expressions.OperatorNodes
{
    class FunctionWithParametersNodeConfigurator : BaseFunctionWithParametersNodeConfigurator<FunctionWithParametersEntity>
    {
        public override void Configure(EntityTypeBuilder<FunctionWithParametersEntity> builder)
        {
            base.Configure(builder);
            builder.Property(c => c.FunctionName).IsRequired();
        }
    }
}
