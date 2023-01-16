using DataAccess.EntityFramework.Entities.Metadata;

namespace DataAccess.EntityFramework.Entities.Expressions.Leafs
{
    public abstract class MetadataItemPathEntity : LeafEntity
    {
        public virtual ICollection<MetadataItemPathRelationEntity> PathToTarget { get; set; } = new List<MetadataItemPathRelationEntity>();
    }
}
