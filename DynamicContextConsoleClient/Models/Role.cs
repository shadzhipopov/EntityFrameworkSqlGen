﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DynamicContextConsoleClient.Models
{
    public partial class Role
    {
        public Role()
        {
            Permissions = new HashSet<Permission>();
            Containers = new HashSet<Container>();
            Users = new HashSet<User>();
        }

        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public bool IsSystem { get; set; }
        public bool IsActive { get; set; }
        public int Type { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }

        public virtual ICollection<Container> Containers { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}