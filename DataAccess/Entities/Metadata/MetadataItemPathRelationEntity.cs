using DataAccess.EntityFramework.Entities;
using DataAccess.EntityFramework.Entities.Expressions.Leafs;

namespace DataAccess.EntityFramework.Entities.Metadata
{
    public class MetadataItemPathRelationEntity : BaseObject
    {
        public int Index { get; set; }

        public Guid PathNodeId { get; set; }

        public Expressions.Leafs.MetadataItemPathEntity PathNode { get; set; }

        public Guid RelationId { get; set; }

        public virtual BusinessObjectRelationEntity Relation { get; set; }
    }
}
