using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Expressions.OperatorNodes;

namespace DataAccess.Configurators.Expressions.OperatorNodes
{
    class FunctionWithParametersNodeConfigurator : BaseFunctionWithParametersNodeConfigurator<FunctionWithParametersNode> 
    {
        public override void Configure(EntityTypeBuilder<FunctionWithParametersNode> builder)
        {
            base.Configure(builder);
            builder.Property(c => c.FunctionName).IsRequired();
        }
    }
}
