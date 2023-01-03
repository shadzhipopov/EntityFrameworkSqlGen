using DynamicCRUD.Data;
using DynamicCRUD.Emit;
using DynamicCRUD.Metadata;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using WebApplication1.Entities;

namespace DynamicCRUD.Api
{
    public class MetadataMiddleware<TContext> where TContext : DynamicDbContext
    {
        private readonly RequestDelegate _next;

        public MetadataMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public Type MapToClrType(FdbaDataType businessPropertyType)
        {
            switch (businessPropertyType)
            {
                case FdbaDataType.ShortInteger:
                    return typeof(Int16);
                case FdbaDataType.Integer:
                    return typeof(int);
                case FdbaDataType.LongInteger:
                    return typeof(Int64);
                case FdbaDataType.Double:
                    return typeof(double);
                case FdbaDataType.Decimal:
                    return typeof(decimal);
                case FdbaDataType.String:
                case FdbaDataType.EmailAddress:
                case FdbaDataType.PhoneNumber:                    
                    return typeof(string);

                //time is converted to timespan and there is problem with this in the datatable 
                //an exception is thrown when trying to put timespan to date time column
                //case BusinessPropertyDataType.Time:                    
                case FdbaDataType.Date:
                case FdbaDataType.DateTime:
                case FdbaDataType.DateTimeOffset:
                    return typeof(DateTime);
                case FdbaDataType.Guid:
                    return typeof(Guid);
                case FdbaDataType.Boolean:
                    return typeof(bool);
                case FdbaDataType.Binary:
                    return typeof(byte[]);
                default:
                    return typeof(string);
            }
        }
        public async Task Invoke(
            HttpContext context,
            MetadataHolder metadataHolder,
            TContext dbContext)
        {
            bool shouldCreateTyes = false;
            if(metadataHolder.Entities==null || metadataHolder.Entities.Count==0)
            {
                var metadataContext = context.RequestServices.GetService<FdbaDbContext>();
                var metadata = metadataContext.BusinessObject.Select(businessObject => new MetadataEntity()
                {
                    SchemaName = businessObject.BusinessModule.PhysicalName,
                    TableName = businessObject.PhysicalName,
                    Name = businessObject.DisplayName,
                    Properties = businessObject.BusinessProperty.Select(property => new MetadataEntityProperty
                    {
                        Name = property.DisplayName,
                        DbType = property.BusinessPropertyType.DataType,
                        ColumnName = property.PhysicalName
                    }).ToList()
                }).ToList();

                foreach (var item in metadata.SelectMany(c=>c.Properties))
                {
                    item.Type = this.MapToClrType((FdbaDataType)item.DbType).Name;
                }

                metadataHolder.Entities = metadata;
                shouldCreateTyes = true;
            }

            if (shouldCreateTyes)
            {
                Dictionary<string, TypeBuilder> entityTypeBuilderList = new Dictionary<string, TypeBuilder>();


                var dynamicClassFactory = new DynamicClassFactory();
                foreach (var metadataEntity in metadataHolder.Entities)
                {
                    var metadataProps = new Dictionary<string, Type>();
                    foreach (var metaDataEntityProp in metadataEntity.Properties.Where(p => !p.IsNavigation))
                    {
                        switch (metaDataEntityProp.Type)
                        {
                            case "String":
                                metadataProps.Add(metaDataEntityProp.Name, typeof(string));
                                break;
                            case "Byte[]":
                                metadataProps.Add(metaDataEntityProp.Name, typeof(byte[]));
                                break;
                            case "Decimal":
                                metadataProps.Add(metaDataEntityProp.Name, typeof(decimal));
                                break;
                            case "Double":
                                metadataProps.Add(metaDataEntityProp.Name, typeof(double));
                                break;
                            case "Float":
                                metadataProps.Add(metaDataEntityProp.Name, typeof(float));
                                break;
                            case "Boolean":
                                metadataProps.Add(metaDataEntityProp.Name, typeof(bool));
                                break;
                            case "Int":
                            case "Int16":
                            case "Int32":
                                metadataProps.Add(metaDataEntityProp.Name, typeof(int));
                                break;
                            case "Guid":
                                metadataProps.Add(metaDataEntityProp.Name, typeof(Guid));
                                break;
                            case "DateTime":
                                metadataProps.Add(metaDataEntityProp.Name, typeof(DateTime));
                                break;
                            default:
                                throw new NotImplementedException();
                                break;
                        }
                    }
                    if (string.IsNullOrEmpty(metadataEntity.CustomAssemblyType))
                    {
                        var entityTypeBuilder = dynamicClassFactory.CreateDynamicTypeBuilder<DynamicEntity>(metadataEntity.Name, metadataProps);

                        entityTypeBuilderList.Add(metadataEntity.Name, entityTypeBuilder);
                    }

                    else
                        metadataEntity.EntityType = Type.GetType(metadataEntity.CustomAssemblyType);


                }

                metadataHolder.Version = metadataHolder.Version;

                foreach (var metadataEntity in metadataHolder.Entities)
                {
                    var existEntityTypeBuilder = entityTypeBuilderList.FirstOrDefault(p => p.Key == metadataEntity.Name).Value;

                    foreach (var metaDataEntityProp in metadataEntity.Properties.Where(p => p.IsNavigation))
                    {
                        var relatedEntityTypeBuilder = entityTypeBuilderList.FirstOrDefault(p => p.Key == metaDataEntityProp.NavigationTypeType).Value;

                        var relatedProp = new Dictionary<string, Type>();

                        if (metaDataEntityProp.NavigationType == "Single")
                        {
                            relatedProp.Add(metaDataEntityProp.Name, relatedEntityTypeBuilder);
                        }
                        else
                        {
                            Type listGenericType = typeof(List<>);

                            Type listRelateEntityType = listGenericType.MakeGenericType(relatedEntityTypeBuilder);

                            relatedProp.Add(metaDataEntityProp.Name, listRelateEntityType);
                        }
                        new DynamicClassFactory().CreatePropertiesForTypeBuilder(existEntityTypeBuilder, relatedProp, null);
                    }
                    metadataEntity.EntityType = existEntityTypeBuilder.CreateType();
                }
            }

            foreach (var metaDataEntity in metadataHolder.Entities)
                dbContext.AddMetadata(metaDataEntity);

            dbContext.SetContextVersion(metadataHolder.Version);

            await _next.Invoke(context);
        }
    }

    public static class DynamicContextMiddlewareExtensions
    {
        public static IApplicationBuilder UseDynamicContext<TContext>(this WebApplication builder) where TContext : DynamicDbContext
        {
            return builder.UseMiddleware<MetadataMiddleware<TContext>>();
        }
    }
}
