using DataAccess.EntityFramework.Configurators.Base;
using DataAccess.EntityFramework.Entities.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityFramework.Configurators.Metadata
{
    public class BusinessPropertyConfigurator : BaseConfigurator<BusinessPropertyEntity>
    {
        public BusinessPropertyConfigurator()
        {
        }

        public override void Configure(EntityTypeBuilder<BusinessPropertyEntity> builder)
        {
            base.Configure(builder);
            //TO DO: check this conversion
            builder.HasOne(c => c.Type)
                .WithOne(c => c.BusinessProperty)
                .HasForeignKey<BusinessPropertyTypeEntity>(c => c.Id)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
        }
    }
}
