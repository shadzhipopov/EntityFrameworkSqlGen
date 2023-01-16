using DataAccess.EntityFramework.Entities.Metadata;

namespace DataAccess.EntityFramework.Entities.Security.Permissions
{
    public class DataFilterPermission : Permission
    {
        public Guid FilterExpressionId { get; set; }

        public virtual BusinessObjectExpressionEntity FilterExpression { get; set; }
    }
}
