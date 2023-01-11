using Model.Enums;

using DataAccess.Entities.Metadata;

namespace DataAccess.Entities.Expressions.OperatorNodes
{
    
    public class QueryExpression : ChildrenOperatorNode//, IQuerySource
    {

        public QueryType QueryType { get; set; }

        public Guid FromId { get; set; }

        public virtual BusinessObject From { get; set; }
    }
}
