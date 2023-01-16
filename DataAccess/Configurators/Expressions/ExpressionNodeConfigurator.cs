using DataAccess.EntityFramework.Configurators.Base;
using DataAccess.EntityFramework.Entities.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Helpers;

namespace DataAccess.EntityFramework.Configurators.Expressions
{
    class ExpressionNodeConfigurator<T> : BaseConfigurator<T>
        where T : ExpressionEntity
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            builder.ToTable(
               "ExpressionNode",
               MetadataNamesHelper.FdbaPrefix);

            // builder.HasKey(x => x.Id);
            // builder.Property(x => x.Id).HasColumnName(typeof(T).Name + "Id");
            builder.HasDiscriminator<string>("NodeType");
            //builder.HasQueryFilter(c => c.IsDeleted == false);
        }
    }
}
