namespace DataAccess.Entities.Expressions.OperatorNodes
{
    public class AggregateFunctionNode : FunctionWithParametersNode
    {
        public bool DistinctValues { get; set; }
    }
}
