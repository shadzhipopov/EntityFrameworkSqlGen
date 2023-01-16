using Model.Enums;


namespace DataAccess.EntityFramework.Entities.Security.Permissions
{
    public class DenyBusinessModuleAccessPermission : BusinessModulePermission
    {
        public DenyMetadataItemAccess DeniedAccess { get; set; }
    }
}
