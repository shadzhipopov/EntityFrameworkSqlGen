using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCRUD.Metadata
{
    internal class DynamicMigrationAssembly : MigrationsAssembly
    {
        public DynamicMigrationAssembly(ICurrentDbContext currentContext, 
            IDbContextOptions options, 
            IMigrationsIdGenerator idGenerator, 
            IDiagnosticsLogger<DbLoggerCategory.Migrations> logger) : base(currentContext, options, idGenerator, logger)
        {

        }
    }
}
