using DataAccess.EntityFramework.Entities.Expressions.Leafs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityFramework.Configurators.Expressions.LeafNodes
{
    class EnumerationLeafNodeConfigurator : LeafNodeConfigurator<EnumerationValueLeafEntity>
    {
        public override void Configure(EntityTypeBuilder<EnumerationValueLeafEntity> builder)
        {
            base.Configure(builder);
            builder.HasOne(c => c.EnumerationType)
                .WithMany()
                .HasForeignKey(c => c.EnumerationTypeId).OnDelete
                (Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
        }
    }
}
