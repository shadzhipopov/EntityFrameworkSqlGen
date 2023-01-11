using DataAccess.Entities.Metadata;
using Model.Enums;
using System.Runtime.Serialization;

namespace DataAccess.Entities.Security.Permissions.Business
{
    public class DenyPropertyPermission : Permission
    {
        public Guid PropertyId { get; set; }

        public BusinessProperty Property { get; set; }

        public DenyMetadataItemAccess DenyPropertyAccess { get; set; }
    }
}
