using System.ComponentModel.DataAnnotations.Schema;

using System.Collections.ObjectModel;
using DataAccess.Entities.UI;

namespace DataAccess.Entities.Metadata
{
    public partial class BusinessObject : DisplayNameObject
    {
        public BusinessObject()
        {
            Expressions = new HashSet<BusinessObjectExpression>();
            Properties = new HashSet<BusinessProperty>();
            FromRelations = new HashSet<BusinessObjectRelation>();
            ToRelations = new HashSet<BusinessObjectRelation>();
            Pages = new HashSet<Page>();
        }


        public bool IsDeletedByUser { get; set; }

        public Guid? BaseObjectId { get; set; }

        public virtual BusinessObject BaseObject { get; set; }

        public Guid? NamePropertyId { get; set; }

        public bool IsHierarchicalType { get; set; }

        public string QuickSearchAbbreviation { get; set; }

        public string Database { get; set; }

        public Guid? BusinessObjectGroupId { get; set; }

        public Guid BusinessModuleId { get; set; }

        public bool IsManyToManyConnectingObject { get; set; }


        public bool IsImported { get; set; }

        //once imported, we need to know whether we have customized it in our UI
        //probably everything created from the Admin tool should be directly compiled

        public bool IsCompiled { get; set; }

        public virtual BusinessModule BusinessModule { get; set; }

        public virtual BusinessObjectGroup Group { get; set; }

        public virtual BusinessProperty NameProperty { get; set; }

        public virtual ICollection<BusinessObject> Descendants { get; set; }

        public virtual ICollection<BusinessObjectExpression> Expressions { get; set; }

        public virtual ICollection<BusinessObjectRelation> FromRelations { get; set; }

        public virtual ICollection<BusinessObjectRelation> ToRelations { get; set; }

        public virtual ICollection<Page> Pages { get; set; }

        public virtual ICollection<BusinessProperty> Properties { get; set; }
    }
}
