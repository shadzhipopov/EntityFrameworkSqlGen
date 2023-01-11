using Model.Enums;
using System.Runtime.Serialization;

namespace DataAccess.Entities.Security.Permissions.Business
{
    public class DenyBusinessModuleAccessPermission : BusinessModulePermission
    {
        public DenyMetadataItemAccess DeniedAccess { get; set; }
    }
}
