using DataAccess.EntityFramework.Entities;
using DataAccess.EntityFramework.Entities.Expressions.OperatorNodes;
using DataAccess.EntityFramework.Entities.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;


namespace DataAccess.EntityFramework.Entities.Expressions
{
    public abstract class ExpressionEntity : BaseObject
    {
        public Guid? QueryId { get; set; }
        public virtual QueryExpressionEntity Query { get; set; }

        public int ExecutionOrder { get; set; }
        public Guid? ParentId { get; set; }


        public virtual ChildrenOperatorEntity Parent { get; set; }


        public string UserDefinedAlias { get; set; }


        public Guid BusinessObjectExpressionId { get; set; }

        public virtual BusinessObjectExpressionEntity BusinessObjectExpression { get; set; }

        public bool IsAddedBySystem { get; set; }
    }
}
