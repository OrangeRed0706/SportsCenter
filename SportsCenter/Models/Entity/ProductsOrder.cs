﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SportsCenter.Models.Entity
{
    public partial class ProductsOrder
    {
        public ProductsOrder()
        {
            ProductsOrderDetail = new HashSet<ProductsOrderDetail>();
        }

        public int Id { get; set; }
        public int MemberId { get; set; }
        public string MemberAddress { get; set; }
        public string MemberCellphone { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Member Member { get; set; }
        public virtual ICollection<ProductsOrderDetail> ProductsOrderDetail { get; set; }
    }
}