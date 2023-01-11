using Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


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

        public Guid FromObjectId { get; set; }

        public Guid ToObjectId { get; set; }

        public RelationEnd FromEnd { get; set; }

        public RelationEnd ToEnd { get; set; }

        public string FromRelationName { get; set; }

        public string ToRelationName { get; set; }



        public virtual BusinessObject ManyToManyObject { get; set; }

        public virtual ICollection<ForeignKey> ForeignKeys { get; set; }

        public virtual BusinessObject FromObject { get; set; }

        public virtual BusinessObject ToObject { get; set; }
    }
}
