using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Expressions.OperatorNodes;

namespace DataAccess.Configurators.Expressions.OperatorNodes
{
    class BaseFunctionWithParametersNodeConfigurator<T> : ChildrenNodeConfigurator<T> where T : FunctionWithParametersNode
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);
            builder.Property(c => c.FunctionName).IsRequired();
        }
    }
}
