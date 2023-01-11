using DataAccess.Configurations.Base;
using DataAccess.Entities.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Metadata
{
    public class BusinessPropertyConfigurator : BaseConfigurator<BusinessProperty>
    {
        public BusinessPropertyConfigurator()
        {
        }

        public override void Configure(EntityTypeBuilder<BusinessProperty> builder)
        {
            base.Configure(builder);
            //TO DO: check this conversion
            builder.HasOne(c => c.Type)
                .WithOne(c => c.BusinessProperty)
                .HasForeignKey<BusinessPropertyType>(c => c.Id)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
        }
    }
}
