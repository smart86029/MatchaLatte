﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Manager.App.Queries.System;
using Manager.App.ViewModels;
using Manager.App.ViewModels.System;

namespace Manager.Queries.System
{
    /// <summary>
    /// 角色查詢服務。
    /// </summary>
    public class RoleQueryService : IRoleQueryService
    {
        private string connectionString;

        /// <summary>
        /// 初始化 <see cref="RoleQueryService"/> 類別的新執行個體。
        /// </summary>
        /// <param name="connectionString">連接字串。</param>
        public RoleQueryService(string connectionString)
        {
            this.connectionString = !string.IsNullOrWhiteSpace(connectionString) ? connectionString : throw new ArgumentNullException(nameof(connectionString));
        }

        /// <summary>
        /// 取得所有角色。
        /// </summary>
        /// <param name="option">分頁查詢。</param>
        /// <returns>所有角色。</returns>
        public async Task<PaginationResult<RoleSummary>> GetRolesAsync(PaginationOption option)
        {
            var sql = $@"
                SELECT RoleId, Name, IsEnabled
                FROM [System].[Role]
                ORDER BY RoleId
                OFFSET @Skip ROWS
                FETCH NEXT @Take ROWS ONLY";
            var sqlCount = $@"
                SELECT COUNT(*) FROM [System].[Role]";
            var param = new
            {
                Skip = (option.PageIndex - 1) * option.PageSize,
                Take = option.PageSize
            };

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var roles = await connection.QueryAsync<RoleSummary>(sql, param);
                var count = await connection.QuerySingleAsync<int>(sqlCount);
                var result = new PaginationResult<RoleSummary>
                {
                    Items = roles.AsList(),
                    ItemCount = count
                };

                return result;
            }
        }

        /// <summary>
        /// 取得角色。
        /// </summary>
        /// <param name="roleId">角色 ID。</param>
        /// <returns>角色。</returns>
        public async Task<Role> GetRoleAsync(int roleId)
        {
            var sql = $@"
                SELECT RoleId, Name, IsEnabled
                FROM [System].[Role]
                WHERE RoleId = @RoleId";
            var param = new { RoleId = roleId };

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var roles = new Dictionary<int, Role>();
                var result = await connection.QuerySingleAsync<Role>(sql, param);

                return result;
            }
        }

        ///// <summary>
        ///// 取得新角色。
        ///// </summary>
        ///// <returns>新角色。</returns>
        //public async Task<Role> GetNewRoleAsync()
        //{
        //    var sql = $@"
        //        SELECT RoleId, Name
        //        FROM [System].[Role]
        //        WHERE IsEnabled = 1";
        //    using (var connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        var roles = await connection.QueryAsync<Role.Role>(sql);
        //        var result = new Role
        //        {
        //            Roles = roles.ToList()
        //        };

        //        return result;
        //    }
        //}
    }
}