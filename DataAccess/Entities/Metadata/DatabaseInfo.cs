using Common;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataAccess.Entities.Metadata
{
    [DataContract(IsReference = true)]
    public class DatabaseInfo : BaseObject
    {

        public string MachineName { get; set; }


        public string MachineAddress { get; set; }


        public string DatabaseServerInstanceName { get; set; }


        public string DatabaseName { get; set; }


        public bool IntegratedSecurity { get; set; }


        public string LoginName { get; set; }


        public string LoginPassword { get; set; }


        public DatabaseServer ServerType { get; set; }


        public virtual ICollection<BusinessModule> BusinessModules { get; set; }
    }
}
