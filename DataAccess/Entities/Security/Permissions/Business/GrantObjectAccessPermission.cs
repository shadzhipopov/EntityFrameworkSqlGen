using Model.Enums;

namespace DataAccess.Entities.Security.Permissions.Business
{
    public class GrantObjectAccessPermission : BusinessObjectPermission
    {
        public ReadWriteAccessType GrantedAccess { get; set; }
    }
}
