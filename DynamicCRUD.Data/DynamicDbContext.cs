using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using DynamicCRUD.Metadata;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core.Parser;
using Model.Enums;

namespace DynamicCRUD.Data
{
    public class DynamicDbContext : DbContext
    {


        string _version;
        public DynamicDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
        public List<MetadataEntity> _metaDataEntityList = new List<MetadataEntity>();

        public void AddMetadata(MetadataEntity metadataEntity) => _metaDataEntityList.Add(metadataEntity);

        public MetadataEntity GetMetadaEntity(Type type) => _metaDataEntityList.FirstOrDefault(p => p.EntityType == type);


        public void SetContextVersion(string version) => _version = version;

        public string GetContextVersion() => _version;

        public void TestJoin()
        {
            var personEntity = this._metaDataEntityList.First(c => c.TableName == "Person");
            var employeye = this._metaDataEntityList.First(c => c.TableName == "Employee");
            var employeePayHistory = this._metaDataEntityList.First(c => c.TableName == "EmployeePayHistory");

            var personDbSet = (IQueryable<DynamicEntity>)this.GetType()
                .GetMethod("Set", 1, Type.EmptyTypes)
                .MakeGenericMethod(personEntity.EntityType).Invoke(this, null);

            var employeyeDbSet = (IQueryable<DynamicEntity>)this.GetType()
                .GetMethod("Set", 1, Type.EmptyTypes)
                .MakeGenericMethod(employeye.EntityType).Invoke(this, null);

            var employeyePayHistpryDbSet = (IQueryable<DynamicEntity>)this.GetType()
                .GetMethod("Set", 1, Type.EmptyTypes)
                .MakeGenericMethod(employeePayHistory.EntityType).Invoke(this, null);

            var join = personDbSet.Join(employeyeDbSet, "fdba_PersonId", "fdba_EmployeeId", "inner");
            var empHistory = join.Join(employeyePayHistpryDbSet, "fdba_EmployeeId", "BusinessEntityID", "inner")
                .Select("Rate");

            var expression = empHistory.Expression;
            var type = empHistory.ElementType;
            var sql = empHistory.ToQueryString();
        }
        public void TestSelectManyParse()
        {
            var personEntity = this._metaDataEntityList.First(c => c.TableName == "Person");

            var personDbSet = (IQueryable<DynamicEntity>)this.GetType()
               .GetMethod("Set", 1, Type.EmptyTypes)
               .MakeGenericMethod(personEntity.EntityType).Invoke(this, null);

            var personParam = Expression.Parameter(personEntity.EntityType, "p");
            var parameters = new[] { personParam };
            var expressionToParse = string.Format("{0}.Employee.EmployeePayHistory",
                                personParam.Name);

            Expression body = new ExpressionParser(parameters, expressionToParse, null, null).Parse(null, false);
        }


        public object GetData(RequestObject requestObject)
        {
            var metadataEntityName = requestObject.TableName;

            var metadata = this._metaDataEntityList.First(c => c.TableName == metadataEntityName);//Find and get your type from json 

            object response = null;
            var metadataQuerySet = (IQueryable<DynamicEntity>)this.GetType()
                .GetMethod("Set", 1, Type.EmptyTypes)
                .MakeGenericMethod(metadata.EntityType).Invoke(this, null);
            // var filters = requestObject["Filters"].ToList();

            string selects = "*";

            if (requestObject.SelectProperties != null)
            {
                selects = string.Join(',', requestObject.SelectProperties.ToList());
            }

            //var i = 0;
            //foreach (var filter in filters)
            //{
            //    var filterValue = requestObject["FilterValues"].ElementAt(i).ToString();
            //    i++;
            //    metadataQuerySet = metadataQuerySet.Where(filter.ToString(), filterValue);
            //}

            if (requestObject.SelectType == SelectType.List)
            {
                if (selects == "*")
                    response = metadataQuerySet.ToDynamicList();
                else
                {
                    var queryable = metadataQuerySet.Select($"new ({selects})");
                    var expression = queryable.Expression;
                    var type = queryable.ElementType;
                    var sql = metadataQuerySet.Select($"new ({selects})").ToQueryString();
                    response = metadataQuerySet.Select($"new ({selects})").ToDynamicList();
                }
            }

            if (requestObject.SelectType == SelectType.Single)
                if (selects == "*")
                {
                    response = metadataQuerySet.FirstOrDefaultAsync();
                }
                else
                {
                    response = metadataQuerySet.Select($"new ({selects})").FirstOrDefault();
                }


            return response;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var metadataEntity in _metaDataEntityList)
            {
                var entityBuilder = modelBuilder.Entity(metadataEntity.EntityType);

                var primaryKey = metadataEntity.Properties.Single(c => c.IsPrimaryKey);
                entityBuilder.ToTable(metadataEntity.TableName, metadataEntity.SchemaName)
                    .HasKey(primaryKey.ColumnName);

                foreach (var metaDataEntityProp in metadataEntity.Properties)
                {
                    var propBuilder = entityBuilder
                        .Property(metaDataEntityProp.Name);

                    if (!string.IsNullOrEmpty(metaDataEntityProp.ColumnName))
                    {
                        propBuilder.HasColumnName(metaDataEntityProp.ColumnName);
                    }
                }
                foreach (var navigationProperty in metadataEntity.NavigationProperties)
                {
                    if (navigationProperty.Type == RelationEnd.One ||
                        navigationProperty.Type == RelationEnd.ZeroOrOne)
                    {
                        if(navigationProperty.RelationType == RelationType.OneToZeroOrOne)
                        {
                            if(navigationProperty.IsPrincipal == false)
                            {
                                entityBuilder.HasOne(navigationProperty.Name)
                          .WithOne(navigationProperty.OppositeNavigationName)
                          .HasForeignKey(metadataEntity.Name, navigationProperty.ForeignKeyPropertyName);
                            }
                          
                        }
                        else
                        {
                            entityBuilder.HasOne(navigationProperty.Name)
                            .WithMany(navigationProperty.OppositeNavigationName)
                            .HasForeignKey(navigationProperty.ForeignKeyPropertyName)
                            .OnDelete(DeleteBehavior.Restrict);
                        }
                    }                    

                }
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
