namespace DataAccess.EntityFramework.Entities.Metadata
{
    public partial class BusinessPropertyEntity : DisplayNameObjectEntity
    {
        public BusinessPropertyEntity()
        {
            MappedProperties = new HashSet<BusinessPropertyEntity>();
            MappingProperties = new HashSet<BusinessPropertyEntity>();
            ValidationExpressions = new HashSet<BusinessObjectExpressionEntity>();
        }

        public Guid BusinessObjectId { get; set; }

        public Guid? EnumerationTypeId { get; set; }

        public bool IsDisabled { get; set; }

        public int OrderIndex { get; set; }

        public string MinValue { get; set; }

        public string MaxValue { get; set; }

        public virtual BusinessPropertyTypeEntity Type { get; set; }

        public EnumerationTypeEntity Enumeration { get; set; }

        //only for mapping purposes when importing data
        //intentionally string and DbColumnType to possibly support more than SqlServer in future
        //could be OriginalType or SourceType if we decide to support different source than database

        public string OriginalImportColumnType { get; set; }

        public string DefaultValue { get; set; }

        public bool IsPrimaryKey { get; set; }

        public bool IsForeignKey { get; set; }

        public virtual BusinessObjectEntity BusinessObject { get; set; }

        public virtual ICollection<BusinessObjectExpressionEntity> ValidationExpressions { get; set; }

        public virtual ImportPropertyInfoEntity ImportInformation { get; set; }

        public virtual ICollection<BusinessPropertyEntity> MappingProperties { get; set; }

        public virtual ICollection<BusinessPropertyEntity> MappedProperties { get; set; }

        public Guid? MappingPropertyId { get; set; }

        public Guid? ComputeExpressionId { get; set; }

        public virtual BusinessObjectExpressionEntity ComputeExpression { get; set; }

        public bool IsServiceProperty { get; set; }

    }
}
