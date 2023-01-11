using DataAccess.Entities.Expressions.LeafNodes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Expressions.LeafNodes
{
    class LeafNodeConfigurator<T> : ExpressionNodeConfigurator<T> where T : LeafNode
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);
            builder.HasOne(p => p.Parent).WithMany().IsRequired(false).HasForeignKey(c => c.ParentId);
            //builder.HasOne(p => p.Root).WithMany().IsRequired(false).HasForeignKey(c => c.RootId);
        }
    }
}
