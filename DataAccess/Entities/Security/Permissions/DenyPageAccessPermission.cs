using System;
using DataAccess.EntityFramework.Entities.UI;

namespace DataAccess.EntityFramework.Entities.Security.Permissions
{
    public class DenyPageAccessPermission : Permission
    {
        public Guid PageId { get; set; }

        public virtual Page Page { get; set; }
    }
}
