using System;
using System.Linq;
using System.Runtime.Serialization;

namespace DataAccess.Entities.Metadata
{
    [DataContract(IsReference = true)]
    public class EnumerationValue : BaseObject
    {

        public Guid EnumerationTypeId { get; set; }


        public virtual EnumerationType EnumerationType { get; set; }


        public string Value { get; set; }


        public string Abbreviation { get; set; }
    }
}
