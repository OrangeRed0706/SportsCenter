﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SportsCenter.Models.Entity
{
    public partial class Category
    {
        public Category()
        {
            LocationBranch = new HashSet<LocationBranch>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int IsActive { get; set; }

        public virtual ICollection<LocationBranch> LocationBranch { get; set; }
    }
}