﻿using System;
using System.Collections.Generic;
using System.Linq;
using MatchaLatte.Common.Domain;
using MatchaLatte.Ordering.Domain.Buyers;

namespace MatchaLatte.Ordering.Domain.Orders
{
    /// <summary>
    /// 訂單。
    /// </summary>
    public class Order : AggregateRoot
    {
        private List<OrderItem> orderDetails = new List<OrderItem>();

        /// <summary>
        /// 初始化 <see cref="Order"/> 類別的新執行個體。
        /// </summary>
        private Order()
        {
        }

        /// <summary>
        /// 初始化 <see cref="Order"/> 類別的新執行個體。
        /// </summary>
        /// <param name="groupId">團 ID。</param>
        /// <param name="buyerId">買家 ID。</param>
        public Order(Guid groupId, Guid buyerId)
        {
            GroupId = groupId;
            BuyerId = buyerId;
        }

        /// <summary>
        /// 取得應付金額。
        /// </summary>
        /// <value>應付金額。</value>
        public decimal AmountPayable => orderDetails.Sum(x => x.ProductItemPrice * x.Quantity);

        /// <summary>
        /// 取得實付金額。
        /// </summary>
        /// <value>實付金額。</value>
        public decimal AmountPaid { get; private set; }

        /// <summary>
        /// 取得團 ID。
        /// </summary>
        /// <value>團 ID。</value>
        public Guid GroupId { get; private set; }

        /// <summary>
        /// 取得買家 ID。
        /// </summary>
        /// <value>買家 ID。</value>
        public Guid BuyerId { get; private set; }

        /// <summary>
        /// 取得新增時間。
        /// </summary>
        /// <value>新增時間。</value>
        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;

        /// <summary>
        /// 取得付款時間。
        /// </summary>
        /// <value>付款時間。</value>
        public DateTime? PaidOn { get; private set; }

        /// <summary>
        /// 取得是否已付款。
        /// </summary>
        /// <value>是否已付款。</value>
        public bool HasPaid => AmountPaid > AmountPayable;

        /// <summary>
        /// 取得買家。
        /// </summary>
        /// <value>買家。</value>
        public Buyer Buyer { get; private set; }

        /// <summary>
        /// 取得訂單明細的集合。
        /// </summary>
        /// <value>訂單明細的集合。</value>
        public IReadOnlyCollection<OrderItem> OrderDetails => orderDetails;

        /// <summary>
        /// 付款。
        /// </summary>
        /// <param name="money">金額。</param>
        public void Pay(decimal money)
        {
            AmountPaid += money;
        }
    }
}