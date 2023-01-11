namespace DataAccess.Entities.Expressions.OperatorNodes
{
    public abstract class ChildrenOperatorNode : ExpressionNode
    {
        public ChildrenOperatorNode()
        {
            Children = new List<ExpressionNode>();
        }

        public virtual ICollection<ExpressionNode> Children { get; set; }

    }
}
