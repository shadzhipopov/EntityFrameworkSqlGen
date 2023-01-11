using DataAccess.Entities.Metadata;

namespace DataAccess.Entities.Security.Permissions
{
    public class DataFilterPermission : Permission
    {
        public Guid FilterExpressionId { get; set; }

        public virtual BusinessObjectExpression FilterExpression { get; set; }
    }
}
