using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCRUD.Metadata
{
    public static class FdbaTypeExtensions
    {
        public static Type MapToClrType(this FdbaDataType businessPropertyType)
        {
            switch (businessPropertyType)
            {
                case FdbaDataType.ShortInteger:
                case FdbaDataType.Integer:
                    return typeof(int);
                case FdbaDataType.Money:
                    return typeof(decimal);
                case FdbaDataType.LongInteger:
                    return typeof(Int64);
                case FdbaDataType.Double:
                    return typeof(double);
                case FdbaDataType.Decimal:
                    return typeof(decimal);
                case FdbaDataType.String:
                case FdbaDataType.EmailAddress:
                case FdbaDataType.PhoneNumber:
                    return typeof(string);

                //time is converted to timespan and there is problem with this in the datatable 
                //an exception is thrown when trying to put timespan to date time column
                //case BusinessPropertyDataType.Time:                    
                case FdbaDataType.Date:
                case FdbaDataType.DateTime:
                case FdbaDataType.DateTimeOffset:
                    return typeof(DateTime);
                case FdbaDataType.Guid:
                    return typeof(Guid);
                case FdbaDataType.Boolean:
                    return typeof(bool);
                case FdbaDataType.Binary:
                    return typeof(byte[]);
                default:
                    return typeof(string);
            }
        }
    }
}
