using DataAccess.EntityFramework.Entities;
using Model.Enums;
using System;
using System.Linq;

using System.Text;

namespace DataAccess.EntityFramework.Entities.Metadata
{
    public class BusinessPropertyTypeEntity : BaseObject
    {
        public FdbaDataType DataType { get; set; }

        public int? NumericPrecision { get; set; }

        public int? NumericScale { get; set; }

        public int? MinCharacterLength { get; set; }

        public long? MaxCharacterLength { get; set; }

        public bool IsRequired { get; set; }

        public bool IsSigned { get; set; }

        public virtual BusinessPropertyEntity BusinessProperty { get; set; }
    }
}
