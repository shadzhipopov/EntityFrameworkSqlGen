using Model.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DataAccess.Entities.Security.Permissions.Business
{
    public class WorkflowActionPermission : Permission
    {
        public WorkflowAction Action { get; set; }

        public Guid WorkflowId { get; set; }
        //public Workflow Workflow { get; set; }
    }
}
