namespace DataAccess.EntityFramework.Entities.Expressions.OperatorNodes
{
    public abstract class ChildrenOperatorEntity : ExpressionEntity
    {
        public ChildrenOperatorEntity()
        {
            Children = new List<ExpressionEntity>();
        }

        public virtual ICollection<ExpressionEntity> Children { get; set; }

    }
}
