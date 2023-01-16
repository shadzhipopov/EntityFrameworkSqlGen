using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.EntityFramework.Entities;

namespace DataAccess.EntityFramework.Entities.Metadata
{
    public class BusinessObjectGroupEntity : BaseObject
    {
        public string GroupName { get; set; }
        public bool IsMenuGroup { get; set; }

        public virtual ICollection<BusinessObjectEntity> BusinessObjects { get; set; }
    }
}
