using DataAccess.Entities.Metadata;

namespace DataAccess.Entities.Expressions.LeafNodes
{
    public class BusinessPropertyLeafNode : MetadataItemPathNode
    {
        public Guid? BusinessPropertyId { get; set; }

        public virtual BusinessProperty BusinessProperty { get; set; }
    }
}
