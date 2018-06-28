﻿using System.Collections.Generic;
using System.Linq;
using Manager.Common;

namespace Manager.Domain.Models.System
{
    /// <summary>
    /// 使用者。
    /// </summary>
    public class User : IAggregateRoot
    {
        private readonly List<UserRole> userRoles = new List<UserRole>();

        /// <summary>
        /// 初始化 <see cref="User"/> 類別的新執行個體。
        /// </summary>
        private User()
        {
        }

        /// <summary>
        /// 初始化 <see cref="User"/> 類別的新執行個體。
        /// </summary>
        /// <param name="userName">使用者名稱。</param>
        /// <param name="password">密碼。</param>
        /// <param name="isEnabled">是否啟用。</param>
        /// <param name="businessEntityId">商業實體 ID。</param>
        public User(string userName, string password, bool isEnabled, int businessEntityId)
            : this(0, userName, password, isEnabled, businessEntityId)
        {
        }

        /// <summary>
        /// 初始化 <see cref="User"/> 類別的新執行個體。
        /// </summary>
        /// <param name="userId">使用者 ID。</param>
        /// <param name="userName">使用者名稱。</param>
        /// <param name="password">密碼。</param>
        /// <param name="isEnabled">是否啟用。</param>
        /// <param name="businessEntityId">商業實體 ID。</param>
        public User(int userId, string userName, string password, bool isEnabled, int businessEntityId)
        {
            UserId = userId;
            UserName = userName;
            PasswordHash = CryptographyUtility.Hash(password);
            IsEnabled = isEnabled;
            BusinessEntityId = businessEntityId;
        }

        /// <summary>
        /// 取得主鍵。
        /// </summary>
        /// <value>主鍵。</value>
        public int UserId { get; private set; }

        /// <summary>
        /// 取得使用者名稱。
        /// </summary>
        /// <value>使用者名稱。</value>
        public string UserName { get; private set; }

        /// <summary>
        /// 取得密碼雜湊。
        /// </summary>
        /// <value>密碼雜湊。</value>
        public string PasswordHash { get; private set; }

        /// <summary>
        /// 取得值，這個值指出是否啟用。
        /// </summary>
        /// <value>如果啟用則為 <c>true</c>，否則為 <c>false</c>。</value>
        public bool IsEnabled { get; private set; }

        /// <summary>
        /// 取得商業實體 ID。
        /// </summary>
        /// <value>商業實體 ID。</value>
        public int BusinessEntityId { get; private set; }

        ///// <summary>
        ///// 取得商業實體。
        ///// </summary>
        ///// <value>商業實體。</value>
        //public BusinessEntity BusinessEntity { get; set; }

        /// <summary>
        /// 取得使用者角色的集合。
        /// </summary>
        /// <value>使用者角色的集合。</value>
        public IReadOnlyCollection<UserRole> UserRoles => userRoles;

        /// <summary>
        /// 更新使用者名稱。
        /// </summary>
        /// <param name="userName">使用者名稱。</param>
        public void UpdateUserName(string userName)
        {
            UserName = userName;
        }

        /// <summary>
        /// 加入使用者角色。
        /// </summary>
        /// <param name="roleId">角色 ID。</param>
        public void AddUserRole(int roleId)
        {
            if (!userRoles.Any(x => x.RoleId == roleId))
                userRoles.Add(new UserRole { UserId = UserId, RoleId = roleId });
        }
    }
}