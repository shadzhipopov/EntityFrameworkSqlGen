﻿using Model.Enums;
using System.Linq.Expressions;


namespace DataAccess.Entities.Expressions.OperatorNodes
{
    public class AllAnyOperatorNode : BooleanOperatorItemNode
    {
        public ComparisonOperator ComparisonOperator { get; set; }
    }
}
