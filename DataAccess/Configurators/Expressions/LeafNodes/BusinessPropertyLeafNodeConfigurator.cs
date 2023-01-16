using DataAccess.EntityFramework.Entities.Expressions.Leafs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityFramework.Configurators.Expressions.LeafNodes
{
    class BusinessPropertyLeafNodeConfigurator : MetadataPathNodeConfigurator<BusinessPropertyLeafEntity>
    {
        public override void Configure(EntityTypeBuilder<BusinessPropertyLeafEntity> builder)
        {
            base.Configure(builder);
        }
    }
}
