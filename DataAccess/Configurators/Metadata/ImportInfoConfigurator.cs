using DataAccess.EntityFramework.Configurators.Base;
using DataAccess.EntityFramework.Entities.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityFramework.Configurators.Metadata
{
    class ImportInfoConfigurator : BaseConfigurator<ImportPropertyInfoEntity>
    {
        public ImportInfoConfigurator()
        {
        }

        public override void Configure(EntityTypeBuilder<ImportPropertyInfoEntity> builder)
        {
            base.Configure(builder);
            builder.HasOne(i => i.ConvertedProperty).WithOne(bp => bp.ImportInformation);
        }
    }
}
