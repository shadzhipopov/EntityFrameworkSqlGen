using Model.Enums;

namespace Model.Expressions.OperatorNodes
{
    public class OrderByItemNode : ChildrenOperatorNode
    {
        public OrderDirection OrderDirection
        {
            get;
            set;
        }
    }
}
