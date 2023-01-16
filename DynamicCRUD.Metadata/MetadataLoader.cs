using DataAccess.EntityFramework;
using DataAccess.EntityFramework.Entities.Metadata;
using Microsoft.EntityFrameworkCore;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCRUD.Metadata
{
    public class MetadataLoader
    {
        private readonly FdbaDbContext metadataContext;

        public MetadataLoader(FdbaDbContext metadataContext)
        {
            this.metadataContext = metadataContext;
        }

        public List<MetadataEntity> Load()
        {
            var metadata = metadataContext.Set<BusinessObjectEntity>()
                    .Where(c => c.BusinessModule.PhysicalName == "HumanResources")
                    .Select(businessObject => new MetadataEntity()
                    {
                        Id = businessObject.Id,
                        SchemaName = businessObject.BusinessModule.PhysicalName,
                        TableName = businessObject.PhysicalName,
                        Name = businessObject.DisplayName,

                        Properties = businessObject.Properties.Select(property => new MetadataEntityProperty
                        {
                            Name = property.DisplayName,
                            DbType = property.Type.DataType,
                            ColumnName = property.PhysicalName,
                            IsPrimaryKey
                             = property.IsPrimaryKey,
                        }).ToList()
                    }).ToList();

            var objectids = metadata.Select(c => c.Id).ToList();
            var relations = metadataContext.Set<BusinessObjectRelationEntity>()
                .Where(c => objectids.Contains(c.FromObjectId) && objectids.Contains(c.ToObjectId))
                .Include(c => c.ForeignKeys)
                .ThenInclude(c => c.ForeignKeyProperty)
                .ToList();

            foreach (var relation in relations)
            {
                var relationType = GetRelationType(relation);

                var fromEntity = metadata.First(c => c.Id == relation.FromObjectId);
                var toEntity = metadata.First(c => c.Id == relation.ToObjectId);

                switch (relationType)
                {
                    case RelationType.ManyToMany:
                        continue;
                    case RelationType.OneToZeroOrOne:
                        var fromEntityNavigation = new MetadataNavigationProperty();
                        fromEntityNavigation.RelationId = relation.Id;
                        fromEntityNavigation.RelationType = GetRelationType(relation);
                        fromEntityNavigation.Type = relation.ToEnd;
                        fromEntityNavigation.Name = toEntity.Name;
                        fromEntityNavigation.RelationName = relation.RelationName;
                        fromEntityNavigation.OppositeNavigationName = fromEntity.Name;
                        fromEntityNavigation.OppositeObjectName = toEntity.Name;
                        fromEntityNavigation.ForeignKeyPropertyName = GetForeignKeyPropertyName(relation);
                        fromEntity.NavigationProperties.Add(fromEntityNavigation);

                        var toEntityNavigation = new MetadataNavigationProperty();
                        toEntityNavigation.RelationId = relation.Id;
                        toEntityNavigation.RelationType = GetRelationType(relation);
                        toEntityNavigation.Type = relation.FromEnd;
                        toEntityNavigation.Name = fromEntity.Name;
                        toEntityNavigation.RelationName = relation.RelationName;
                        toEntityNavigation.OppositeNavigationName = toEntity.Name;
                        toEntityNavigation.OppositeObjectName = fromEntity.Name;
                        toEntityNavigation.ForeignKeyPropertyName = GetForeignKeyPropertyName(relation);
                        toEntity.NavigationProperties.Add(toEntityNavigation);

                        if (IsFromPrincipalCondition(relation))
                        {
                            fromEntityNavigation.IsPrincipal = true;
                        }
                        else
                        {
                            toEntityNavigation.IsPrincipal = false;
                        }

                        continue;
                    case RelationType.OneToMany:
                        CreateOneToManyNavigationProperties(relation, fromEntity, toEntity);
                        break;
                }
            }

            foreach (var item in metadata.SelectMany(c => c.Properties))
            {
                item.Type = item.DbType.MapToClrType().Name;
            }

            return metadata;
        }

        private void CreateOneToManyNavigationProperties(BusinessObjectRelationEntity relation, MetadataEntity fromEntity, MetadataEntity toEntity)
        {

            var fromEntityNavigation = new MetadataNavigationProperty();
            fromEntityNavigation.RelationType = GetRelationType(relation);
            fromEntityNavigation.RelationId = relation.Id;
            fromEntityNavigation.Type = relation.ToEnd;
            fromEntityNavigation.Name = toEntity.Name;
            fromEntityNavigation.RelationName = relation.RelationName;
            fromEntityNavigation.OppositeNavigationName = fromEntity.Name;
            fromEntityNavigation.OppositeObjectName = toEntity.Name;
            fromEntityNavigation.ForeignKeyPropertyName = GetForeignKeyPropertyName(relation);
            fromEntity.NavigationProperties.Add(fromEntityNavigation);

            var toEntityNavigation = new MetadataNavigationProperty();
            toEntityNavigation.RelationType = GetRelationType(relation);
            toEntityNavigation.RelationId = relation.Id;
            toEntityNavigation.Type = relation.FromEnd;
            toEntityNavigation.Name = fromEntity.Name;
            toEntityNavigation.RelationName = relation.RelationName;
            toEntityNavigation.OppositeNavigationName = toEntity.Name;
            toEntityNavigation.OppositeObjectName = fromEntity.Name;
            toEntityNavigation.ForeignKeyPropertyName = GetForeignKeyPropertyName(relation);
            toEntity.NavigationProperties.Add(toEntityNavigation);

            if (relation.FromEnd == RelationEnd.One ||
                relation.FromEnd == RelationEnd.ZeroOrOne)
            {

                toEntityNavigation.Name = PluralizeName(fromEntity.Name);
            }
            else
            {

                fromEntityNavigation.Name = PluralizeName(toEntity.Name);
            }
        }

        private bool IsFromPrincipalCondition(BusinessObjectRelationEntity relation)
        {
            if (relation.FromEnd == RelationEnd.Many && relation.ToEnd == RelationEnd.Many)
            {
                throw new Exception("Many to many relations do not have principal!");
            }
            var condition = (relation.FromEnd == RelationEnd.One) ||
                     (relation.FromEnd == RelationEnd.ZeroOrOne && relation.ToEnd == RelationEnd.Many);
            return condition;
        }



        private string PluralizeName(string name)
        {
            return PluralizeService.Core.PluralizationProvider.Pluralize(name);
        }

        private RelationType GetRelationType(BusinessObjectRelationEntity relation)
        {
            if (relation.FromEnd == RelationEnd.One || relation.FromEnd == RelationEnd.ZeroOrOne)
            {
                if (relation.ToEnd == RelationEnd.One || relation.ToEnd == RelationEnd.ZeroOrOne)
                {
                    return RelationType.OneToZeroOrOne;
                }
                else
                {
                    return RelationType.OneToMany;
                }
            }
            else
            {
                if (relation.ToEnd == RelationEnd.Many)
                {
                    return RelationType.ManyToMany;
                }
                else
                {
                    return RelationType.OneToMany;
                }
            }
        }

        private string GetForeignKeyPropertyName(BusinessObjectRelationEntity relation)
        {
            return relation.ForeignKeys.SingleOrDefault().ForeignKeyProperty.PhysicalName;
        }
    }
}
