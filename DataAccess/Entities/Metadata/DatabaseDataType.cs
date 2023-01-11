using Common;

namespace DataAccess.Entities.Metadata
{
    public class DatabaseDataType : BaseObject
    {
        public DatabaseServer ServerType { get; set; }

        public string DbDataType { get; set; }
        public int DbTypeEnumValue { get; set; }

        public int? NumericPrecision { get; set; }
        public int? NumericScale { get; set; }
        public long? MaxCharactedLength { get; set; }
        public bool IsRequired { get; set; }
    }
}
