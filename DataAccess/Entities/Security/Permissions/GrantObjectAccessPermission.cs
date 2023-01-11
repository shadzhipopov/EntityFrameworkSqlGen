using Model.Enums;

namespace DataAccess.Entities.Security.Permissions
{
    public class GrantObjectAccessPermission : BusinessObjectPermission
    {
        public ReadWriteAccessType GrantedAccess { get; set; }
    }
}
