using DataAccess.EntityFramework.Entities.Expressions.Leafs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityFramework.Configurators.Expressions.LeafNodes
{
    class LeafNodeConfigurator<T> : ExpressionNodeConfigurator<T> where T : LeafEntity
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);
            builder.HasOne(p => p.Parent).WithMany().IsRequired(false).HasForeignKey(c => c.ParentId);
            //builder.HasOne(p => p.Root).WithMany().IsRequired(false).HasForeignKey(c => c.RootId);
        }
    }
}
