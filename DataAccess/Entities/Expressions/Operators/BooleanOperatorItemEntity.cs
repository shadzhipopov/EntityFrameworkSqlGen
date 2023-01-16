using DataAccess.EntityFramework.Entities.Expressions.Leafs;
using Model.Enums;

namespace DataAccess.EntityFramework.Entities.Expressions.OperatorNodes
{
    public abstract class BooleanOperatorItemEntity : BooleanOperatorEntity
    {
        public virtual LeafEntity NodeToCheck { get; set; }

        public BooleanOperatorValueType ValueToCheck { get; set; }
    }
}
