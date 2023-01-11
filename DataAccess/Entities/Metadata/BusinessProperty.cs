namespace DataAccess.Entities.Metadata
{
    public partial class BusinessProperty : DisplayNameObject
    {
        public BusinessProperty()
        {
            MappedProperties = new HashSet<BusinessProperty>();
            MappingProperties = new HashSet<BusinessProperty>();
            ValidationExpressions = new HashSet<BusinessObjectExpression>();
        }

        public Guid BusinessObjectId { get; set; }

        public Guid? EnumerationTypeId { get; set; }

        public bool IsDisabled { get; set; }

        public int OrderIndex { get; set; }

        public string MinValue { get; set; }

        public string MaxValue { get; set; }

        public virtual BusinessPropertyType Type { get; set; }

        public EnumerationType Enumeration { get; set; }

        //only for mapping purposes when importing data
        //intentionally string and DbColumnType to possibly support more than SqlServer in future
        //could be OriginalType or SourceType if we decide to support different source than database

        public string OriginalImportColumnType { get; set; }

        public string DefaultValue { get; set; }

        public bool IsPrimaryKey { get; set; }

        public bool IsForeignKey { get; set; }

        public virtual BusinessObject BusinessObject { get; set; }

        public virtual ICollection<BusinessObjectExpression> ValidationExpressions { get; set; }

        public virtual ImportPropertyInfo ImportInformation { get; set; }

        public virtual ICollection<BusinessProperty> MappingProperties { get; set; }

        public virtual ICollection<BusinessProperty> MappedProperties { get; set; }

        public Guid? MappingPropertyId { get; set; }

        public Guid? ComputeExpressionId { get; set; }

        public BusinessObjectExpression ComputeExpression { get; set; }

        public bool IsServiceProperty { get; set; }

    }
}
