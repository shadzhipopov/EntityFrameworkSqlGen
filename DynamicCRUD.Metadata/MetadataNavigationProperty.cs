using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCRUD.Metadata
{
    public class MetadataNavigationProperty
    {
        public string RelationName { get; set; }
        public string Name { get; set; }
        public string OppositeObjectName { get; set; }
        public string OppositeNavigationName { get; set; }

        public string ForeignKeyPropertyName { get; set; }

        public RelationEnd Type { get; set; }

        public RelationType RelationType { get; set; }

        public bool IsPrincipal { get; set; }


    }
}
