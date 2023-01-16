using DataAccess.EntityFramework.Configurators.Base;
using DataAccess.EntityFramework.Entities.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityFramework.Configurators.Metadata
{
    class BusinessObjectExpressionConfigurator : BaseConfigurator<BusinessObjectExpressionEntity>
    {
        public BusinessObjectExpressionConfigurator()
        {
        }

        public override void Configure(EntityTypeBuilder<BusinessObjectExpressionEntity> builder)
        {
            base.Configure(builder);

            builder.HasMany(e => e.Nodes)
                .WithOne(n => n.BusinessObjectExpression)
                .HasForeignKey(e => e.BusinessObjectExpressionId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            builder.HasOne(e => e.TargetProperty)
                .WithMany(p => p.ValidationExpressions)
                .HasForeignKey(e => e.TargetPropertyId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
        }
    }
}
