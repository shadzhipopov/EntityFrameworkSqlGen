using DataAccess.Entities.Expressions.LeafNodes;
using Model.Enums;

namespace DataAccess.Entities.Expressions.OperatorNodes
{
    public abstract class BooleanOperatorItemNode : BooleanOperatorNode
    {
        public virtual LeafNode NodeToCheck { get; set; }

        public BooleanOperatorValueType ValueToCheck { get; set; }
    }
}
