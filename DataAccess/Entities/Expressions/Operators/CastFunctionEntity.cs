using Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace DataAccess.EntityFramework.Entities.Expressions.OperatorNodes
{
    public class CastFunctionEntity : FunctionWithParametersEntity
    {
        public FdbaDataType CastType { get; set; }
    }
}
