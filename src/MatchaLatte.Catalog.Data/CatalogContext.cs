﻿using System;
using System.Linq;
using MatchaLatte.Catalog.Data.Configurations;
using MatchaLatte.Common.EntityFramework.Configurations;
using MatchaLatte.Common.EntityFramework.Converters;
using Microsoft.EntityFrameworkCore;

namespace MatchaLatte.Catalog.Data
{
    public class CatalogContext : DbContext
    {
        /// <summary>
        /// 初始化 <see cref="CatalogContext"/> 類別的新執行個體。
        /// </summary>
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {
        }

        /// <summary>
        /// 此方法的呼叫時機是在初始化衍生內容的模型時，但在鎖定此模型及使用此模型初始化內容之前。
        /// </summary>
        /// <param name="modelBuilder">針對建立的內容定義模型的產生器。</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Catalog");
            modelBuilder.ApplyConfiguration(new EventLogConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new StoreConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductItemConfiguration());

            var utcDateTimeConverter = new UtcDateTimeConverter();
            var dateTimeProperties = modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(x => x.GetProperties())
                .Where(x => x.ClrType == typeof(DateTime));

            foreach (var property in dateTimeProperties)
                property.SetValueConverter(utcDateTimeConverter);
        }
    }
}