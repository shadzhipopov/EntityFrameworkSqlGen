using Model.Enums;
using System.Linq.Expressions;


namespace DataAccess.EntityFramework.Entities.Expressions.OperatorNodes
{
    public class AllAnyOperatorEntity : BooleanOperatorItemEntity
    {
        public ComparisonOperator ComparisonOperator { get; set; }
    }
}
