using Model.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataAccess.EntityFramework.Entities.Security.Permissions
{
    public class WorkflowActionPermission : Permission
    {
        public WorkflowAction Action { get; set; }

        public Guid WorkflowId { get; set; }
        //public Workflow Workflow { get; set; }
    }
}
