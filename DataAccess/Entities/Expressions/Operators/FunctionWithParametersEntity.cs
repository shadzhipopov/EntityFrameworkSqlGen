using Model.Functions;

namespace DataAccess.EntityFramework.Entities.Expressions.OperatorNodes
{
    public class FunctionWithParametersEntity : ChildrenOperatorEntity
    {
        public virtual string FunctionName { get; set; }

        public virtual FunctionType FunctionType { get; set; }
    }
}
