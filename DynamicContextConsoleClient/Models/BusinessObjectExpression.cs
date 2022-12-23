﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DynamicContextConsoleClient.Models
{
    public partial class BusinessObjectExpression
    {
        public BusinessObjectExpression()
        {
            BusinessProperties = new HashSet<BusinessProperty>();
            ExpressionNodes = new HashSet<ExpressionNode>();
            PageFilters = new HashSet<Page>();
            PageQueries = new HashSet<Page>();
            Permissions = new HashSet<Permission>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool? ApplyToAllPages { get; set; }
        public bool IsShared { get; set; }
        public int Type { get; set; }
        public Guid BusinessObjectId { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsValidatingProperty { get; set; }
        public Guid? TargetPropertyId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual BusinessObject BusinessObject { get; set; }
        public virtual BusinessProperty TargetProperty { get; set; }
        public virtual ICollection<BusinessProperty> BusinessProperties { get; set; }
        public virtual ICollection<ExpressionNode> ExpressionNodes { get; set; }
        public virtual ICollection<Page> PageFilters { get; set; }
        public virtual ICollection<Page> PageQueries { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}