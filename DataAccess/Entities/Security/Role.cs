using DataAccess.Entities.Security.Permissions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DataAccess.Entities.Security
{
    [DataContract(IsReference = true)]
    public class Role : BaseObject
    {
        public Role()
        {
            Users = new List<User>();
        }

        [DataMember]
        public string RoleName { get; set; }

        [DataMember]
        public bool IsSystem { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public RoleType Type { get; set; }

        [DataMember]
        public virtual ICollection<User> Users { get; set; }

        [DataMember]
        public virtual ICollection<Permission> Permissions { get; set; }

        [DataMember]
        public virtual ICollection<Container> Containers { get; set; }
    }
}
