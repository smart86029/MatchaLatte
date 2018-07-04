﻿using System.Threading.Tasks;
using Manager.Domain.Models.GroupBuying;

namespace Manager.Domain.Repositories.GroupBuying
{
    /// <summary>
    /// 店家存放庫。
    /// </summary>
    public interface IStoreRepository
    {
        /// <summary>
        /// 取得店家。
        /// </summary>
        /// <param name="storeId">店家 ID。</param>
        /// <returns>店家。</returns>
        Task<Store> GetStoreAsync(int storeId);

        /// <summary>
        /// 加入店家。
        /// </summary>
        /// <param name="store">店家。</param>
        void Add(Store store);

        /// <summary>
        /// 更新店家。
        /// </summary>
        /// <param name="store">店家。</param>
        void Update(Store store);
    }
}