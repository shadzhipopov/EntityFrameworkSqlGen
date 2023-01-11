using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace DataAccess.Configurators.Base
{
    public class BaseConfigurator<T> : EntityTypeConfiguration<T> where T : BaseObject
    {
        public BaseConfigurator()
        {
        }

        public override void Configure(EntityTypeBuilder<T> builder)
        {
            builder.ToTable(
                typeof(T).Name,
                "fdba");

            builder.HasKey(x => x.Id);
            builder.HasQueryFilter(c => c.IsDeleted == false);
        }
    }

    public abstract class EntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseObject
    {
        public abstract void Configure(EntityTypeBuilder<T> builder);
    }
}
