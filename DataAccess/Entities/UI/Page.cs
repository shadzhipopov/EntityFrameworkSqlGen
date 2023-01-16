using DataAccess.EntityFramework.Entities;
using DataAccess.EntityFramework.Entities.Metadata;

namespace DataAccess.EntityFramework.Entities.UI
{
    public class Page : BaseObject
    {

        public int TemplateId { get; set; }


        public Guid PageObjectId { get; set; }


        public BusinessObjectEntity PageObject { get; set; }


        public Guid? QueryId { get; set; }


        public virtual BusinessObjectExpressionEntity Query { get; set; }


        public Guid? FilterId { get; set; }


        public virtual BusinessObjectExpressionEntity Filter { get; set; }

        //public virtual ICollection<Workflow> Actions { get; set; }
    }
}
