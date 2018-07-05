﻿using System;
using System.Collections.Generic;
using Manager.Domain.Models.Generic;

namespace Manager.Domain.Models.GroupBuying
{
    /// <summary>
    /// 店家。
    /// </summary>
    public class Store : IAggregateRoot
    {
        private List<ProductCategory> productCategories = new List<ProductCategory>();
        //private List<GroupStore> groupStores = new List<GroupStore>();

        /// <summary>
        /// 初始化 <see cref="Store"/> 類別的新執行個體。
        /// </summary>
        private Store()
        {
        }

        /// <summary>
        /// 初始化 <see cref="Store"/> 類別的新執行個體。
        /// </summary>
        /// <param name="name">名稱。</param>
        /// <param name="description">描述。</param>
        /// <param name="phone">電話。</param>
        /// <param name="address">地址。</param>
        /// <param name="remark">備註。</param>
        /// <param name="createdBy">新增者 ID。</param>
        public Store(string name, string description, Phone phone, Address address, string remark, int createdBy)
            : this(0, name, description, phone, address, remark, createdBy)
        {
        }

        /// <summary>
        /// 初始化 <see cref="Store"/> 類別的新執行個體。
        /// </summary>
        /// <param name="storeId">店家 ID。</param>
        /// <param name="name">名稱。</param>
        /// <param name="description">描述。</param>
        /// <param name="phone">電話。</param>
        /// <param name="address">地址。</param>
        /// <param name="remark">備註。</param>
        /// <param name="createdBy">新增者 ID。</param>
        public Store(int storeId, string name, string description, Phone phone, Address address, string remark, int createdBy)
        {
            StoreId = storeId;
            Name = name;
            Description = description;
            Phone = phone;
            Address = address;
            Remark = remark;
            CreatedBy = createdBy;
            CreatedOn = DateTime.Now;
        }

        /// <summary>
        /// 取得主鍵。
        /// </summary>
        /// <value>主鍵。</value>
        public int StoreId { get; private set; }

        /// <summary>
        /// 取得名稱。
        /// </summary>
        /// <value>名稱。</value>
        public string Name { get; private set; }

        /// <summary>
        /// 取得描述。
        /// </summary>
        /// <value>描述。</value>
        public string Description { get; private set; }

        /// <summary>
        /// 取得電話。
        /// </summary>
        /// <value>電話。</value>
        public Phone Phone { get; private set; }

        /// <summary>
        /// 取得地址。
        /// </summary>
        /// <value>地址。</value>
        public Address Address { get; private set; }

        /// <summary>
        /// 取得備註。
        /// </summary>
        /// <value>備註。</value>
        public string Remark { get; private set; }

        /// <summary>
        /// 取得新增者 ID。
        /// </summary>
        /// <value>新增者 ID。</value>
        public int CreatedBy { get; private set; }

        /// <summary>
        /// 取得新增時間。
        /// </summary>
        /// <value>新增時間。</value>
        public DateTime CreatedOn { get; private set; }

        /// <summary>
        /// 取得商品分類的集合。
        /// </summary>
        /// <value>商品分類。</value>
        public IReadOnlyCollection<ProductCategory> ProductCategories => productCategories;

        /// <summary>
        /// 取得團店家的集合。
        /// </summary>
        /// <value>團店家的集合。</value>
        //public IReadOnlyCollection<GroupStore> GroupStores => groupStores;
    }
}