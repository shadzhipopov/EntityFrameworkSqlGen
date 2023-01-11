using Model.Functions;

namespace Model.Expressions.OperatorNodes
{
    public class FunctionWithParametersNode : ChildrenOperatorNode
    {
        public virtual string FunctionName { get; set; }

        public virtual FunctionType FunctionType { get; set; }       
    }
}
