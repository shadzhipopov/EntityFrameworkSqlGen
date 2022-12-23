﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DynamicContextConsoleClient.Models
{
    public partial class BusinessProperty
    {
        public BusinessProperty()
        {
            BusinessObjectExpressions = new HashSet<BusinessObjectExpression>();
            BusinessObjects = new HashSet<BusinessObject>();
            ExpressionNodeBusinessProperties = new HashSet<ExpressionNode>();
            ExpressionNodeCountProperties = new HashSet<ExpressionNode>();
            ForeignKeyForeignKeyProperties = new HashSet<ForeignKey>();
            ForeignKeyPrimaryKeyProperties = new HashSet<ForeignKey>();
            Permissions = new HashSet<Permission>();
            MappedProperties = new HashSet<BusinessProperty>();
            MappingProperties = new HashSet<BusinessProperty>();
        }

        public Guid Id { get; set; }
        public Guid BusinessObjectId { get; set; }
        public Guid? EnumerationTypeId { get; set; }
        public bool IsDisabled { get; set; }
        public int OrderIndex { get; set; }
        public string MinValue { get; set; }
        public string MaxValue { get; set; }
        public string OriginalImportColumnType { get; set; }
        public string DefaultValue { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool IsForeignKey { get; set; }
        public Guid? MappingPropertyId { get; set; }
        public Guid? ComputeExpressionId { get; set; }
        public bool IsServiceProperty { get; set; }
        public bool IsDeleted { get; set; }
        public string DisplayName { get; set; }
        public string PhysicalName { get; set; }

        public virtual BusinessObject BusinessObject { get; set; }
        public virtual BusinessObjectExpression ComputeExpression { get; set; }
        public virtual EnumerationType EnumerationType { get; set; }
        public virtual BusinessPropertyType BusinessPropertyType { get; set; }
        public virtual ImportPropertyInfo ImportPropertyInfo { get; set; }
        public virtual ICollection<BusinessObjectExpression> BusinessObjectExpressions { get; set; }
        public virtual ICollection<BusinessObject> BusinessObjects { get; set; }
        public virtual ICollection<ExpressionNode> ExpressionNodeBusinessProperties { get; set; }
        public virtual ICollection<ExpressionNode> ExpressionNodeCountProperties { get; set; }
        public virtual ICollection<ForeignKey> ForeignKeyForeignKeyProperties { get; set; }
        public virtual ICollection<ForeignKey> ForeignKeyPrimaryKeyProperties { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }

        public virtual ICollection<BusinessProperty> MappedProperties { get; set; }
        public virtual ICollection<BusinessProperty> MappingProperties { get; set; }
    }
}