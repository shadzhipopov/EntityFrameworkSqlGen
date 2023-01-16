using DataAccess.EntityFramework.Entities;

namespace DataAccess.EntityFramework.Entities.Metadata
{

    public class EnumerationTypeEntity : BaseObject
    {
        public string Name { get; set; }

        public bool CanUserModify { get; set; }

        public virtual ICollection<EnumerationValueEntity> Values { get; set; }

        public virtual ICollection<BusinessPropertyEntity> UsedInProperties { get; set; }
    }
}
