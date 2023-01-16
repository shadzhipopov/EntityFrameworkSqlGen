using DataAccess.EntityFramework.Configurators.Base;
using DataAccess.EntityFramework.Entities.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityFramework.Configurators.Metadata
{
    class EnumerationTypeConfigurator : BaseConfigurator<EnumerationTypeEntity>
    {
        public EnumerationTypeConfigurator()
        {

        }

        public override void Configure(EntityTypeBuilder<EnumerationTypeEntity> builder)
        {
            base.Configure(builder);
            builder.HasMany(t => t.UsedInProperties)
                .WithOne(p => p.Enumeration)
                .HasForeignKey(c => c.EnumerationTypeId);
        }
    }
}
