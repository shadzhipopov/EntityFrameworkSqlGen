using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccess.Configurations.Base;
using DataAccess.Entities.Security;

namespace DataAccess.Configurations.Security
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
