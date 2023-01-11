using DataAccess.Entities.Metadata;

namespace DataAccess.Entities.Security.Permissions
{
    public abstract class BusinessModulePermission : Permission
    {
        public Guid ModuleId { get; set; }

        public virtual BusinessModule Module { get; set; }
    }
}
