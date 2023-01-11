namespace Model
{
    public partial class BaseObject
    {
        public Guid Id { get; set; }

        public BaseObject()
        {
            this.Id = Guid.NewGuid();
        }

        public bool IsDeleted { get; set; }
    }
}
