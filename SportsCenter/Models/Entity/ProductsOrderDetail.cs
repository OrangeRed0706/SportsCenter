﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SportsCenter.Models.Entity
{
    public partial class ProductsOrderDetail
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public int Count { get; set; }
        public int ProductsPrice { get; set; }
        public string ProductName { get; set; }
        public int ProductOrderId { get; set; }

        public virtual ProductsOrder ProductOrder { get; set; }
    }
}