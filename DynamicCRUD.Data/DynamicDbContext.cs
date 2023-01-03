using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using DynamicCRUD.Metadata;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

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

                entityBuilder.ToTable(metadataEntity.TableName, metadataEntity.SchemaName)
                    .HasKey("Id");

                foreach (var metaDataEntityProp in metadataEntity.Properties)
                {
                    if (!metaDataEntityProp.IsNavigation)
                    {
                        var propBuilder = entityBuilder
                            .Property(metaDataEntityProp.Name);

                        if (!string.IsNullOrEmpty(metaDataEntityProp.ColumnName))
                        {
                            propBuilder.HasColumnName(metaDataEntityProp.ColumnName);
                        }
                    }
                    else
                    {
                        if(metaDataEntityProp.NavigationType == "Single")
                        {
                            entityBuilder.HasOne(metaDataEntityProp.Name)
                                .WithMany(metaDataEntityProp.OppositeNavigationName)
                                .HasForeignKey(metaDataEntityProp.ColumnName)
                                .OnDelete(DeleteBehavior.Restrict);
                        }
                    }
                }
            }
            base.OnModelCreating(modelBuilder);
        }

    }

}
