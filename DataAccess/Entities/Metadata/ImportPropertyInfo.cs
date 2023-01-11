using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataAccess.Entities.Metadata
{
    
    public class ImportPropertyInfo : BaseObject
    {

        public Guid ConvertedPropertyId { get; set; }

        //when running the import more than once, we need to know what was the original name
        //also, this information is needed for the data import, otherwise the data import will need to know for
        //bot the original import data and the converterted data and how to convert between them

        public string OriginalImportName { get; set; }


        public DatabaseDataType OriginalPropertyType { get; set; }


        public BusinessProperty ConvertedProperty { get; set; }
    }
}
