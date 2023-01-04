using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCRUD.Metadata
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

    public enum RelationType
    {
        OneToZeroOrOne,
        OneToMany,
        ManyToOne,
        ManyToZeroOrOne,
        ManyToMany
    }
}
