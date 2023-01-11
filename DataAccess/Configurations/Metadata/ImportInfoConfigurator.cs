using DataAccess.Configurations.Base;
using DataAccess.Entities.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Metadata
{
    class ImportInfoConfigurator : BaseConfigurator<ImportPropertyInfo>
    {
        public ImportInfoConfigurator()
        {
        }

        public override void Configure(EntityTypeBuilder<ImportPropertyInfo> builder)
        {
            base.Configure(builder);
            builder.HasOne(i => i.ConvertedProperty).WithOne(bp => bp.ImportInformation);
        }
    }
}
