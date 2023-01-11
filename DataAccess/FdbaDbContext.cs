﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Model.Helpers;
using DataAccess.Entities.Expressions.OperatorNodes;
using DataAccess.Entities.Expressions;
using DataAccess.Entities.Security;
using DataAccess.Configurations.Expressions.LeafNodes;
using DataAccess.Configurations.Metadata;
using DataAccess.Configurations.Expressions.OperatorNodes;
using DataAccess.Configurations.Security;
using DataAccess.Configurations.Security.Permissions;
using DataAccess.Configurations.Expressions;
using DataAccess.Entities.Metadata;
using DataAccess.Configurators.UI;
using DataAccess.Entities.Security.Permissions;
#nullable disable

namespace DataAccess.Entities
{
    public partial class FdbaDbContext : DbContext
    {
        public FdbaDbContext()
        {
        }

        public FdbaDbContext(DbContextOptions<FdbaDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<ExpressionNode> ExpressionNodes { get; set; }
        public DbSet<AggregateFunctionNode> AggregateFunctionNodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Metadata configurators
            modelBuilder.ApplyConfiguration(new DatabaseInfoConfigurator());
            modelBuilder.ApplyConfiguration(new BusinessModuleConfigurator());
            modelBuilder.ApplyConfiguration(new BusinessObjectConfigurator());
            modelBuilder.ApplyConfiguration(new BusinessObjectGroupConfigurator());
            modelBuilder.ApplyConfiguration(new BusinessPropertyConfigurator());
            modelBuilder.ApplyConfiguration(new BusinessPropertyTypeConfigurator());
            modelBuilder.ApplyConfiguration(new BusinessObjectRelationConfigurator());
            modelBuilder.ApplyConfiguration(new ForeignKeyConfigurator());
            modelBuilder.ApplyConfiguration(new ImportInfoConfigurator());
            modelBuilder.ApplyConfiguration(new MetadataItemPathRelationConfigurator());
            modelBuilder.ApplyConfiguration(new EnumerationValueConfigurator());
            modelBuilder.ApplyConfiguration(new EnumerationTypeConfigurator());
            modelBuilder.ApplyConfiguration(new DatabaseDataTypeConfigurator());
            modelBuilder.ApplyConfiguration(new BusinessObjectExpressionConfigurator());

            modelBuilder.Entity<BusinessProperty>()
                .HasMany(m => m.MappingProperties)
                .WithMany(c => c.MappedProperties)
                .UsingEntity(c =>
                {
                    c.ToTable(("MappingProperties"),
                        MetadataNamesHelper.FdbaPrefix);
                });
            #endregion

            #region Expressions
            modelBuilder.ApplyConfiguration(new ExpressionNodeConfigurator<ExpressionNode>());
            modelBuilder.ApplyConfiguration(new BusinessObjectLeafNodeConfigurator());
            modelBuilder.ApplyConfiguration(new BusinessPropertyLeafNodeConfigurator());
            modelBuilder.ApplyConfiguration(new ConstantLeafNodeConfigurator());          
            modelBuilder.ApplyConfiguration(new ClrEnumerationLeafNodeConfigurator());
            modelBuilder.ApplyConfiguration(new EnumerationLeafNodeConfigurator());
            modelBuilder.ApplyConfiguration(new LogicalOperatorNodeConfigurator());
            modelBuilder.ApplyConfiguration(new ComparisonOperatorNodeConfigurator());
            modelBuilder.ApplyConfiguration(new SelectOperatorNodeConfigurator());
            modelBuilder.ApplyConfiguration(new WhereOperatorNodeConfigurator());
            modelBuilder.ApplyConfiguration(new TrinaryOperatorNodeConfigurator());
            modelBuilder.ApplyConfiguration(new QueryExpressionConfigurator());

            modelBuilder.ApplyConfiguration(new OrderByNodeConfigurator());
            modelBuilder.ApplyConfiguration(new OrderByNodeItemConfigurator());
            modelBuilder.ApplyConfiguration(new ExistsNodeConfigurator());
            modelBuilder.ApplyConfiguration(new InOperatorNodeConfigurator());
            modelBuilder.ApplyConfiguration(new AllAnyOperatorNodeConfigurator());
            #endregion


            #region Security
            modelBuilder.ApplyConfiguration(new RoleConfigurator());
            modelBuilder.ApplyConfiguration(new UserConfigurator());
            modelBuilder.ApplyConfiguration(new ContainerConfigurator());
            modelBuilder.ApplyConfiguration(new UsersGroupConfigurator());

            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Groups)
                .WithMany(r => r.Users);

            modelBuilder.Entity<Container>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Containers);

            modelBuilder.ApplyConfiguration(new PermissionConfigurator());

            modelBuilder.Entity<GrantModuleAccessPermission>(builder =>
            {
                builder.Property(c => c.GrantedAccess).HasColumnName("GrantedAccess");

                builder.HasOne(c => c.Module)
                .WithMany()
                .HasForeignKey(c => c.ModuleId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<DenyBusinessModuleAccessPermission>(builder =>
            {
                builder.Property(c => c.DeniedAccess).HasColumnName("DeniedAccess");
                builder.HasOne(c => c.Module)
                .WithMany()
                .HasForeignKey(c => c.ModuleId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<GrantObjectAccessPermission>(builder =>
            {
                builder.Property(c => c.GrantedAccess).HasColumnName("GrantedAccess");
                builder.HasOne(c => c.Object)
                .WithMany()
                .HasForeignKey(c => c.ObjectId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<DenyObjectAccessPermission>(builder =>
            {
                builder.Property(c => c.DeniedAccess).HasColumnName("DeniedAccess");

                builder.HasOne(c => c.Object)
                .WithMany()
                .HasForeignKey(c => c.ObjectId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<DataFilterPermission>(builder =>
            {
                builder.HasOne(c => c.FilterExpression)
                .WithMany()
                .HasForeignKey(c => c.FilterExpressionId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<DenyPropertyPermission>(builder =>
            {
                builder.Property(c => c.DenyPropertyAccess).HasColumnName("DeniedAccess");
                builder.HasOne(c => c.Property)
                .WithMany()
                .HasForeignKey(c => c.PropertyId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<DenyPageAccessPermission>(builder =>
            {
                builder.HasOne(c => c.Page)
                .WithMany()
                .HasForeignKey(c => c.PageId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
            });
            #endregion

            #region UI
            modelBuilder.ApplyConfiguration(new PageConfigurator());
            #endregion

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
