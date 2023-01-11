using System;
using System.Linq;


namespace DataAccess.Entities.Metadata
{
    
    public class EnumerationValue : BaseObject
    {

        public Guid EnumerationTypeId { get; set; }


        public virtual EnumerationType EnumerationType { get; set; }


        public string Value { get; set; }


        public string Abbreviation { get; set; }
    }
}
