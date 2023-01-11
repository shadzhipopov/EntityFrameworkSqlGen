using System.Runtime.Serialization;
using Model.Enums;
using System.Linq.Expressions;

namespace Model.Expressions.OperatorNodes
{
    public class LogicalOperatorNode : ChildrenOperatorNode
    {
        public LogicalOperator LogicalOperator { get; set; }                
    }
}
