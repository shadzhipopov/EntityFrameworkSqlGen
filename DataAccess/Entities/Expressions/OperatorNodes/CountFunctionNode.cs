using System.Runtime.Serialization;
using DataAccess.Entities;

namespace Model.Expressions.OperatorNodes
{
    [DataContract(IsReference = true)]
    public class CountFunctionNode : AggregateFunctionNode
    {
        public Guid? CountPropertyId { get; set; }
        public virtual BusinessProperty CountProperty { get; set; }

        public Guid? CountObjectId { get; set; }
        public virtual BusinessObject CountObject { get; set; }

        public bool CountAll { get; set; }
    }
}
