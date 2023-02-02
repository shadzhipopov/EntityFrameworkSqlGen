using DataAccess.DynamicContext;
using DynamicContextConsoleClient.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicContextConsoleClient
{
    internal class CompareModelMigrator
    {
        public CompareModelMigrator(BookShopApiContext db)
        {
            var options = new DbContextOptionsBuilder();
            options.UseNpgsql("server=localhost;user id=postgres;password=1234;database=FdbaDb");
            var dynamicContext = new DynamicDbContext(options.Options, new DynamicCRUD.Metadata.MetadataHolder() { Version = "1"});

            var dynCon2 = new DynamicDbContext(options.Options, new DynamicCRUD.Metadata.MetadataHolder() {
                Version = "2",
                Entities = new List<DynamicCRUD.Metadata.MetadataEntity>()
                {
                    new DynamicCRUD.Metadata.MetadataEntity(){
                        TableName = "PAParent",
                        SchemaName="RegItem",
                        Properties = new List<DynamicCRUD.Metadata.MetadataEntityProperty>()
                        {
                            new DynamicCRUD.Metadata.MetadataEntityProperty()
                            {
                                Name="ParentId",
                                IsPrimaryKey=true,
                                ColumnName="ParentId",
                                DbType = Model.Enums.FdbaDataType.Guid,
                            }
                        }
                    }
                }
            });

            var model1 = dynamicContext.GetService<IDesignTimeModel>().Model.GetRelationalModel();
            var model2 = dynCon2.GetService<IDesignTimeModel>().Model.GetRelationalModel();

            var diff =  db.GetInfrastructure().GetService<IMigrationsModelDiffer>().GetDifferences(
                 model1, model2
                );
        }
    }
}
