using Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;

namespace Model.Expressions.OperatorNodes
{
    public class CastFunctionNode : FunctionWithParametersNode
    {
        public FdbaDataType CastType { get; set; }
    }
}
