namespace DataAccess.Entities.Metadata
{

    public class EnumerationType : BaseObject
    {
        public string Name { get; set; }

        public bool CanUserModify { get; set; }

        public virtual ICollection<EnumerationValue> Values { get; set; }

        public virtual ICollection<BusinessProperty> UsedInProperties { get; set; }
    }
}
