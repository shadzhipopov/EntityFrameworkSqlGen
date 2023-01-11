using DataAccess.Entities.Expressions.OperatorNodes;
using DataAccess.Entities.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;

namespace DataAccess.Entities.Expressions
{
    public abstract class ExpressionNode : BaseObject
    {
        public Guid? QueryId { get; set; }
        public virtual QueryExpression Query { get; set; }

        public int ExecutionOrder { get; set; }
        public Guid? ParentId { get; set; }


        public virtual ChildrenOperatorNode Parent { get; set; }


        public string UserDefinedAlias { get; set; }


        public Guid BusinessObjectExpressionId { get; set; }

        public virtual BusinessObjectExpression BusinessObjectExpression { get; set; }

        public bool IsAddedBySystem { get; set; }
    }
}
