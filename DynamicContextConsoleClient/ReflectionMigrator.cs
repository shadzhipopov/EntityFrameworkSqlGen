using DataAccess.EntityFramework;
using DataAccess.EntityFramework.Entities.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicContextConsoleClient
{
    public class ReflectionMigrator : Migration
    {
        private readonly FdbaDbContext context;

        public ReflectionMigrator(FdbaDbContext context)
        {
            this.context = context;
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }
    }
}
