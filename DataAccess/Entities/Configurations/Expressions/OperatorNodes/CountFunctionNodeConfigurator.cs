using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Expressions.OperatorNodes;

namespace DataAccess.Configurators.Expressions.OperatorNodes
{
    class CountFunctionNodeConfigurator : BaseFunctionWithParametersNodeConfigurator<CountFunctionNode>
    {
        public override void Configure(EntityTypeBuilder<CountFunctionNode> builder)
        {
            base.Configure(builder);
            builder.Property(c => c.CountAll);
        }
    }
}
