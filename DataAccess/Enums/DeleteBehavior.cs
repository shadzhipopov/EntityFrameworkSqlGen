using System;

namespace Model.Enums
{
    public enum DeleteBehavior
    {
        Cascade,
        Restricted,                
        //disassociate - used only in 0:1..* relations
        SetToNull
    }
}
