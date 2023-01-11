
using Model.Enums;
using System.Linq.Expressions;

namespace DataAccess.Entities.Expressions.OperatorNodes
{
    public class LogicalOperatorNode : ChildrenOperatorNode
    {
        public LogicalOperator LogicalOperator { get; set; }
    }
}
