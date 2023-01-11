using DataAccess.Entities;

namespace Model.Expressions.LeafNodes
{
    public class BusinessObjectLeafNode : MetadataItemPathNode
    {
        public Guid TargetObjectId { get; set; }
        public virtual BusinessObject TargetObject { get; set; }
        
    }
}
