using DataAccess.DynamicContext;
using DynamicContextConsoleClient.Models;
using DynamicCRUD.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicContextConsoleClient
{
    internal class CompareModelMigrator
    {
        private readonly BookShopApiContext db;

        public MetadataHolder GetMetadata(string version)
        {
            var result = new MetadataHolder();
            result.Version = version;
            var entities = new List<DynamicCRUD.Metadata.MetadataEntity>()
                {
                    new DynamicCRUD.Metadata.MetadataEntity(){
                        TableName = "PAParent",
                        Name = "PAParent",
                        SchemaName="RegItem",
                        Properties = new List<DynamicCRUD.Metadata.MetadataEntityProperty>()
                        {
                            new DynamicCRUD.Metadata.MetadataEntityProperty()
                            {
                                Name="ParentId",
                                IsPrimaryKey=true,
                                ColumnName="ParentId",
                                DbType = Model.Enums.FdbaDataType.Integer,
                                Type = typeof(int).Name,
                            }
                        }
                    }
            };
            result.Entities = entities;
            EntityTypesBuilder typesBuilder = new EntityTypesBuilder(result, null);
            typesBuilder.CreateEntityTypes();

            return result;
        }

        public CompareModelMigrator(BookShopApiContext db)
        {
            this.db = db;
        }

        public void AddTableTest()
        {
            var options = new DbContextOptionsBuilder();
            options.UseNpgsql("server=localhost;user id=postgres;password=1234;database=FdbaDb");
            options.ReplaceService<IModelCacheKeyFactory, DynamicContextCacheKeyFactory>();

            var dynamicContext = new DynamicDbContext(options.Options, new MetadataHolder());

            var dynCon2 = new DynamicDbContext(options.Options, GetMetadata("2"));
            var model1 = dynamicContext.GetService<IDesignTimeModel>().Model.GetRelationalModel();
            var model2 = dynCon2.GetService<IDesignTimeModel>().Model.GetRelationalModel();

            var diff = db.GetInfrastructure().GetService<IMigrationsModelDiffer>().GetDifferences(
                 model1, model2
                );

            var sql = db.GetService<IMigrationsSqlGenerator>().Generate(diff);
        }

        public void RemovedTableTest()
        {
            var options = new DbContextOptionsBuilder();
            options.UseNpgsql("server=localhost;user id=postgres;password=1234;database=FdbaDb");
            options.ReplaceService<IModelCacheKeyFactory, DynamicContextCacheKeyFactory>();

            var dynamicContext = new DynamicDbContext(options.Options, GetMetadata("1"));

            var dynCon2 = new DynamicDbContext(options.Options, new DynamicCRUD.Metadata.MetadataHolder()
            {
                Version = "2",

            });

            var model1 = dynamicContext.GetService<IDesignTimeModel>().Model.GetRelationalModel();
            var model2 = dynCon2.GetService<IDesignTimeModel>().Model.GetRelationalModel();

            var diff = db.GetInfrastructure().GetService<IMigrationsModelDiffer>().GetDifferences(
                 model1, model2
                );

            var sql = db.GetService<IMigrationsSqlGenerator>().Generate(diff);
        }
    }
}
