using DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCRUD.Metadata.DynamicMigrations
{
    public class ReflectionMigration : Migration
    {
        private readonly FdbaDbContext dbContext;

        public ReflectionMigration(FdbaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var migrationBuilderType = migrationBuilder.GetType();
            var createTableMethod = migrationBuilderType.GetMethod(nameof(migrationBuilder.CreateTable));
            migrationBuilder.EnsureSchema("customschema");
        }
        
    }
}
