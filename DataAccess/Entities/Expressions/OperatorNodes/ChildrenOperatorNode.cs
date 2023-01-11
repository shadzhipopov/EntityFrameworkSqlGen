using System.Collections.ObjectModel;

namespace Model.Expressions.OperatorNodes
{
    public abstract class ChildrenOperatorNode : ExpressionNode
    {
        public ChildrenOperatorNode()
        {
            this.Children = new ObservableCollection<ExpressionNode>();
        }

        public virtual ICollection<ExpressionNode> Children { get; set; }
        
    }
}
