﻿using DataAccess.Entities;

namespace Model.UI
{
    public class Page : BaseObject
    {
        
        public int TemplateId { get; set; }

        
        public Guid PageObjectId { get; set; }

        
        public BusinessObject PageObject { get; set; }

        
        public Guid? QueryId { get; set; }

        
        public BusinessObjectExpression Query { get; set; }

        
        public Guid? FilterId { get; set; }

        
        public virtual BusinessObjectExpression Filter { get; set; }

        //public virtual ICollection<Workflow> Actions { get; set; }
    }
}
