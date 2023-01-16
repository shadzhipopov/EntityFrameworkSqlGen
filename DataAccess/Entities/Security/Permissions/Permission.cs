using System;
using DataAccess.EntityFramework.Entities;


namespace DataAccess.EntityFramework.Entities.Security.Permissions
{
    public abstract class Permission : BaseObject
    {
        public Guid RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
