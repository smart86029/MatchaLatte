﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchaLatte.HumanResources.App.Queries.Employees;
using MatchaLatte.HumanResources.App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MatchaLatte.HumanResources.Api.Controllers
{
    /// <summary>
    /// 員工控制器。
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        }

        /// <summary>
        /// 取得所有員工。
        /// </summary>
        /// <param name="option">分頁查詢。</param>
        /// <returns>所有員工。</returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] EmployeeOption option)
        {
            var employees = await employeeService.GetEmployeesAsync(option);
            Response.Headers.Add("X-Total-Count", employees.ItemCount.ToString());

            return Ok(employees.Items);
        }
    }
}
