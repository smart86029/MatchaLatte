﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manager.Models.GroupBuying
{
    /// <summary>
    /// 商品。
    /// </summary>
    [Table("Product", Schema = "GroupBuying")]
    public class Product
    {
        /// <summary>
        /// 取得或設定主鍵。
        /// </summary>
        /// <value>主鍵。</value>
        public int ProductId { get; set; }

        /// <summary>
        /// 取得或設定名稱。
        /// </summary>
        /// <value>名稱。</value>
        [Required]
        [StringLength(32, ErrorMessage = "長度不可超過 32")]
        public string Name { get; set; }

        /// <summary>
        /// 取得或設定價格。
        /// </summary>
        /// <value>價格。</value>
        public decimal Price { get; set; }

        /// <summary>
        /// 取得或設定商品分類 ID。
        /// </summary>
        /// <value>商品分類 ID。</value>
        public int ProductCategoryId { get; set; }

        /// <summary>
        /// 取得或設定商品分類。
        /// </summary>
        /// <value>商品分類。</value>
        public ProductCategory ProductCategory { get; set; }
    }
}