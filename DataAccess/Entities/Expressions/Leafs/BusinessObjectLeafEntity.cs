using DataAccess.EntityFramework.Entities.Metadata;

namespace DataAccess.EntityFramework.Entities.Expressions.Leafs
{
    public class BusinessObjectLeafEntity : MetadataItemPathEntity
    {
        public Guid TargetObjectId { get; set; }
        public virtual BusinessObjectEntity TargetObject { get; set; }

    }
}
