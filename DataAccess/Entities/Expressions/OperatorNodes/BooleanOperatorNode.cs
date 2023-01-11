using Model.Enums;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataAccess.Entities.Expressions.OperatorNodes
{
    
    public abstract class BooleanOperatorNode : ChildrenOperatorNode
    {
        public BooleanOperator Operator { get; set; }
    }
}
