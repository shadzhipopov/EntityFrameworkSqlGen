using DataAccess.Configurations.Base;
using DataAccess.Entities.UI;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurators.UI
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
