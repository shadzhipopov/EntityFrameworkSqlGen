using DataAccess.Entities.Expressions.LeafNodes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Expressions.LeafNodes
{
    class BusinessPropertyLeafNodeConfigurator : MetadataPathNodeConfigurator<BusinessPropertyLeafNode>
    {
        public override void Configure(EntityTypeBuilder<BusinessPropertyLeafNode> builder)
        {
            base.Configure(builder);
        }
    }
}
