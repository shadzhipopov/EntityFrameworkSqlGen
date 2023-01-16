using DataAccess.EntityFramework.Configurators.Base;
using DataAccess.EntityFramework.Entities.UI;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityFramework.Configurators.UI
{
    class PageConfigurator : BaseConfigurator<Page>
    {
        public override void Configure(EntityTypeBuilder<Page> builder)
        {
            base.Configure(builder);

            builder.HasOne(c => c.PageObject)
                .WithMany(o => o.Pages)
                .HasForeignKey(p => p.PageObjectId);
        }
    }
}
