using DataAccess.EntityFramework.Configurators.Base;
using DataAccess.EntityFramework.Entities.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityFramework.Configurators.Metadata
{
    class DatabaseInfoConfigurator : BaseConfigurator<DatabaseInfoEntity>
    {
        public DatabaseInfoConfigurator()
        {
        }

        public override void Configure(EntityTypeBuilder<DatabaseInfoEntity> builder)
        {
            base.Configure(builder);

            builder.HasMany(d => d.BusinessModules)
                .WithOne(m => m.Database)
                .IsRequired(false)
                .HasForeignKey(c => c.DatabaseInfoId);
        }
    }
}
