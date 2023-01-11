using System;
using System.Runtime.Serialization;
using DataAccess.Entities.UI;

namespace DataAccess.Entities.Security.Permissions.Business
{
    [DataContract(IsReference = true)]
    public class DenyPageAccessPermission : Permission
    {
        [DataMember]
        public Guid PageId { get; set; }

        [DataMember]
        public Page Page { get; set; }
    }
}
