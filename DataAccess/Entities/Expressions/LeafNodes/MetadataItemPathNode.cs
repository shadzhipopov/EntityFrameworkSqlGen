using DataAccess.Entities;

namespace Model.Expressions.LeafNodes
{
    public abstract class MetadataItemPathNode : LeafNode
    {
        public virtual ICollection<MetadataItemPathRelation> PathToTarget { get; set; }
    }
}
