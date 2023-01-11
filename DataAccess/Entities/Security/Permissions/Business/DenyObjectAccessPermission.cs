using Model.Enums;

namespace DataAccess.Entities.Security.Permissions.Business
{
    public class DenyObjectAccessPermission : BusinessObjectPermission
    {
        public DenyMetadataItemAccess DeniedAccess { get; set; }
    }
}
