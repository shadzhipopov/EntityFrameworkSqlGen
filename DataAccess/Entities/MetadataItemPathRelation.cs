using Model;
using Model.Expressions.LeafNodes;

namespace DataAccess.Entities
{
    public class MetadataItemPathRelation : BaseObject
    {
        public int Index { get; set; }

        public Guid PathNodeId { get; set; }

        public MetadataItemPathNode PathNode { get; set; }

        public Guid RelationId { get; set; }

        public virtual BusinessObjectRelation Relation { get; set; }
    }
}
