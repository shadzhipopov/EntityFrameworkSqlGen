using Model.Enums;

namespace DataAccess.EntityFramework.Entities.Expressions.OperatorNodes
{
    public abstract class BooleanOperatorEntity : ChildrenOperatorEntity
    {
        public BooleanOperator Operator { get; set; }
    }
}
