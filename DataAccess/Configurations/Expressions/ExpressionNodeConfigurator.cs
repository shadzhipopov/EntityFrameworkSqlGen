using DataAccess.Configurations.Base;
using DataAccess.Entities.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Helpers;

namespace DataAccess.Configurations.Expressions
{
    class ExpressionNodeConfigurator<T> : BaseConfigurator<T>
        where T : ExpressionNode
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {

            builder.ToTable(
               nameof(ExpressionNode),
               MetadataNamesHelper.FdbaPrefix);

            // builder.HasKey(x => x.Id);
            // builder.Property(x => x.Id).HasColumnName(typeof(T).Name + "Id");
            builder.HasDiscriminator<string>("NodeType");
            //builder.HasQueryFilter(c => c.IsDeleted == false);
        }
    }
}
