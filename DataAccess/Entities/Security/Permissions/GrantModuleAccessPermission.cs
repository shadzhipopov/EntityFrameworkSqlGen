using Model.Enums;


namespace DataAccess.EntityFramework.Entities.Security.Permissions
{
    public class GrantModuleAccessPermission : BusinessModulePermission
    {
        public ReadWriteAccessType GrantedAccess { get; set; }
    }
}
