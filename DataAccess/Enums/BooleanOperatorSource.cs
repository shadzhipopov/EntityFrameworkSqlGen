using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Enums
{
    //add converter depending on property type
    public enum BooleanOperatorSource
    {
        [Display(Name = "Subquery")]
        Subquery,
        [Display(Name = "Constants List")]
        ConstantList,
        //check if property is enumeration and hide if not
        [Display(Name = "Enumeration Values")]
        EnumerationValues        
    }
}
