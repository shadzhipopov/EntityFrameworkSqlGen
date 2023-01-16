using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework.Entities.Metadata
{
    public interface IMigrationEntity
    {
        public bool IsDeployed { get; set; }
        public string SqlScript { get; set; }
    }
}
