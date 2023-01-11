using Model.Enums;
using System.Runtime.Serialization;
using DataAccess.Entities;

namespace Model.Expressions.OperatorNodes
{
    [DataContract(IsReference = true)]
    public class QueryExpression : ChildrenOperatorNode//, IQuerySource
    {

        public QueryType QueryType { get; set; }

        public Guid FromId { get; set; }

        public virtual BusinessObject From { get; set; }
    }
}
