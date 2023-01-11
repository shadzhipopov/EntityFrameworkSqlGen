using Model.Enums;
using System.Runtime.Serialization;

namespace DataAccess.Entities.Security.Permissions.Business
{
    [DataContract(IsReference = true)]
    public class GrantModuleAccessPermission : BusinessModulePermission
    {
        [DataMember]
        public ReadWriteAccessType GrantedAccess { get; set; }
    }
}
