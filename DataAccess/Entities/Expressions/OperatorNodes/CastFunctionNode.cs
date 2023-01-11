using Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace DataAccess.Entities.Expressions.OperatorNodes
{
    public class CastFunctionNode : FunctionWithParametersNode
    {
        public FdbaDataType CastType { get; set; }
    }
}
