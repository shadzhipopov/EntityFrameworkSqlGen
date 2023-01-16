using System.ComponentModel.DataAnnotations.Schema;

using System.Collections.ObjectModel;
using DataAccess.EntityFramework.Entities.UI;

namespace DataAccess.EntityFramework.Entities.Metadata
{
    public partial class BusinessObjectEntity : DisplayNameObjectEntity
    {
        public BusinessObjectEntity()
        {
            Expressions = new HashSet<BusinessObjectExpressionEntity>();
            Properties = new HashSet<BusinessPropertyEntity>();
            FromRelations = new HashSet<BusinessObjectRelationEntity>();
            ToRelations = new HashSet<BusinessObjectRelationEntity>();
            Pages = new HashSet<Page>();
        }


        public bool IsDeletedByUser { get; set; }

        public Guid? BaseObjectId { get; set; }

        public virtual BusinessObjectEntity BaseObject { get; set; }

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

        public virtual BusinessModuleEntity BusinessModule { get; set; }

        public virtual BusinessObjectGroupEntity Group { get; set; }

        public virtual BusinessPropertyEntity NameProperty { get; set; }

        public virtual ICollection<BusinessObjectEntity> Descendants { get; set; }

        public virtual ICollection<BusinessObjectExpressionEntity> Expressions { get; set; }

        public virtual ICollection<BusinessObjectRelationEntity> FromRelations { get; set; }

        public virtual ICollection<BusinessObjectRelationEntity> ToRelations { get; set; }

        public virtual ICollection<Page> Pages { get; set; }

        public virtual ICollection<BusinessPropertyEntity> Properties { get; set; }
    }
}
