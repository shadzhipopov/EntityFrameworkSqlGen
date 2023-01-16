using DataAccess.EntityFramework.Entities;

namespace DataAccess.EntityFramework.Entities.Security
{
    public class Container : BaseObject
    {
        public Container()
        {
            Users = new List<User>();
            Roles = new List<Role>();
        }

        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
