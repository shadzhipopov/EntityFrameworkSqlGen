using DataAccess.Entities.Metadata;
using Model.Enums;


namespace DataAccess.Entities.Security.Permissions
{
    public class DenyPropertyPermission : Permission
    {
        public Guid PropertyId { get; set; }
        
        public DenyMetadataItemAccess DenyPropertyAccess { get; set; }

        public virtual BusinessProperty Property { get; set; }
    }
}
