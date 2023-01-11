using Common;

namespace DataAccess.Entities.Metadata
{
    public class DatabaseDataType : BaseObject
    {
        //this is only because the objects cloner doesn't support constructor with parameters yet
        public DatabaseDataType()
        { }

        public DatabaseDataType(DatabaseServer dbServerType, string dbType, bool isRequired)
        {
            ServerType = dbServerType;
            DbDataType = dbType;
            IsRequired = isRequired;
        }

        public DatabaseDataType(DatabaseServer dbServerType, string dbType, bool isRequired, int? numericPrecision, int? numericScale, long? maxCharacterLength)
            : this(dbServerType, dbType, isRequired)
        {
            NumericPrecision = numericPrecision;
            NumericScale = numericScale;
            MaxCharactedLength = maxCharacterLength;
        }

        public DatabaseDataType(DatabaseServer dbServerType, string dbType, bool isRequired, int? numericPrecision, int? numericScale, long? maxCharacterLength, int dbTypeEnumValue)
            : this(dbServerType, dbType, isRequired, numericPrecision, numericScale, maxCharacterLength)
        {
            DbTypeEnumValue = dbTypeEnumValue;
        }

        public DatabaseServer ServerType { get; set; }

        public string DbDataType { get; set; }
        public int DbTypeEnumValue { get; set; }

        public int? NumericPrecision { get; set; }
        public int? NumericScale { get; set; }
        public long? MaxCharactedLength { get; set; }
        public bool IsRequired { get; set; }
    }
}
