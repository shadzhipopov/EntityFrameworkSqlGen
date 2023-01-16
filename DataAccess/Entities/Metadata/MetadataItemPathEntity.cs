using System;
using System.Collections.Generic;
using Model.Enums;

namespace DataAccess.EntityFramework.Entities.Metadata
{
    public class MetadataItemPathEntity
    {
        public MetadataItemPathEntity()
        {
            Relations = new List<MetadataItemPathRelationEntity>();
        }

        public List<MetadataItemPathRelationEntity> Relations { get; set; }
    }
}
