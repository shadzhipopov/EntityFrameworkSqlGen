using Model.Enums;

namespace DataAccess.EntityFramework.Entities.Security.Permissions
{
    public class GrantObjectAccessPermission : BusinessObjectPermission
    {
        public ReadWriteAccessType GrantedAccess { get; set; }
    }
}
