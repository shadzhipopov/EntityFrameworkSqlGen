using DataAccess.EntityFramework.Entities.Metadata;

namespace DataAccess.EntityFramework.Entities.Expressions.OperatorNodes
{

    public class CountFunctionEntity : AggregateFunctionEntity
    {
        public Guid? CountPropertyId { get; set; }
        public virtual BusinessPropertyEntity CountProperty { get; set; }

        public Guid? CountObjectId { get; set; }
        public virtual BusinessObjectEntity CountObject { get; set; }

        public bool CountAll { get; set; }
    }
}
