using DataAccess.Configurations.Base;
using DataAccess.Entities.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Metadata
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
