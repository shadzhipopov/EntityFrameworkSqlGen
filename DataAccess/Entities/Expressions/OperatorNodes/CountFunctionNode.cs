
using DataAccess.Entities.Metadata;

namespace DataAccess.Entities.Expressions.OperatorNodes
{
    
    public class CountFunctionNode : AggregateFunctionNode
    {
        public Guid? CountPropertyId { get; set; }
        public virtual BusinessProperty CountProperty { get; set; }

        public Guid? CountObjectId { get; set; }
        public virtual BusinessObject CountObject { get; set; }

        public bool CountAll { get; set; }
    }
}
