using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;


namespace DataAccess.EntityFramework.Entities.Expressions.Leafs
{

    public class ClrEnumerationEntity : LeafEntity
    {
        [NotMapped]
        public Type EnumerationType { get; set; }


        public string EnumType { get; set; }


        public string SelectedEnumValue { get; set; }
    }
}
