using Model.Enums;
using System;
using System.Linq;

using System.Text;

namespace DataAccess.Entities.Metadata
{    
    public class BusinessPropertyType : BaseObject
    {
        public FdbaDataType DataType { get; set; }

        public int? NumericPrecision { get; set; }

        public int? NumericScale { get; set; }

        public int? MinCharacterLength { get; set; }

        public long? MaxCharacterLength { get; set; }

        public bool IsRequired { get; set; }

        public bool IsSigned { get; set; }

        public virtual BusinessProperty BusinessProperty { get; set; }
    }
}
