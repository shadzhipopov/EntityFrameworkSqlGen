using System;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using DataAccess.EntityFramework.Entities;

namespace DataAccess.EntityFramework.Entities.Metadata
{
    public class ForeignKeyEntity : BaseObject
    {
        public Guid BusinessObjectRelationId { get; set; }


        public BusinessObjectRelationEntity BusinessObjectRelation { get; set; }


        public Guid PrimaryKeyPropertyId { get; set; }


        public Guid ForeignKeyPropertyId { get; set; }


        public string ForeignKeyName { get; set; }


        public BusinessPropertyEntity PrimaryKeyProperty { get; set; }


        public BusinessPropertyEntity ForeignKeyProperty { get; set; }
      
    }
}
