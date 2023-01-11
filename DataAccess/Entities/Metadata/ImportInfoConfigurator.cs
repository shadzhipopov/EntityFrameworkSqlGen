using DataAccess.Configurators.Base;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurators.Metadata
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
