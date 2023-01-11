using System;


namespace DataAccess.Entities.Security.Permissions
{    
    public abstract class Permission : BaseObject
    {        
        public Guid RoleId { get; set; }
                
        public virtual Role Role { get; set; }
    }
}
