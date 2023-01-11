using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataAccess.Entities.Security
{
    [DataContract(IsReference = true)]
    public class Container : BaseObject
    {
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
