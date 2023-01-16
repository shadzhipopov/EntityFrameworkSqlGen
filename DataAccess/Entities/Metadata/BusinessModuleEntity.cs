using System.Collections.ObjectModel;

namespace DataAccess.EntityFramework.Entities.Metadata
{
    public class BusinessModuleEntity : DisplayNameObjectEntity
    {
        public BusinessModuleEntity()
        {
            BusinessObjects = new ObservableCollection<BusinessObjectEntity>();
        }

        public Guid? DatabaseInfoId { get; set; }

        public virtual ICollection<BusinessObjectEntity> BusinessObjects { get; set; }

        public virtual DatabaseInfoEntity Database { get; set; }
    }
}
