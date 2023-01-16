using Model.Enums;
using DataAccess.EntityFramework.Entities.Metadata;

namespace DataAccess.EntityFramework.Entities.Expressions.OperatorNodes
{

    public class QueryExpressionEntity : ChildrenOperatorEntity//, IQuerySource
    {

        public QueryType QueryType { get; set; }

        public Guid FromId { get; set; }

        public virtual BusinessObjectEntity From { get; set; }
    }
}
