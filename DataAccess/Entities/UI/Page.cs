using DataAccess.Entities.Metadata;

namespace DataAccess.Entities.UI
{
    public class Page : BaseObject
    {

        public int TemplateId { get; set; }


        public Guid PageObjectId { get; set; }


        public BusinessObject PageObject { get; set; }


        public Guid? QueryId { get; set; }


        public virtual BusinessObjectExpression Query { get; set; }


        public Guid? FilterId { get; set; }


        public virtual BusinessObjectExpression Filter { get; set; }

        //public virtual ICollection<Workflow> Actions { get; set; }
    }
}
