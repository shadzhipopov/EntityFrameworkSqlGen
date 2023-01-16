using DynamicCRUD.Data;
using DynamicCRUD.Metadata;
using Microsoft.EntityFrameworkCore;
using Model.Enums;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace DataAccess.DynamicContext
{
    public class DynamicDbContext : DbContext
    {
        public string Version { get; set; }
        public DynamicDbContext(DbContextOptions dbContextOptions, MetadataHolder holder) : base(dbContextOptions)
        {
            this.Metadata = holder;
            this.Version = holder.Version;

        }
        public MetadataHolder Metadata { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public void MigrateDb()
        {
            this.Database.Migrate();
        }

        public object GetData(RequestObject requestObject)
        {
            var metadataEntityName = requestObject.TableName;

            var metadata = this.Metadata.Entities.First(c => c.TableName == metadataEntityName);//Find and get your type from json 

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var metadataEntity in this.Metadata.Entities)
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
                        if (navigationProperty.RelationType == RelationType.OneToZeroOrOne)
                        {
                            if (navigationProperty.IsPrincipal == false)
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
                            .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
                        }
                    }

                }
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
