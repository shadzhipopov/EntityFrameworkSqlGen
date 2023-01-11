namespace DataAccess.Entities.Security
{
    public class Container : BaseObject
    {
        public Container()
        {
            this.Users= new List<User>();
            this.Roles= new List<Role>();
        }

        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
