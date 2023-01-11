using DataAccess.Configurators.Base;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurators.Metadata
{
    class BusinessObjectRelationConfigurator : BaseConfigurator<BusinessObjectRelation>
    {
        public BusinessObjectRelationConfigurator()
        {
            
        }

        public override void Configure(EntityTypeBuilder<BusinessObjectRelation> builder)
        {
            base.Configure(builder);

            builder.HasOne(r => r.FromObject)
                .WithMany(c => c.FromRelations)
                .HasForeignKey(r => r.FromObjectId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);                

            builder.HasOne(r => r.ToObject)
                .WithMany(c => c.ToRelations)
                .HasForeignKey(r => r.ToObjectId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);                

            builder.HasMany(c => c.ForeignKeys)
                .WithOne(c => c.BusinessObjectRelation)
                .HasForeignKey(c => c.BusinessObjectRelationId);
        }
    }
}
