using DataAccess.EntityFramework.Entities.Metadata;

namespace DataAccess.EntityFramework.Entities.Expressions.Leafs
{
    public class BusinessPropertyLeafEntity : MetadataItemPathEntity
    {
        public Guid? BusinessPropertyId { get; set; }

        public virtual BusinessPropertyEntity BusinessProperty { get; set; }
    }
}
