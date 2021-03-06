﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MatchaLatte.Common.Domain;

namespace MatchaLatte.HumanResources.Domain.Employees
{
    /// <summary>
    /// 員工存放庫。
    /// </summary>
    public interface IEmployeeRepository : IRepository<Employee>
    {
        /// <summary>
        /// 取得員工的集合。
        /// </summary>
        /// <param name="offset">略過的筆數。</param>
        /// <param name="limit">限制的筆數。</param>
        /// <returns>員工的集合。</returns>
        Task<ICollection<Employee>> GetEmployeesAsync(int offset, int limit);

        /// <summary>
        /// 取得員工。
        /// </summary>
        /// <param name="employeeId">員工 ID。</param>
        /// <returns>員工。</returns>
        Task<Employee> GetEmployeeAsync(Guid employeeId);

        /// <summary>
        /// 取得所有員工的數量。
        /// </summary>
        /// <returns>所有員工的數量。</returns>
        Task<int> GetEmployeesCountAsync();

        /// <summary>
        /// 加入員工。
        /// </summary>
        /// <param name="employee">員工。</param>
        void Add(Employee employee);

        /// <summary>
        /// 更新員工。
        /// </summary>
        /// <param name="employee">員工。</param>
        void Update(Employee employee);
    }
}