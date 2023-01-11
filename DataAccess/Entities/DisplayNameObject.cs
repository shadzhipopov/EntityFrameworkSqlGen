using Model;

namespace DataAccess.Entities
{
    public partial class DisplayNameObject : BaseObject
    {        
        public string DisplayName { get; set; }
        
        public string PhysicalName { get; set; }
    }
}
