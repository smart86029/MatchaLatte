﻿using System;
using MatchaLatte.Common.Attributes;

namespace MatchaLatte.Ordering.App.ViewModels.Stores
{
    public class ProductItemDetail
    {
        public Guid ProductItemId { get; set; }

        [Column("ItemName")]
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}