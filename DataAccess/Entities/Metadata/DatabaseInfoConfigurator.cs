using DataAccess.Configurators.Base;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurators
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
