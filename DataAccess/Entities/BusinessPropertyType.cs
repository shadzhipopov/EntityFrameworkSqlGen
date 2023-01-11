using Model;
using Model.Enums;
using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DataAccess.Entities
{
    [DataContract]
    public class BusinessPropertyType : BaseObject
    {
        public BusinessPropertyType()
        {
        }

        public BusinessPropertyType(FdbaDataType dataType)
        {
            DataType = dataType;
        }

        public BusinessPropertyType(FdbaDataType dataType, bool isRequired) : this(dataType)
        {
            IsRequired = isRequired;
        }


        public BusinessProperty BusinessProperty { get; set; }


        public FdbaDataType DataType { get; set; }


        public int? NumericPrecision { get; set; }


        public int? NumericScale { get; set; }


        public int? MinCharacterLength { get; set; }


        public long? MaxCharacterLength { get; set; }


        public bool IsRequired { get; set; }


        public bool IsSigned { get; set; }

        public override string ToString()
        {
            StringBuilder propertyDescriptionBuilder = new StringBuilder();
            propertyDescriptionBuilder.Append(DataType.ToString());

            if (MaxCharacterLength.HasValue)
            {
                var typeLimit = string.Format("({0})", MaxCharacterLength.Value);
                propertyDescriptionBuilder.Append(typeLimit);
            }
            else if (NumericPrecision.HasValue && NumericPrecision.Value != 0)
            {
                string typeLimit;
                if (NumericScale.HasValue)
                {
                    typeLimit = string.Format("({0}, {1})", NumericPrecision.Value, NumericScale.Value);
                }
                else
                {
                    typeLimit = string.Format("({0})", NumericPrecision.Value);
                }

                propertyDescriptionBuilder.Append(typeLimit);

            }
            propertyDescriptionBuilder.Append(", ");
            string isNull = IsRequired ? "not null" : "null";
            propertyDescriptionBuilder.Append(isNull);
            propertyDescriptionBuilder.Append(")");

            string result = propertyDescriptionBuilder.ToString();
            return result;
        }
    }
}
