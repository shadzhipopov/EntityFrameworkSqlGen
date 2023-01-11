using Model.Enums;

namespace DataAccess.Entities.Expressions.OperatorNodes
{
    public class ComparisonOperatorNode : ChildrenOperatorNode
    {
        public ComparisonOperator Operation { get; set; }
    }
}
