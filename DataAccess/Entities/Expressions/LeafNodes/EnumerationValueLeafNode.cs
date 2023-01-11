using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using DataAccess.Entities;

namespace Model.Expressions.LeafNodes
{
    public class EnumerationValueLeafNode : LeafNode
    {      
        public Guid? EnumerationTypeId { get; set; }
      
        public virtual EnumerationType EnumerationType { get; set; }
     
        public Guid? EnumerationValueId { get; set; }
      
        public virtual EnumerationValue EnumerationValue { get; set; }
    }
}
