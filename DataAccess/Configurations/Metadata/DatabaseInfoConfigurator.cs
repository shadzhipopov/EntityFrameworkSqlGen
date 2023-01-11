using DataAccess.Configurations.Base;
using DataAccess.Entities.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Metadata
{
    class DatabaseInfoConfigurator : BaseConfigurator<DatabaseInfo>
    {
        public DatabaseInfoConfigurator()
        {
        }

        public override void Configure(EntityTypeBuilder<DatabaseInfo> builder)
        {
            base.Configure(builder);

            builder.HasMany(d => d.BusinessModules)
                .WithOne(m => m.Database)
                .IsRequired(false)
                .HasForeignKey(c => c.DatabaseInfoId);
        }
    }
}
