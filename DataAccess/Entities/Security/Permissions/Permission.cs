using System;
using System.Runtime.Serialization;

namespace DataAccess.Entities.Security.Permissions
{
    [DataContract(IsReference = true)]
    public abstract class Permission : BaseObject
    {
        [DataMember]
        public Guid RoleId { get; set; }

        [DataMember]
        public virtual Role Role { get; set; }
    }
}
