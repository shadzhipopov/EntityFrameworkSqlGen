using System;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.EntityFramework.Entities;


namespace DataAccess.EntityFramework.Entities.Metadata
{

    public class ImportPropertyInfoEntity : BaseObject
    {

        public Guid ConvertedPropertyId { get; set; }

        //when running the import more than once, we need to know what was the original name
        //also, this information is needed for the data import, otherwise the data import will need to know for
        //bot the original import data and the converterted data and how to convert between them

        public string OriginalImportName { get; set; }


        public DatabaseDataTypeEntity OriginalPropertyType { get; set; }


        public BusinessPropertyEntity ConvertedProperty { get; set; }
    }
}
