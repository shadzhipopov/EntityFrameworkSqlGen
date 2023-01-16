using System;
using System.Linq;
using DataAccess.EntityFramework.Entities;


namespace DataAccess.EntityFramework.Entities.Metadata
{

    public class EnumerationValueEntity : BaseObject
    {

        public Guid EnumerationTypeId { get; set; }


        public virtual EnumerationTypeEntity EnumerationType { get; set; }


        public string Value { get; set; }


        public string Abbreviation { get; set; }
    }
}
