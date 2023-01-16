
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using DataAccess.EntityFramework.Entities.Metadata;

namespace DataAccess.EntityFramework.Entities.Expressions.Leafs
{
    public class EnumerationValueLeafEntity : LeafEntity
    {
        public Guid? EnumerationTypeId { get; set; }

        public virtual EnumerationTypeEntity EnumerationType { get; set; }

        public Guid? EnumerationValueId { get; set; }

        public virtual EnumerationValueEntity EnumerationValue { get; set; }
    }
}
