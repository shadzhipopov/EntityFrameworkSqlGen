using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace DataAccess.Entities.Security
{
    [DataContract(IsReference = true)]
    public class User : BaseObject
    {
        public User()
        {
            Roles = new ObservableCollection<Role>();
        }

        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public virtual ICollection<Role> Roles { get; set; }

        [DataMember]
        public virtual Container Container { get; set; }

        [DataMember]
        public virtual ICollection<UsersGroup> Groups { get; set; }
    }
}
