using DataAccess.Entities.Metadata;


namespace DataAccess.Entities.Security.Permissions
{
    public abstract class BusinessObjectPermission : Permission
    {
        public Guid ObjectId { get; set; }

        public virtual BusinessObject Object { get; set; }
    }
}
