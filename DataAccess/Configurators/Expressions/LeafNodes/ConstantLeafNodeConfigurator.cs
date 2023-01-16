using DataAccess.EntityFramework.Entities.Expressions.Leafs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityFramework.Configurators.Expressions.LeafNodes
{
    class ConstantLeafNodeConfigurator : LeafNodeConfigurator<ConstantEntity>
    {
        public override void Configure(EntityTypeBuilder<ConstantEntity> builder)
        {
            base.Configure(builder);
            builder.Property(c => c.ConstantType);
        }
    }
}
