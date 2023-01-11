using Model.Enums;

namespace Model.Expressions.OperatorNodes
{
    public class InOperatorNode : BooleanOperatorItemNode
    {
        public BooleanOperatorSource ValuesSource { get; set; }
    }
}
