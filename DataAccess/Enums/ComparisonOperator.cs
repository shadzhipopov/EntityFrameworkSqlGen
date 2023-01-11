
namespace Model.Enums
{
    public enum ComparisonOperator
    {
        Equals,
        NotEquals,
        GreaterThan,
        GreaterThanOrEqualTo,
        LessThan,
        LessThanOrEqualTo
    }

    public static class ComparisonOperationExtensions
    {
        public static ComparisonOperator GetNegatedOperation(this ComparisonOperator operation)
        {
            switch (operation)
            {
                case ComparisonOperator.Equals:
                    return ComparisonOperator.NotEquals;
                case ComparisonOperator.GreaterThan:
                    return ComparisonOperator.LessThanOrEqualTo;
                case ComparisonOperator.GreaterThanOrEqualTo:
                    return ComparisonOperator.LessThan;
                case ComparisonOperator.LessThan:
                    return ComparisonOperator.GreaterThanOrEqualTo;
                case ComparisonOperator.LessThanOrEqualTo:
                    return ComparisonOperator.GreaterThan;
                case ComparisonOperator.NotEquals:
                    return ComparisonOperator.Equals;
                default:
                    throw new ArgumentException("The selected operation cannot be negated!");      
            }
        }
    }
}
