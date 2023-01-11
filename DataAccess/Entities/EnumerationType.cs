using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Model;

namespace DataAccess.Entities
{
    [DataContract(IsReference = true)]
    public class EnumerationType : BaseObject
    {
        
        public string Name { get; set; }

        
        public bool CanUserModify { get; set; }

        
        public virtual ObservableCollection<EnumerationValue> Values { get; set; }

        public virtual List<BusinessProperty> UsedInProperties { get; set; }
    }
}
