﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Manager.App.Queries.GroupBuying;
using Manager.App.ViewModels;
using Manager.App.ViewModels.GroupBuying;

namespace Manager.Queries.GroupBuying
{
    /// <summary>
    /// 店家查詢服務。
    /// </summary>
    public class StoreQueryService : IStoreQueryService
    {
        private string connectionString;

        /// <summary>
        /// 初始化 <see cref="StoreQueryService"/> 類別的新執行個體。
        /// </summary>
        /// <param name="connectionString">連接字串。</param>
        public StoreQueryService(string connectionString)
        {
            this.connectionString = !string.IsNullOrWhiteSpace(connectionString) ? connectionString : throw new ArgumentNullException(nameof(connectionString));
            SqlMapper.SetTypeMap(typeof(Store.ProductCategory), new TypeMap<Store.ProductCategory>());
            SqlMapper.SetTypeMap(typeof(Store.Product), new TypeMap<Store.Product>());
            SqlMapper.SetTypeMap(typeof(Store.ProductItem), new TypeMap<Store.ProductItem>());
        }

        /// <summary>
        /// 取得所有店家。
        /// </summary>
        /// <param name="option">分頁查詢。</param>
        /// <returns>所有店家。</returns>
        public async Task<PaginationResult<StoreSummary>> GetStoresAsync(PaginationOption option)
        {
            var sql = $@"
                SELECT [StoreId], [Name], [CreatedOn]
                FROM [GroupBuying].[Store]
                ORDER BY [StoreId]
                OFFSET @Skip ROWS
                FETCH NEXT @Take ROWS ONLY";
            var sqlCount = $@"
                SELECT COUNT(*) FROM [GroupBuying].[Store]";
            var param = new
            {
                Skip = (option.PageIndex - 1) * option.PageSize,
                Take = option.PageSize
            };

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var stores = await connection.QueryAsync<StoreSummary>(sql, param);
                var count = await connection.QuerySingleAsync<int>(sqlCount);
                var result = new PaginationResult<StoreSummary>
                {
                    Items = stores.AsList(),
                    ItemCount = count
                };

                return result;
            }
        }

        /// <summary>
        /// 取得店家。
        /// </summary>
        /// <param name="storeId">店家 ID。</param>
        /// <returns>店家。</returns>
        public async Task<Store> GetStoreAsync(int storeId)
        {
            var sql = $@"
				SELECT [s].[StoreId], [s].[Name], [s].[Description], [s].[AreaCode], [s].[BaseNumber], [s].[Extension],
					[s].[PostalCode], [s].[Country], [s].[City], [s].[District], [s].[Street], [s].[Remark],
					[y].[ProductCategoryId], [y].[CategoryName],
					[y].[ProductId], [y].[ProductName], [y].[ProductDescription],
					[y].[ProductItemId], [y].[ItemName], [y].[Price]
				FROM (
                    SELECT [StoreId], [Name], [Description], [AreaCode], [BaseNumber], [Extension], [PostalCode], [Country], [City], [District], [Street], [Remark]
                    FROM [GroupBuying].[Store]
                    WHERE [StoreId] = @StoreId
                ) AS [s]
				LEFT JOIN (
                    SELECT [c].[ProductCategoryId], [c].[Name] AS [CategoryName], [c].[StoreId],
                        [x].[ProductId], [x].[ProductName], [x].[ProductDescription],
						[x].[ProductItemId], [x].[ItemName], [x].[Price]
                    FROM [GroupBuying].[ProductCategory] AS [c]
					LEFT JOIN (
						SELECT [p].[ProductId], [p].[Name] AS [ProductName], [p].[Description] AS [ProductDescription], [p].[ProductCategoryId],
							[i].[ProductItemId], [i].[Name] AS [ItemName], [i].[Price]
						FROM [GroupBuying].[Product] AS [p]
						LEFT JOIN [GroupBuying].[ProductItem] AS [i] ON [p].[ProductId] = [i].[ProductId]
					) AS [x] ON [c].[ProductCategoryId] = [x].[ProductCategoryId]
                    WHERE [StoreId] = @StoreId
                ) AS [y] ON [s].[StoreId] = [y].[StoreId]";
            var param = new { StoreId = storeId };

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var stores = new Dictionary<int, Store>();
                var categories = new Dictionary<int, Store.ProductCategory>();
                var products = new Dictionary<int, Store.Product>();
                var result = await connection.QueryAsync(sql, (Store s, Phone phone, Address a, Store.ProductCategory c, Store.Product p, Store.ProductItem i) =>
                {
                    if (!stores.TryGetValue(s.StoreId, out Store store))
                    {
                        stores.Add(s.StoreId, store = s);
                    }

                    if (string.IsNullOrWhiteSpace(store.Phone))
                        store.Phone = phone.AreaCode + phone.BaseNumber + phone.Extension;
                    if (string.IsNullOrWhiteSpace(store.Address))
                        store.Address = a.City + a.District + a.Street;

                    if (c == default(Store.ProductCategory))
                        return store;
                    if (!categories.TryGetValue(c.ProductCategoryId, out Store.ProductCategory category))
                    {
                        categories.Add(c.ProductCategoryId, category = c);
                        store.ProductCategories.Add(category);
                    }

                    if (p == default(Store.Product))
                        return store;
                    if (!products.TryGetValue(p.ProductId, out Store.Product product))
                    {
                        products.Add(p.ProductId, product = p);
                        category.Products.Add(product);
                    }

                    if (i == default(Store.ProductItem))
                        return store;
                    product.ProductItems.Add(i);

                    return store;
                }, param, splitOn: "AreaCode, PostalCode, ProductCategoryId, ProductId, ProductItemId");

                return result.FirstOrDefault();
            }
        }
    }
}