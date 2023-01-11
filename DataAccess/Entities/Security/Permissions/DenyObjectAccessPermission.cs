using Model.Enums;

namespace DataAccess.Entities.Security.Permissions
{
    public class DenyObjectAccessPermission : BusinessObjectPermission
    {
        public DenyMetadataItemAccess DeniedAccess { get; set; }
    }
}
