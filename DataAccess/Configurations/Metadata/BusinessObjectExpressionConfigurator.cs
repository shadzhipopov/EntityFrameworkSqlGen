using DataAccess.Configurations.Base;
using DataAccess.Entities.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Metadata
{
    class BusinessObjectExpressionConfigurator : BaseConfigurator<BusinessObjectExpression>
    {
        public BusinessObjectExpressionConfigurator()
        {
        }

        public override void Configure(EntityTypeBuilder<BusinessObjectExpression> builder)
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
