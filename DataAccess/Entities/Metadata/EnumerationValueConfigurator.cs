using DataAccess.Configurators.Base;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurators.Metadata
{
    class EnumerationValueConfigurator : BaseConfigurator<EnumerationValue>
    {
        public EnumerationValueConfigurator()
        {           
        }

        public override void Configure(EntityTypeBuilder<EnumerationValue> builder)
        {
            base.Configure(builder);

            builder.HasOne(c => c.EnumerationType)
                .WithMany(c => c.Values)
                .HasForeignKey(c => c.EnumerationTypeId);
        }
    }
}
