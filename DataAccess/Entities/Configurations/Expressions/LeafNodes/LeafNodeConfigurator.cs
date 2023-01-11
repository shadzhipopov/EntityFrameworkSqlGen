using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Expressions;
using Model.Expressions.LeafNodes;

namespace DataAccess.Configurators.Expressions.LeafNodes
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
