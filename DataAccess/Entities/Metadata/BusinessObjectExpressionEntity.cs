using Model.Enums;
using DataAccess.EntityFramework.Entities;
using DataAccess.EntityFramework.Entities.Expressions;

namespace DataAccess.EntityFramework.Entities.Metadata
{
    public partial class BusinessObjectExpressionEntity : BaseObject
    {
        public BusinessObjectExpressionEntity()
        {
            Nodes = new HashSet<ExpressionEntity>();
        }

        public string Name { get; set; }

        public bool? ApplyToAllPages { get; set; }

        public bool IsShared { get; set; }

        public BusinessObjectExpressionType Type { get; set; }

        public Guid BusinessObjectId { get; set; }

        public string ErrorMessage { get; set; }

        //ValidationTarget = property or object
        public bool IsValidatingProperty { get; set; }

        public Guid? TargetPropertyId { get; set; }

        public virtual BusinessPropertyEntity TargetProperty { get; set; }

        public virtual ICollection<ExpressionEntity> Nodes { get; set; }

        public virtual BusinessObjectEntity BusinessObject { get; set; }
    }
}
