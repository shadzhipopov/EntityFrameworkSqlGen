using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataAccess.Entities.Security
{
    [DataContract(IsReference = true)]
    public class UsersGroup : BaseObject
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public virtual ICollection<User> Users { get; set; }
    }
}
