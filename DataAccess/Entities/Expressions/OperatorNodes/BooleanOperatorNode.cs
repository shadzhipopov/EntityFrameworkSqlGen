using Model.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DataAccess.Entities.Expressions.OperatorNodes
{
    [DataContract(IsReference = true)]
    public abstract class BooleanOperatorNode : ChildrenOperatorNode
    {
        public BooleanOperator Operator { get; set; }
    }
}
