using System.Collections.Generic;
using DataAccess.EntityFramework.Entities;

namespace DataAccess.EntityFramework.Entities.Security
{
    public class UsersGroup : BaseObject
    {
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
