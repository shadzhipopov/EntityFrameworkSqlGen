using DataAccess.EntityFramework;
using DataAccess.EntityFramework.Entities.Metadata;
using DynamicCRUD.Emit;
using DynamicCRUD.Metadata;
using Microsoft.EntityFrameworkCore;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace DataAccess.DynamicContext
{
    public class EntityTypesBuilder
    {
        private readonly MetadataHolder metadataHolder;
        private readonly MetadataLoader loader;

        public EntityTypesBuilder(MetadataHolder metadataHolder, MetadataLoader loader)
        {
            this.metadataHolder = metadataHolder;
            this.loader = loader;
        }

        public void CreateEntityTypes(string version = null)
        {
            bool shouldCreateTyes = false;
            if (metadataHolder.Entities == null || metadataHolder.Entities.Count == 0)
            {
                var entities = loader.Load();
                metadataHolder.Entities = entities;
                shouldCreateTyes = true;
                metadataHolder.Version = version??"1.0";
            }

            if (shouldCreateTyes)
            {
                Dictionary<string, TypeBuilder> entityTypeBuilderList = new Dictionary<string, TypeBuilder>();

                var dynamicClassFactory = new DynamicClassFactory();
                foreach (var metadataEntity in metadataHolder.Entities)
                {
                    var metadataProps = new Dictionary<string, Type>();
                    foreach (var metaDataEntityProp in metadataEntity.Properties)
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

                            case "Int16":
                                metadataProps.Add(metaDataEntityProp.Name, typeof(Int16));
                                break;
                            case "Int":
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
                        }
                    }
                    if (string.IsNullOrEmpty(metadataEntity.CustomAssemblyType))
                    {
                        var entityTypeBuilder = dynamicClassFactory.CreateDynamicTypeBuilder<DynamicEntity>(metadataEntity.Name, metadataProps);

                        entityTypeBuilderList.Add(metadataEntity.Name, entityTypeBuilder);
                    }
                    else
                    {
                        metadataEntity.EntityType = Type.GetType(metadataEntity.CustomAssemblyType);
                    }
                }

                foreach (var metadataEntity in metadataHolder.Entities)
                {
                    var existEntityTypeBuilder = entityTypeBuilderList.FirstOrDefault(p => p.Key == metadataEntity.Name).Value;

                    foreach (var navigationProperty in metadataEntity.NavigationProperties)
                    {
                        var relatedEntityTypeBuilder = entityTypeBuilderList.FirstOrDefault(p => p.Key == navigationProperty.OppositeObjectName).Value;

                        var relatedProp = new Dictionary<string, Type>();

                        if (navigationProperty.Type == RelationEnd.One ||
                            navigationProperty.Type == RelationEnd.ZeroOrOne)
                        {
                            relatedProp.Add(navigationProperty.Name, relatedEntityTypeBuilder);
                        }
                        else
                        {
                            Type listGenericType = typeof(ICollection<>);
                            Type listRelateEntityType = listGenericType.MakeGenericType(relatedEntityTypeBuilder);
                            relatedProp.Add(navigationProperty.Name, listRelateEntityType);
                        }
                        new DynamicClassFactory().CreatePropertiesForTypeBuilder(existEntityTypeBuilder, relatedProp, null);
                    }
                    metadataEntity.EntityType = existEntityTypeBuilder.CreateType();
                }
            }
        }

        
    }
}
