using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enums
{
    [Flags]
    public enum FdbaDataType
    {
        ShortInteger = 1,
        Integer = 2,
        LongInteger = 4,
        Double = 8,
        Decimal = 16,
        String = 32,
        Date = 64,
        DateTime = 128,
        DateTimeOffset = 256,
        //DateRange       = 512,
        Time = 1024,
        Guid = 2048,
        EmailAddress = 4096,
        PhoneNumber = 8192,
        Boolean = 16384,
        Image = 32768,
        Binary = 65536,
        Xml = 131072,
        Money = 262144,
        Enumeration = 524288,
        All = 524288 * 2
    }
}
