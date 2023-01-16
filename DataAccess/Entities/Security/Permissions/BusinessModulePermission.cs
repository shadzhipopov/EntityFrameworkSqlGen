using DataAccess.EntityFramework.Entities.Metadata;

namespace DataAccess.EntityFramework.Entities.Security.Permissions
{
    public abstract class BusinessModulePermission : Permission
    {
        public Guid ModuleId { get; set; }

        public virtual BusinessModuleEntity Module { get; set; }
    }
}
