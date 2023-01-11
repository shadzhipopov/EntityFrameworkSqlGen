using DataAccess.Entities.Metadata;

namespace DataAccess.Entities.Expressions.LeafNodes
{
    public abstract class MetadataItemPathNode : LeafNode
    {
        public virtual ICollection<MetadataItemPathRelation> PathToTarget { get; set; }
    }
}
