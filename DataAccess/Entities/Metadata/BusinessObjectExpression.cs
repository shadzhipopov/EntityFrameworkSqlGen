using Model.Enums;
using DataAccess.Entities.Expressions;

namespace DataAccess.Entities.Metadata
{
    public partial class BusinessObjectExpression : BaseObject
    {
        public BusinessObjectExpression()
        {
            Nodes = new HashSet<ExpressionNode>();
        }

        public string Name { get; set; }

        public bool? ApplyToAllPages { get; set; }

        public virtual ICollection<ExpressionNode> Nodes { get; set; }

        public bool IsShared { get; set; }


        public BusinessObjectExpressionType Type { get; set; }


        public virtual BusinessObject BusinessObject { get; set; }

        public Guid BusinessObjectId { get; set; }

        public string ErrorMessage { get; set; }

        //ValidationTarget = property or object
        public bool IsValidatingProperty { get; set; }

        public Guid? TargetPropertyId { get; set; }

        public virtual BusinessProperty TargetProperty { get; set; }
    }
}
