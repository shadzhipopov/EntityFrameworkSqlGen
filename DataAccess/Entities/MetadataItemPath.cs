using System;
using System.Collections.Generic;
using Model.Enums;

namespace DataAccess.Entities
{
    public class MetadataItemPath
    {
        public MetadataItemPath()
        {
            Relations = new List<MetadataItemPathRelation>();
        }

        public List<MetadataItemPathRelation> Relations { get; set; }
    }
}
