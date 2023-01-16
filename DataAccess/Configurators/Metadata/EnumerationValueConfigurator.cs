using DataAccess.EntityFramework.Configurators.Base;
using DataAccess.EntityFramework.Entities.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityFramework.Configurators.Metadata
{
    class EnumerationValueConfigurator : BaseConfigurator<EnumerationValueEntity>
    {
        public EnumerationValueConfigurator()
        {
        }

        public override void Configure(EntityTypeBuilder<EnumerationValueEntity> builder)
        {
            base.Configure(builder);

            builder.HasOne(c => c.EnumerationType)
                .WithMany(c => c.Values)
                .HasForeignKey(c => c.EnumerationTypeId);
        }
    }
}
