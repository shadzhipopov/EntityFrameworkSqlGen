using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Expressions.LeafNodes;

namespace DataAccess.Configurators.Expressions.LeafNodes
{
    class BusinessPropertyLeafNodeConfigurator : MetadataPathNodeConfigurator<BusinessPropertyLeafNode>
    {
        public override void Configure(EntityTypeBuilder<BusinessPropertyLeafNode> builder)
        {
            base.Configure(builder);
        }
    }
}
