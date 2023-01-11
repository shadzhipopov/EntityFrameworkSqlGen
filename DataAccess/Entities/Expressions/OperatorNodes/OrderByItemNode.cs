using Model.Enums;

namespace DataAccess.Entities.Expressions.OperatorNodes
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
