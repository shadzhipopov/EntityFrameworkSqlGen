using Model.Enums;


namespace DataAccess.Entities.Security.Permissions
{
    public class DenyBusinessModuleAccessPermission : BusinessModulePermission
    {
        public DenyMetadataItemAccess DeniedAccess { get; set; }
    }
}
