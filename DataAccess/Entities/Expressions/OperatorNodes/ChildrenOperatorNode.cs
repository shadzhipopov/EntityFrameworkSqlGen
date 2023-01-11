using System.Collections.ObjectModel;

namespace DataAccess.Entities.Expressions.OperatorNodes
{
    public abstract class ChildrenOperatorNode : ExpressionNode
    {
        public ChildrenOperatorNode()
        {
            Children = new ObservableCollection<ExpressionNode>();
        }

        public virtual ICollection<ExpressionNode> Children { get; set; }

    }
}
