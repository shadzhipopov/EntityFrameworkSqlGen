using System.Collections.ObjectModel;

namespace DataAccess.Entities
{
    public class BusinessModule : DisplayNameObject
    {
        public BusinessModule()
        {
            BusinessObjects = new ObservableCollection<BusinessObject>();
        }

        public Guid? DatabaseInfoId { get; set; }

        public virtual ICollection<BusinessObject> BusinessObjects { get; set; }

        public virtual DatabaseInfo Database { get; set; }
    }
}
