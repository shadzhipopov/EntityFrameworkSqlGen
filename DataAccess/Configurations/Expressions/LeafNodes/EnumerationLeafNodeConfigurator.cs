using DataAccess.Entities.Expressions.LeafNodes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Expressions.LeafNodes
{
    class EnumerationLeafNodeConfigurator : LeafNodeConfigurator<EnumerationValueLeafNode>
    {
        public override void Configure(EntityTypeBuilder<EnumerationValueLeafNode> builder)
        {
            base.Configure(builder);
            builder.HasOne(c => c.EnumerationType)
                .WithMany()
                .HasForeignKey(c => c.EnumerationTypeId).OnDelete
                (Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
        }
    }
}
