using DataAccess.Entities.Metadata;

namespace DataAccess.Entities.Expressions.LeafNodes
{
    public class BusinessObjectLeafNode : MetadataItemPathNode
    {
        public Guid TargetObjectId { get; set; }
        public virtual BusinessObject TargetObject { get; set; }

    }
}
