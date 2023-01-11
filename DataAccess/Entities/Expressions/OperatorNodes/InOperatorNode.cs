using Model.Enums;

namespace DataAccess.Entities.Expressions.OperatorNodes
{
    public class InOperatorNode : BooleanOperatorItemNode
    {
        public BooleanOperatorSource ValuesSource { get; set; }
    }
}
