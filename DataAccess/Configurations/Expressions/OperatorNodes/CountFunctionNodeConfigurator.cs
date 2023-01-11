using DataAccess.Entities.Expressions.OperatorNodes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Expressions.OperatorNodes
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
