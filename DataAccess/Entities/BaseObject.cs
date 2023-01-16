namespace DataAccess.EntityFramework.Entities
{
    public partial class BaseObject
    {
        public Guid Id { get; set; }

        public BaseObject()
        {
            Id = Guid.NewGuid();
        }

        public bool IsDeleted { get; set; }
    }
}
