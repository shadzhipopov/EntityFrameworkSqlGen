using DataAccess.Entities.Expressions.OperatorNodes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Expressions.OperatorNodes
{
    class ChildrenNodeConfigurator<T> : ExpressionNodeConfigurator<T>
        where T : ChildrenOperatorNode
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);
            //HasOptional(p => p.Parent).WithOptionalDependent().Map(c => { c.MapKey("ParentId"); });          
            //builder.HasOne(c => c.Parent).WithMany().IsRequired(false).HasForeignKey(c => c.ParentId);
            //builder.HasOne(c => c.Root).WithMany().IsRequired(false).HasForeignKey(c => c.RootId);
            builder.HasMany(c => c.Children).WithOne(c => (T)c.Parent).HasForeignKey(c => c.ParentId);
        }
    }
}
