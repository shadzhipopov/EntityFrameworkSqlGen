using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;


namespace DataAccess.Entities.Expressions.LeafNodes
{
    
    public class ClrEnumerationLeafNode : LeafNode
    {
        [NotMapped]
        public Type EnumerationType { get; set; }


        public string EnumType { get; set; }


        public string SelectedEnumValue { get; set; }
    }
}
