using Model.Enums;


namespace DataAccess.Entities.Security.Permissions
{
    public class GrantModuleAccessPermission : BusinessModulePermission
    {
        public  ReadWriteAccessType GrantedAccess { get; set; }
    }
}
