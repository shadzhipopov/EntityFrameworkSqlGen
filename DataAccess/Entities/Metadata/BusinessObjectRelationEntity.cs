using DataAccess.EntityFramework.Entities;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace DataAccess.EntityFramework.Entities.Metadata
{
    public class BusinessObjectRelationEntity : BaseObject
    {
        public BusinessObjectRelationEntity()
        {
            ForeignKeys = new HashSet<ForeignKeyEntity>();
        }

        public string RelationName { get; set; }

        public bool IsBaseObjectRelation { get; set; }

        public Guid? ManyToManyObjectId { get; set; }

        public Guid FromObjectId { get; set; }

        public Guid ToObjectId { get; set; }

        public RelationEnd FromEnd { get; set; }

        public RelationEnd ToEnd { get; set; }

        public string FromRelationName { get; set; }

        public string ToRelationName { get; set; }



        public virtual BusinessObjectEntity ManyToManyObject { get; set; }

        public virtual ICollection<ForeignKeyEntity> ForeignKeys { get; set; }

        public virtual BusinessObjectEntity FromObject { get; set; }

        public virtual BusinessObjectEntity ToObject { get; set; }
    }
}
