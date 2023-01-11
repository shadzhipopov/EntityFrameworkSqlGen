using DataAccess.Entities.Security.Permissions;

namespace DataAccess.Entities.Security
{
    public class Role : BaseObject
    {
        public string RoleName { get; set; }

        public bool IsSystem { get; set; }

        public bool IsActive { get; set; }

        public RoleType Type { get; set; }

        public virtual ICollection<User> Users { get; set; } = new List<User>();

        public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();

        public virtual ICollection<Container> Containers { get; set; } = new List<Container>();
    }
}
