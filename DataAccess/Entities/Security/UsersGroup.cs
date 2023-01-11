using System.Collections.Generic;

namespace DataAccess.Entities.Security
{    
    public class UsersGroup : BaseObject
    {        
        public string Name { get; set; }
        
        public virtual ICollection<User> Users { get; set; } = new List<User>(); 
    }
}
