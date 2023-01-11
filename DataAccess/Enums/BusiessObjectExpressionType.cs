using System;

namespace Model.Enums
{
    public enum BusinessObjectExpressionType
    {
        View,//defined for business object
        //operate on data rather than generating sql
        Predicate,
        //UiAction, //enabled, disabled, visible
        ComputedProperty,
        //Workflow condition
        //Query
        //Predicate
        Edit
    }
}
