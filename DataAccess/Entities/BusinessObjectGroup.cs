using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccess.Entities
{
    public class BusinessObjectGroup : BaseObject
    {
        public string GroupName { get; set; }
        public bool IsMenuGroup { get; set; }

        public virtual ICollection<BusinessObject> BusinessObjects { get; set; }
    }
}
