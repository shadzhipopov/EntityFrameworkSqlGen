using DataAccess.Configurators.Base;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurators.Metadata
{
    class EnumerationTypeConfigurator : BaseConfigurator<EnumerationType>
    {
        public EnumerationTypeConfigurator()
        {
            
        }

        public override void Configure(EntityTypeBuilder<EnumerationType> builder)
        {
            base.Configure(builder);
            builder.HasMany(t => t.UsedInProperties)
                .WithOne(p => p.Enumeration)
                .HasForeignKey(c => c.EnumerationTypeId);
        }
    }
}
