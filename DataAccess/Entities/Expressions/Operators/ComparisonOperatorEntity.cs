using Model.Enums;

namespace DataAccess.EntityFramework.Entities.Expressions.OperatorNodes
{
    public class ComparisonOperatorEntity : ChildrenOperatorEntity
    {
        public ComparisonOperator Operation { get; set; }
    }
}
