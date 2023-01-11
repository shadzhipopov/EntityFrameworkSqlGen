using System;

using DataAccess.Entities.UI;

namespace DataAccess.Entities.Security.Permissions
{    
    public class DenyPageAccessPermission : Permission
    {        
        public Guid PageId { get; set; }
        
        public virtual Page Page { get; set; }
    }
}
