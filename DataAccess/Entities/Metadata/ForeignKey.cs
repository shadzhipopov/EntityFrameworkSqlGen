using System;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;

namespace DataAccess.Entities.Metadata
{
    public class ForeignKey : BaseObject
    {
        public Guid BusinessObjectRelationId { get; set; }


        public BusinessObjectRelation BusinessObjectRelation { get; set; }


        public Guid PrimaryKeyPropertyId { get; set; }


        public Guid ForeignKeyPropertyId { get; set; }


        public string ForeignKeyName { get; set; }


        public BusinessProperty PrimaryKeyProperty { get; set; }


        public BusinessProperty ForeignKeyProperty { get; set; }

        //helper properties
        [NotMapped]
        public BusinessObject PrimaryKeyObject
        {
            get
            {
                return PrimaryKeyProperty != null ? PrimaryKeyProperty.BusinessObject : null;
            }
        }

        [NotMapped]
        public BusinessObject ForeignKeyObject
        {
            get
            {
                return ForeignKeyProperty != null ? ForeignKeyProperty.BusinessObject : null;
            }
        }

        [NotMapped]
        public bool NeedsDataMapping
        {
            get
            {
                var needsMapping = ForeignKeyProperty.MappingProperties != null &&
                    ForeignKeyProperty.MappingProperties.Any();
                return needsMapping;
            }
        }
    }
}
