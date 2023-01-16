using DataAccess.EntityFramework.Entities.Metadata;

namespace DataAccess.EntityFramework.Entities.Security.Permissions
{
    public abstract class BusinessObjectPermission : Permission
    {
        public Guid ObjectId { get; set; }

        public virtual BusinessObjectEntity Object { get; set; }
    }
}
