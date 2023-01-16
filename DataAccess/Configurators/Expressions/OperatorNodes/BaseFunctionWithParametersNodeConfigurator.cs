using DataAccess.EntityFramework.Entities.Expressions.OperatorNodes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityFramework.Configurators.Expressions.OperatorNodes
{
    class BaseFunctionWithParametersNodeConfigurator<T> : ChildrenNodeConfigurator<T> where T : FunctionWithParametersEntity
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);
            builder.Property(c => c.FunctionName).IsRequired();
        }
    }
}
