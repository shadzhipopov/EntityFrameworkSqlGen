using DataAccess.Entities.Metadata;

namespace DataAccess.Entities.Expressions.LeafNodes
{
    public class BusinessPropertyLeafNode : MetadataItemPathNode
    {
        public BusinessPropertyLeafNode()
        {
            PathToTarget = new List<MetadataItemPathRelation>();
        }

        public Guid? BusinessPropertyId { get; set; }

        public virtual BusinessProperty BusinessProperty { get; set; }
    }
}
