using DataAccess.Entities.Metadata;

namespace DataAccess.Entities.Security.Permissions.Business
{
    public class DataFilterPermission : Permission
    {
        public Guid FilterExpressionId { get; set; }

        public BusinessObjectExpression FilterExpression { get; set; }
    }
}
