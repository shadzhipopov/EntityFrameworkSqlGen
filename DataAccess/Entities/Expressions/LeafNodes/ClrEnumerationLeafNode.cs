using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace DataAccess.Entities.Expressions.LeafNodes
{
    [DataContract(IsReference = true)]
    public class ClrEnumerationLeafNode : LeafNode
    {
        [NotMapped]
        public Type EnumerationType { get; set; }


        public string EnumType { get; set; }


        public string SelectedEnumValue { get; set; }
    }
}
