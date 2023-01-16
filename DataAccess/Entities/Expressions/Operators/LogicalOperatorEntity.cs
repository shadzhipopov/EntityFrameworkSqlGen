using Model.Enums;
using System.Linq.Expressions;

namespace DataAccess.EntityFramework.Entities.Expressions.OperatorNodes
{
    public class LogicalOperatorEntity : ChildrenOperatorEntity
    {
        public LogicalOperator LogicalOperator { get; set; }
    }
}
