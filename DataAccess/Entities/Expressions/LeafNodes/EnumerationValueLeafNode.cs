
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using DataAccess.Entities.Metadata;

namespace DataAccess.Entities.Expressions.LeafNodes
{
    public class EnumerationValueLeafNode : LeafNode
    {
        public Guid? EnumerationTypeId { get; set; }

        public virtual EnumerationType EnumerationType { get; set; }

        public Guid? EnumerationValueId { get; set; }

        public virtual EnumerationValue EnumerationValue { get; set; }
    }
}
