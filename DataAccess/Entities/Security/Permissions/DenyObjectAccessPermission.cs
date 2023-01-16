using Model.Enums;

namespace DataAccess.EntityFramework.Entities.Security.Permissions
{
    public class DenyObjectAccessPermission : BusinessObjectPermission
    {
        public DenyMetadataItemAccess DeniedAccess { get; set; }
    }
}
