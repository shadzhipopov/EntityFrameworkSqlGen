using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Expressions;
using Model.Expressions.LeafNodes;

namespace DataAccess.Configurators.Expressions.LeafNodes
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
