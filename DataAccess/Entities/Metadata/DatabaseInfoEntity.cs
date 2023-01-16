using Common;
using DataAccess.EntityFramework.Entities;
using System.Collections.Generic;


namespace DataAccess.EntityFramework.Entities.Metadata
{

    public class DatabaseInfoEntity : BaseObject
    {

        public string MachineName { get; set; }


        public string MachineAddress { get; set; }


        public string DatabaseServerInstanceName { get; set; }


        public string DatabaseName { get; set; }


        public bool IntegratedSecurity { get; set; }


        public string LoginName { get; set; }


        public string LoginPassword { get; set; }


        public DatabaseServer ServerType { get; set; }


        public virtual ICollection<BusinessModuleEntity> BusinessModules { get; set; }
    }
}
