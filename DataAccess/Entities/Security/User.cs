using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataAccess.EntityFramework.Entities;

namespace DataAccess.EntityFramework.Entities.Security
{
    public class User : BaseObject
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }


        public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

        public virtual Container Container { get; set; }

        public virtual ICollection<UsersGroup> Groups { get; set; } = new HashSet<UsersGroup>();
    }
}
