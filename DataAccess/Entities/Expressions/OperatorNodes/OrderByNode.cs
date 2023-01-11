using System.Runtime.Serialization;
using Model.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace Model.Expressions.OperatorNodes
{
    [DataContract(IsReference = true)]
    public class OrderByNode : ChildrenOperatorNode
    {
    }
}
