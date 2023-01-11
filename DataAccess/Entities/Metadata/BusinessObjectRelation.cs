using Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;

namespace DataAccess.Entities.Metadata
{
    public class BusinessObjectRelation : BaseObject
    {
        public BusinessObjectRelation()
        {
            ForeignKeys = new HashSet<ForeignKey>();
        }

        public string RelationName { get; set; }

        public bool IsBaseObjectRelation { get; set; }

        public Guid? ManyToManyObjectId { get; set; }

        public BusinessObject ManyToManyObject { get; set; }

        public virtual ICollection<ForeignKey> ForeignKeys { get; set; }


        public Guid FromObjectId { get; set; }

        public Guid ToObjectId { get; set; }

        public BusinessObject FromObject { get; set; }

        public BusinessObject ToObject { get; set; }

        public RelationEnd FromEnd { get; set; }

        public RelationEnd ToEnd { get; set; }

        public string FromRelationName { get; set; }

        public string ToRelationName { get; set; }
    }
}
