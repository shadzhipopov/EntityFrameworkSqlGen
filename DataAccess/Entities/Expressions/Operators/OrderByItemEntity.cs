using Model.Enums;

namespace DataAccess.EntityFramework.Entities.Expressions.OperatorNodes
{
    public class OrderByItemEntity : ChildrenOperatorEntity
    {
        public OrderDirection OrderDirection
        {
            get;
            set;
        }
    }
}
