using DataAccess.Entities.Expressions.OperatorNodes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Expressions.OperatorNodes
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
