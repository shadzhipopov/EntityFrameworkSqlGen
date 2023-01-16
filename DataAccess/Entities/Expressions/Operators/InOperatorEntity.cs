using Model.Enums;

namespace DataAccess.EntityFramework.Entities.Expressions.OperatorNodes
{
    public class InOperatorEntity : BooleanOperatorItemEntity
    {
        public BooleanOperatorSource ValuesSource { get; set; }
    }
}
