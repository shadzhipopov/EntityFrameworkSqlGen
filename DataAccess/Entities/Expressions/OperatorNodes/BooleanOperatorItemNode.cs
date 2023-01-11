using Model.Enums;
using Model.Expressions.LeafNodes;

namespace Model.Expressions.OperatorNodes
{
    public abstract class BooleanOperatorItemNode : BooleanOperatorNode
    {
        public virtual LeafNode NodeToCheck { get; set; }

        public BooleanOperatorValueType ValueToCheck { get; set; }
    }
}
