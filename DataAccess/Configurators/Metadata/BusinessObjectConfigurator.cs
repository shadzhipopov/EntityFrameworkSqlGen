using DataAccess.EntityFramework.Configurators.Base;
using DataAccess.EntityFramework.Entities.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityFramework.Configurators.Metadata
{
    public class BusinessObjectConfigurator : BaseConfigurator<BusinessObjectEntity>
    {
        public BusinessObjectConfigurator()
        {
        }

        public override void Configure(EntityTypeBuilder<BusinessObjectEntity> builder)
        {
            base.Configure(builder);
            builder.HasMany(t => t.Properties).WithOne(c => c.BusinessObject).HasForeignKey(c => c.BusinessObjectId);
            builder.HasOne(c => c.NameProperty).WithMany().HasForeignKey(c => c.NamePropertyId);
            builder.HasOne(t => t.BusinessModule).WithMany(m => m.BusinessObjects).HasForeignKey(c => c.BusinessModuleId);
            builder.HasOne(c => c.BaseObject).WithMany(c => c.Descendants).HasForeignKey(c => c.BaseObjectId);
            builder.HasMany(o => o.FromRelations).WithOne(c => c.FromObject).HasForeignKey(c => c.FromObjectId);
            builder.HasMany(o => o.ToRelations).WithOne(c => c.ToObject).HasForeignKey(c => c.ToObjectId);
        }
    }
}
