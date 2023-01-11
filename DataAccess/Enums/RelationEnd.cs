using System;
using System.ComponentModel;

namespace Model.Enums
{
    public enum RelationEnd
    {
        [Description("One")]
        One,
        [Description("Zero or one")]
        ZeroOrOne,
        [Description("Many")]
        Many
    }
}
