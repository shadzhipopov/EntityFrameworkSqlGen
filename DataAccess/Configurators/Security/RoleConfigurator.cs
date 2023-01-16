using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccess.EntityFramework.Entities.Security;
using DataAccess.EntityFramework.Configurators.Base;

namespace DataAccess.EntityFramework.Configurators.Security
{
    public class RoleConfigurator : BaseConfigurator<Role>
    {
        public RoleConfigurator()
        {

        }

        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            base.Configure(builder);
            builder.HasMany(c => c.Permissions).WithOne(c => c.Role).HasForeignKey(c => c.RoleId);
        }
    }
}
