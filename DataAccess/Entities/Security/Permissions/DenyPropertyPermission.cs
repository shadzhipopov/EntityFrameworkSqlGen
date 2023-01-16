using DataAccess.EntityFramework.Entities.Metadata;
using Model.Enums;

namespace DataAccess.EntityFramework.Entities.Security.Permissions
{
    public class DenyPropertyPermission : Permission
    {
        public Guid PropertyId { get; set; }

        public DenyMetadataItemAccess DenyPropertyAccess { get; set; }

        public virtual BusinessPropertyEntity Property { get; set; }
    }
}
