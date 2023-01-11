using DataAccess.Entities.Metadata;

namespace DataAccess.Entities.Security.Permissions.Business
{
    public abstract class BusinessModulePermission : Permission
    {
        public Guid ModuleId { get; set; }

        public BusinessModule Module { get; set; }
    }
}
