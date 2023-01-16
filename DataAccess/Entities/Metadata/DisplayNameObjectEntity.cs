using DataAccess.EntityFramework.Entities;

namespace DataAccess.EntityFramework.Entities.Metadata
{
    public abstract class DisplayNameObjectEntity : BaseObject
    {
        public string DisplayName { get; set; }

        public string PhysicalName { get; set; }
    }
}
