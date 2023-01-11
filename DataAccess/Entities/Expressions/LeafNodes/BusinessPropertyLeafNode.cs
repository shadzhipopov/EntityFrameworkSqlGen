using DataAccess.Entities;

namespace Model.Expressions.LeafNodes
{
    public class BusinessPropertyLeafNode : MetadataItemPathNode
    {
        public BusinessPropertyLeafNode()
        {
            this.PathToTarget = new List<MetadataItemPathRelation>();
        }

        public Guid? BusinessPropertyId { get; set; }
        
        public virtual BusinessProperty BusinessProperty { get; set; }
    }
}
